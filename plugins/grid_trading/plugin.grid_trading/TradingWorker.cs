using Dragonfly.Plugin.GridTrading.Strategy;
using Dragonfly.Plugin.GridTrading.Trade;
using Dragonfly.Plugin.GridTrading.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<ModelTodayDeals> todayDeals;

            // 查询当日可撤委托
            List<ModelRevocableOrder> revocableOrders;

            // 查询持仓数据
            Tuple<ModelAccountStat, List<ModelHoldingStock>> holdingStocks;

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
                grid.LastTradingOrder = new GridOrder() { Direction =, Price =, Volume = };

                // 算出下一笔的买卖单
                GridNode nodeByPrice = grid.ExpectedGridNode(price);
                GridNode nodeByVolume = grid.ExpectedGridNode(holdingVolume);
                // 不一致, 忽略


                // 对比委托记录，是否已经下单



                // 下单，（保存委托记录，仅作为日志）
                switch (grid.StockMarket)
                {
                    case StockMarket.A:
                        if (nodeByPrice.BuyOrder != null)
                        {
                            TraderHelper.Instance.BuyStock(grid.StockCode, nodeByPrice.BuyOrder.Price, nodeByPrice.BuyOrder.Volume);
                        }
                        if (nodeByPrice.BuyOrder != null)
                        {
                            TraderHelper.Instance.SellStock(grid.StockCode, nodeByPrice.SellOrder.Price, nodeByPrice.SellOrder.Volume);
                        }
                        break;
                    case StockMarket.Hgt:
                        if (nodeByPrice.BuyOrder != null)
                        {
                            TraderHelper.Instance.HgtBuyStock(grid.StockCode, nodeByPrice.BuyOrder.Price, nodeByPrice.BuyOrder.Volume);
                        }
                        if (nodeByPrice.BuyOrder != null)
                        {
                            TraderHelper.Instance.HgtSellStock(grid.StockCode, nodeByPrice.SellOrder.Price, nodeByPrice.SellOrder.Volume);
                        }
                        break;
                    case StockMarket.Sgt:
                        if (nodeByPrice.BuyOrder != null)
                        {
                            TraderHelper.Instance.SgtBuyStock(grid.StockCode, nodeByPrice.BuyOrder.Price, nodeByPrice.BuyOrder.Volume);
                        }
                        if (nodeByPrice.BuyOrder != null)
                        {
                            TraderHelper.Instance.SgtSellStock(grid.StockCode, nodeByPrice.SellOrder.Price, nodeByPrice.SellOrder.Volume);
                        }
                        break;
                }
            }
        }

    }
}
