using Dragonfly.Plugin.GridTrading.Trade.GuoHai;
using System;
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

        internal void Init()
        {
            lock (lockObject)
            {
                trader.Init();
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

        internal void BuyStock(string stockCode, float price, int volume)
        {
            lock (lockObject)
            {
                trader.BuyStock(stockCode, price, volume);
            }
        }

        internal void SellStock(string stockCode, float price, int volume)
        {
            lock (lockObject)
            {
                trader.SellStock(stockCode, price, volume);
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

        internal Tuple<ModelAccountStat, List<ModelHoldingStock>> HoldingStockList()
        {
            lock (lockObject)
            {
                return trader.HoldingStockList();
            }
        }

        #endregion

        #region 沪港通


        internal void HgtBuyStock(string stockCode, float price, int volume)
        {
            lock (lockObject)
            {
                trader.HgtBuyStock(stockCode, price, volume);
            }
        }

        internal void HgtSellStock(string stockCode, float price, int volume)
        {
            lock (lockObject)
            {
                trader.HgtSellStock(stockCode, price, volume);
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

        internal Tuple<ModelAccountStat, List<ModelHoldingStock>> HgtHoldingStockList()
        {
            lock (lockObject)
            {
                return trader.HgtHoldingStockList();
            }
        }

        #endregion

        #region 深港通


        internal void SgtBuyStock(string stockCode, float price, int volume)
        {
            lock (lockObject)
            {
                trader.SgtBuyStock(stockCode, price, volume);
            }
        }

        internal void SgtSellStock(string stockCode, float price, int volume)
        {
            lock (lockObject)
            {
                trader.SgtSellStock(stockCode, price, volume);
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

        internal Tuple<ModelAccountStat, List<ModelHoldingStock>> SgtHoldingStockList()
        {
            lock (lockObject)
            {
                return trader.SgtHoldingStockList();
            }
        }

        #endregion

    }
}
