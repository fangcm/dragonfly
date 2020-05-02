using Dragonfly.Plugin.GridTrading.Trade.GuoHai;
using System.Collections.Generic;

namespace Dragonfly.Plugin.GridTrading.Trade
{
    public class TraderHelper
    {
        private static TraderHelper instance = new TraderHelper();
        public static TraderHelper Instance
        {
            get { return instance; }
        }

        object lockObject = new object();
        ITrader trader = new JintanhaoTrader();

        public void Init()
        {
            lock (lockObject)
            {
                trader.Init();
            }
        }


        public void BuyStock(string code, float price, int num)
        {
            lock (lockObject)
            {
                trader.BuyStock(code, price, num);
            }
        }

        public void SellStock(string code, float price, int num)
        {
            lock (lockObject)
            {
                trader.SellStock(code, price, num);
            }
        }

        public void CancelStock(string code, float price, int num)
        {
            lock (lockObject)
            {
                trader.CancelStock(code, price, num);
            }
        }

        public List<Dictionary<string, string>> TodayDealsList()
        {
            lock (lockObject)
            {
                return trader.TodayDealsList();
            }
        }

        public List<Dictionary<string, string>> HoldingStockList()
        {
            lock (lockObject)
            {
                return trader.HoldingStockList();
            }
        }

    }
}
