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

        internal void CancelStock(string code, float price, int num)
        {
            lock (lockObject)
            {
                trader.CancelStock(code, price, num);
            }
        }

        internal List<string[]> TodayDealsList()
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

    }
}
