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

        internal void BuyStock(string code, float price, int num)
        {
            lock (lockObject)
            {
                trader.BuyStock(code, price, num);
            }
        }

        internal void SellStock(string code, float price, int num)
        {
            lock (lockObject)
            {
                trader.SellStock(code, price, num);
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


        internal void HgtBuyStock(string code, float price, int num)
        {
            lock (lockObject)
            {
                trader.HgtBuyStock(code, price, num);
            }
        }

        internal void HgtSellStock(string code, float price, int num)
        {
            lock (lockObject)
            {
                trader.HgtSellStock(code, price, num);
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


        internal void SgtBuyStock(string code, float price, int num)
        {
            lock (lockObject)
            {
                trader.SgtBuyStock(code, price, num);
            }
        }

        internal void SgtSellStock(string code, float price, int num)
        {
            lock (lockObject)
            {
                trader.SgtSellStock(code, price, num);
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
