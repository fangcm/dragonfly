using Dragonfly.Plugin.GridTrading.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragonfly.Plugin.GridTrading.Trade
{
    internal class StockMarketTradingPeriods
    {
        private static StockMarketTradingPeriods instance = new StockMarketTradingPeriods();
        internal static StockMarketTradingPeriods Instance
        {
            get { return instance; }
        }

        internal List<TradablePeriod> periodsA = new List<TradablePeriod>(); //A股交易时段
        internal List<TradablePeriod> periodsGgt = new List<TradablePeriod>(); //港股通交易时段

        private StockMarketTradingPeriods()
        {
            periodsA.Add(new TradablePeriod() { StartTime = 0, EndTime = 150000, TradeType = "限价委托" });
            periodsA.Add(new TradablePeriod() { StartTime = 173000, EndTime = 235959, TradeType = "限价委托" });

            periodsGgt.Add(new TradablePeriod() { StartTime = 90000, EndTime = 91500, TradeType = "竞价限价盘" });
            periodsGgt.Add(new TradablePeriod() { StartTime = 93000, EndTime = 160000, TradeType = "增强限价盘" });
            periodsGgt.Add(new TradablePeriod() { StartTime = 160000, EndTime = 161000, TradeType = "竞价限价盘" });
        }

        internal string CurrentTimeTradingType(StockMarket market)
        {
            int time = int.Parse(DateTime.Now.ToString("Hmmss"));

            List<TradablePeriod> periods = null;
            switch (market)
            {
                case StockMarket.A:
                    periods = periodsA;
                    break;
                case StockMarket.Hgt:
                case StockMarket.Sgt:
                    periods = periodsGgt;
                    break;
            }

            if (periods == null)
            {
                return string.Empty;
            }

            foreach (TradablePeriod period in periods)
            {
                if (time > period.StartTime && time < period.EndTime)
                {
                    return period.TradeType;
                }

            }

            return string.Empty;
        }

    }

    internal class TradablePeriod
    {
        internal int StartTime { get; set; }
        internal int EndTime { get; set; }
        internal string TradeType { get; set; }
    }

}
