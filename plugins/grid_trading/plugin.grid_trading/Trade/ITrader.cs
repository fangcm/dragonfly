using System;
using System.Collections.Generic;

namespace Dragonfly.Plugin.GridTrading.Trade
{
    // 交易接口
    internal interface ITrader
    {
        bool Init();

        void KeepAlive();

        void SellStock(string code, float price, int num);

        void BuyStock(string code, float price, int num);

        void CancelStock(string code, float price, int num);

        List<ModelTodayDeals> TodayDealsList();

        Tuple<ModelAccountStat, List<ModelHoldingStock>> HoldingStockList();

    }
}
