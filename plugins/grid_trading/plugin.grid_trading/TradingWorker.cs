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

            // 查询当日最后成交（同步当日成交记录）
            List<ModelTodayDeals> todayDeals;

            todayDeals = TraderHelper.Instance.TodayDealsList();
            TradeDao.SaveOrUpdateTodayDeals(StockMarket.A,todayDeals);

            todayDeals = TraderHelper.Instance.HgtTodayDealsList();
            TradeDao.SaveOrUpdateTodayDeals(StockMarket.Hgt, todayDeals);

            todayDeals = TraderHelper.Instance.SgtTodayDealsList();
            TradeDao.SaveOrUpdateTodayDeals(StockMarket.Sgt, todayDeals);

            // 查询当日可撤委托
            List<ModelRevocableOrder> revocableOrderA = TraderHelper.Instance.RevocableOrders();
            List<ModelRevocableOrder> revocableOrderHgt = TraderHelper.Instance.HgtRevocableOrders();
            List<ModelRevocableOrder> revocableOrderSgt = TraderHelper.Instance.SgtRevocableOrders();

            foreach(Grid grid in grids) {
                // 查出历史最后成交
                TradingRecord tr = TradeDao.FindLastTradingRecord(grid.StockMarket, grid.StockCode);
                grid.LastTradingOrder = new GridOrder() { Direction =, Price =, Volume = };

                // 算出下一笔的买卖单
                grid.ExpectedGridNode(price)
                grid.ExpectedGridNode(holdingVolume)


                // （同步委托记录），是否已经下单



                // 下单，保存委托记录
            }

        }
    }
}
