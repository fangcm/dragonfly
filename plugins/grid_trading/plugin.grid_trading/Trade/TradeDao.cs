using System;
using System.Collections.Generic;
using Dragonfly.Plugin.GridTrading.Strategy;
using Dragonfly.Plugin.GridTrading.Trade.GuoHai;

namespace Dragonfly.Plugin.GridTrading.Trade
{
    internal class TradeDao
    {
        internal static void SaveOrUpdateTodayDeals(StockMarket market, List<ModelTodayDeals> todayDeals)
        {
            throw new NotImplementedException();
        }

        internal static TradingRecord FindLastTradingRecord(StockMarket stockMarket, string stockCode)
        {
            throw new NotImplementedException();
        }
    }

    internal class TradingRecord : ModelTodayDeals
    {
        internal int id = 0; // db主键
        internal int stockMarket = 0; // 市场
        internal string createTime = string.Empty; // 创建时间 yyyy-mm-dd hh:mm:ss
    }
}