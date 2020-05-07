﻿using Dragonfly.Plugin.GridTrading.Strategy;
using Dragonfly.Plugin.GridTrading.Trade;
using Dragonfly.Plugin.GridTrading.Utils;
using System;
using System.Collections.Generic;

namespace Dragonfly.Plugin.GridTrading
{
    internal class TradingWorker
    {
        internal static void start()
        {
            // 获取策略网格
            List<Grid> grids = GridDao.GetAllGrids();
            if (grids == null || grids.Count == 0)
            {
                LoggerUtil.Log(LoggType.Gray, "无网格策略可用");
                return;
            }

            List<Grid> gridsForA = grids.FindAll(x => x.StockMarket == StockMarket.A);
            ProgressMarket(StockMarket.A, gridsForA);
            List<Grid> gridsForHgt = grids.FindAll(x => x.StockMarket == StockMarket.Hgt);
            ProgressMarket(StockMarket.Hgt, gridsForHgt);
            List<Grid> gridsForSgt = grids.FindAll(x => x.StockMarket == StockMarket.Sgt);
            ProgressMarket(StockMarket.Sgt, gridsForSgt);
        }


        private static void ProgressMarket(StockMarket market, List<Grid> grids)
        {
            if (grids == null || grids.Count == 0)
            {
                LoggerUtil.Log(LoggType.Gray, "无网格策略,在市场：" + market.ToString());
                return;
            }

            // 查询当日最后成交（同步当日成交记录）
            List<ModelTodayDeals> todayDeals = null;

            // 查询当日可撤委托
            List<ModelRevocableOrder> revocableOrders = null;

            // 查询持仓数据
            List<ModelHoldingStock> holdingStocks = null;

            switch (market)
            {
                case StockMarket.A:
                    todayDeals = TraderHelper.Instance.TodayDealsList();
                    TradeDao.SaveOrUpdateTodayDeals(StockMarket.A, todayDeals);
                    revocableOrders = TraderHelper.Instance.RevocableOrders();
                    holdingStocks = TraderHelper.Instance.HoldingStockList();
                    break;
                case StockMarket.Hgt:
                    todayDeals = TraderHelper.Instance.HgtTodayDealsList();
                    TradeDao.SaveOrUpdateTodayDeals(StockMarket.Hgt, todayDeals);
                    revocableOrders = TraderHelper.Instance.HgtRevocableOrders();
                    holdingStocks = TraderHelper.Instance.HgtHoldingStockList();
                    break;
                case StockMarket.Sgt:
                    todayDeals = TraderHelper.Instance.SgtTodayDealsList();
                    TradeDao.SaveOrUpdateTodayDeals(StockMarket.Sgt, todayDeals);
                    revocableOrders = TraderHelper.Instance.SgtRevocableOrders();
                    holdingStocks = TraderHelper.Instance.SgtHoldingStockList();
                    break;
            }




            foreach (Grid grid in grids)
            {
                // 查出历史最后成交
                TradingRecord tr = TradeDao.FindLastTradingRecord(grid.StockMarket, grid.StockCode);
                grid.LastTradingOrder = new GridOrder() { Direction = tr.ConvertDirectionToInt(), Price = tr.tradePrice, Volume = tr.tradeVolume };

                // 算出下一笔的买卖单
                GridNode nodeByPrice = grid.ExpectedGridNodeByPrice(tr.tradePrice);

                int holdingVolume = FindStockHoldingVolume(grid.StockMarket, grid.StockCode, holdingStocks);
                GridNode nodeByVolume = grid.ExpectedGridNodeByHoldingVolume(holdingVolume);
                // 不一致, 忽略
                bool sameNode = Grid.Equals(nodeByPrice, nodeByVolume);
                if (!sameNode)
                {
                    LoggerUtil.Log(LoggType.Red, "网格策略在判断当前网格节点时存在不一致，需人工参与。 市场：" + grid.StockMarket.ToString() +
                        ", 股票：" + grid.StockCode + ", 价格" + tr.tradePrice + ", 数量：" + tr.tradeVolume + ", 持仓：" + holdingStocks);
                    return;
                }


                // 判断可撤委托是否有该笔订单
                bool doBuyOrder, doSellOrder;

                if (nodeByPrice.BuyOrder == null)
                {
                    doBuyOrder = false;
                }
                else
                {
                    bool existOrder = IsExistRevocableOrders(Direction.buy, grid.StockCode, nodeByPrice.BuyOrder.Price, nodeByPrice.BuyOrder.Volume, revocableOrders);
                    doBuyOrder = !existOrder;
                }

                if (nodeByPrice.SellOrder == null)
                {
                    doSellOrder = false;
                }
                else
                {
                    bool existOrder = IsExistRevocableOrders(Direction.sell, grid.StockCode, nodeByPrice.SellOrder.Price, nodeByPrice.SellOrder.Volume, revocableOrders);
                    doSellOrder = !existOrder;
                }


                // 下单，（保存委托记录，仅作为日志）
                switch (grid.StockMarket)
                {
                    case StockMarket.A:
                        if (doBuyOrder)
                        {
                            TraderHelper.Instance.BuyStock(grid.StockCode, nodeByPrice.BuyOrder.Price, nodeByPrice.BuyOrder.Volume);
                        }
                        if (doSellOrder)
                        {
                            TraderHelper.Instance.SellStock(grid.StockCode, nodeByPrice.SellOrder.Price, nodeByPrice.SellOrder.Volume);
                        }
                        break;
                    case StockMarket.Hgt:
                        if (doBuyOrder)
                        {
                            TraderHelper.Instance.HgtBuyStock(grid.StockCode, nodeByPrice.BuyOrder.Price, nodeByPrice.BuyOrder.Volume);
                        }
                        if (doSellOrder)
                        {
                            TraderHelper.Instance.HgtSellStock(grid.StockCode, nodeByPrice.SellOrder.Price, nodeByPrice.SellOrder.Volume);
                        }
                        break;
                    case StockMarket.Sgt:
                        if (doBuyOrder)
                        {
                            TraderHelper.Instance.SgtBuyStock(grid.StockCode, nodeByPrice.BuyOrder.Price, nodeByPrice.BuyOrder.Volume);
                        }
                        if (doSellOrder)
                        {
                            TraderHelper.Instance.SgtSellStock(grid.StockCode, nodeByPrice.SellOrder.Price, nodeByPrice.SellOrder.Volume);
                        }
                        break;
                }
            }
        }

        private static int FindStockHoldingVolume(StockMarket stockMarket, string stockCode, List<ModelHoldingStock> holdingStocks)
        {
            if (holdingStocks == null || holdingStocks.Count == 0)
            {
                return 0;
            }

            foreach (ModelHoldingStock hs in holdingStocks)
            {
                if (hs.stockCode == stockCode)
                {
                    // todo: hgt ?
                    return hs.holdingVolume;
                }
            }

            return 0;
        }

        private static bool IsExistRevocableOrders(Direction direction, string stockCode, decimal price, int volume, List<ModelRevocableOrder> revocableOrders)
        {
            if (revocableOrders == null || revocableOrders.Count == 0)
            {
                return false;
            }

            foreach (ModelRevocableOrder ro in revocableOrders)
            {
                if (ro.stockCode == stockCode && ro.orderVolume == volume && ro.ConvertDirectionToInt() == direction &&
                    Math.Abs(ro.orderPrice - price) < decimal.Parse("0.02"))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
