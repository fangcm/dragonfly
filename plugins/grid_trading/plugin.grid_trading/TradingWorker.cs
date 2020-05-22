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
                LoggerUtil.Log(LoggType.MediumBlue, "无网格策略可用");
                return;
            }

            LoggerUtil.Log(LoggType.Gray, "开始策略交易 ......");

            List<Grid> gridsForA = grids.FindAll(x => x.StockMarket == StockMarket.A);
            ProgressMarket(StockMarket.A, gridsForA);
            List<Grid> gridsForHgt = grids.FindAll(x => x.StockMarket == StockMarket.Hgt);
            ProgressMarket(StockMarket.Hgt, gridsForHgt);
            List<Grid> gridsForSgt = grids.FindAll(x => x.StockMarket == StockMarket.Sgt);
            ProgressMarket(StockMarket.Sgt, gridsForSgt);

            LoggerUtil.Log(LoggType.Gray, "结束本次策略交易");
        }


        private static void ProgressMarket(StockMarket market, List<Grid> grids)
        {
            if (grids == null || grids.Count == 0)
            {
                LoggerUtil.Log(LoggType.Gray, "在市场【" + market.ToString() + "】无网格策略");
                return;
            }

            bool isTradingTime = true;
            string tradingType = StockMarketTradingPeriods.Instance.CurrentTimeTradingType(market);
            if (string.IsNullOrEmpty(tradingType))
            {
                isTradingTime = false;
                LoggerUtil.Log(LoggType.Gray, "市场【" + market.ToString() + "】未到下单时间，只做成交数据同步");
            }

            // 查询当日最后成交（同步当日成交记录）
            List<ModelTodayDeals> todayDeals = null;

            // 查询当日可撤委托
            List<ModelRevocableOrder> revocableOrders = null;

            // 查询持仓数据
            List<ModelHoldingStock> holdingStocks = null;

            try
            {
                switch (market)
                {
                    case StockMarket.A:
                        todayDeals = TraderHelper.Instance.TodayDealsList();
                        TradeDao.SaveOrUpdateTodayDeals(StockMarket.A, todayDeals);
                        if (isTradingTime)
                        {
                            revocableOrders = TraderHelper.Instance.RevocableOrders();
                            holdingStocks = TraderHelper.Instance.HoldingStockList();
                        }
                        break;
                    case StockMarket.Hgt:
                        todayDeals = TraderHelper.Instance.HgtTodayDealsList();
                        TradeDao.SaveOrUpdateTodayDeals(StockMarket.Hgt, todayDeals);
                        if (isTradingTime)
                        {
                            revocableOrders = TraderHelper.Instance.HgtRevocableOrders();
                            holdingStocks = TraderHelper.Instance.HgtHoldingStockList();
                        }
                        break;
                    case StockMarket.Sgt:
                        todayDeals = TraderHelper.Instance.SgtTodayDealsList();
                        TradeDao.SaveOrUpdateTodayDeals(StockMarket.Sgt, todayDeals);
                        if (isTradingTime)
                        {
                            revocableOrders = TraderHelper.Instance.SgtRevocableOrders();
                            holdingStocks = TraderHelper.Instance.SgtHoldingStockList();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                LoggerUtil.Log(LoggType.MediumBlue, "异常：" + ex.Message);
                return;
            }

            if (!isTradingTime)
            {
                //未到交易时间
                return;
            }

            foreach (Grid grid in grids)
            {
                // 查出历史最后成交价格
                ModelTodayDeals tr = TradeDao.FindLastTradingPrice(grid.StockMarket, grid.StockCode);

                decimal lastTradePrice;
                if (tr != null && tr.tradePrice > 0)
                {
                    lastTradePrice = tr.tradePrice;
                }
                else
                {
                    lastTradePrice = grid.InitPrice;
                }
                // 算出下一笔的买卖单
                GridNode nodeByPrice = grid.ExpectedGridNodeByPrice(lastTradePrice);

                int holdingVolume = FindStockHoldingVolume(grid.StockMarket, grid.StockCode, holdingStocks);
                if (holdingVolume == 0)
                {
                    LoggerUtil.Log(LoggType.MediumBlue, "忽略：" + grid.StockMarket.ToString() + "【" + grid.StockCode + "】持仓为0");
                    continue;
                }

                GridNode nodeByVolume = grid.ExpectedGridNodeByHoldingVolume(holdingVolume);
                // 不一致, 忽略
                bool sameNode = Grid.Equals(nodeByPrice, nodeByVolume);
                if (!sameNode)
                {
                    LoggerUtil.Log(LoggType.MediumBlue, "忽略：判断网格节点时有歧义，" + grid.StockMarket.ToString() + "【" + grid.StockCode + "】最后交易价：" + lastTradePrice + ",持仓：" + holdingVolume);
                    continue;
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
                    if (existOrder)
                    {
                        LoggerUtil.Log(LoggType.Gray, "买单已存在：" + grid.StockMarket.ToString() + "【" + grid.StockCode + "】,价：" + nodeByPrice.BuyOrder.Price + ",量：" + nodeByPrice.BuyOrder.Volume);
                    }
                    doBuyOrder = !existOrder;
                }

                if (nodeByPrice.SellOrder == null)
                {
                    doSellOrder = false;
                }
                else
                {
                    bool existOrder = IsExistRevocableOrders(Direction.sell, grid.StockCode, nodeByPrice.SellOrder.Price, nodeByPrice.SellOrder.Volume, revocableOrders);
                    if (existOrder)
                    {
                        LoggerUtil.Log(LoggType.Gray, "卖单已存在：" + grid.StockMarket.ToString() + "【" + grid.StockCode + "】,价：" + nodeByPrice.SellOrder.Price + ",量：" + nodeByPrice.SellOrder.Volume);
                    }
                    doSellOrder = !existOrder;
                }


                // 下单
                try
                {
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
                catch (Exception ex)
                {
                    LoggerUtil.Log(LoggType.MediumBlue, "异常：" + ex.Message);
                    return;
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
                    return hs.FixHoldingVolume;
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
                    Math.Abs(ro.orderPrice - price) < decimal.Parse("0.001"))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
