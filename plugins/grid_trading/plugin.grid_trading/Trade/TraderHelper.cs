using Dragonfly.Plugin.GridTrading.Trade.GuoHai;
using System.Collections.Generic;

namespace Dragonfly.Plugin.GridTrading.Trade
{
    internal class TraderHelper
    {
        private static TraderHelper instance = new TraderHelper();
        internal static TraderHelper Instance
        {
            get { return instance; }
        }

        object lockObject = new object();
        ITrader trader = new JintanhaoTrader();

        internal bool Init()
        {
            lock (lockObject)
            {
                return trader.Init();
            }
        }

        internal void KeepAlive()
        {
            lock (lockObject)
            {
                trader.KeepAlive();
            }
        }

        #region A股

        internal bool BuyStock(string stockCode, decimal price, int volume)
        {
            lock (lockObject)
            {
                return trader.BuyStock(stockCode, price, volume);
            }
        }

        internal bool SellStock(string stockCode, decimal price, int volume)
        {
            lock (lockObject)
            {
                return trader.SellStock(stockCode, price, volume);
            }
        }

        internal List<ModelRevocableOrder> RevocableOrders()
        {
            lock (lockObject)
            {
                return trader.RevocableOrders();
            }
        }

        internal List<ModelTodayDeals> TodayDealsList()
        {
            lock (lockObject)
            {
                return trader.TodayDealsList();
            }
        }

        internal List<ModelHoldingStock> HoldingStockList()
        {
            lock (lockObject)
            {
                return trader.HoldingStockList();
            }
        }

        #endregion

        #region 沪港通


        internal bool HgtBuyStock(string stockCode, decimal price, int volume)
        {
            lock (lockObject)
            {
                return trader.HgtBuyStock(stockCode, price, volume);
            }
        }

        internal bool HgtSellStock(string stockCode, decimal price, int volume)
        {
            lock (lockObject)
            {
                return trader.HgtSellStock(stockCode, price, volume);
            }
        }

        internal List<ModelRevocableOrder> HgtRevocableOrders()
        {
            lock (lockObject)
            {
                return trader.HgtRevocableOrders();
            }
        }

        internal List<ModelTodayDeals> HgtTodayDealsList()
        {
            lock (lockObject)
            {
                return trader.HgtTodayDealsList();
            }
        }

        internal List<ModelHoldingStock> HgtHoldingStockList()
        {
            lock (lockObject)
            {
                return trader.HgtHoldingStockList();
            }
        }

        #endregion

        #region 深港通


        internal bool SgtBuyStock(string stockCode, decimal price, int volume)
        {
            lock (lockObject)
            {
                return trader.SgtBuyStock(stockCode, price, volume);
            }
        }

        internal bool SgtSellStock(string stockCode, decimal price, int volume)
        {
            lock (lockObject)
            {
                return trader.SgtSellStock(stockCode, price, volume);
            }
        }

        internal List<ModelRevocableOrder> SgtRevocableOrders()
        {
            lock (lockObject)
            {
                return trader.SgtRevocableOrders();
            }
        }

        internal List<ModelTodayDeals> SgtTodayDealsList()
        {
            lock (lockObject)
            {
                return trader.SgtTodayDealsList();
            }
        }

        internal List<ModelHoldingStock> SgtHoldingStockList()
        {
            lock (lockObject)
            {
                return trader.SgtHoldingStockList();
            }
        }

        #endregion

    }
}
