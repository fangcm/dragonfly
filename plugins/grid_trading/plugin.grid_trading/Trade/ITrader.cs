using System;
using System.Collections.Generic;

namespace Dragonfly.Plugin.GridTrading.Trade
{
    // 交易接口
    internal interface ITrader
    {
        bool Init();

        void KeepAlive();

        #region A股

        void BuyStock(string stockCode, decimal price, int volume);

        void SellStock(string stockCode, decimal price, int volume);

        List<ModelRevocableOrder> RevocableOrders(); // 可撤订单

        List<ModelTodayDeals> TodayDealsList();

        Tuple<ModelAccountStat, List<ModelHoldingStock>> HoldingStockList();

        #endregion

        #region 沪港通

        void HgtBuyStock(string stockCode, decimal price, int volume);

        void HgtSellStock(string stockCode, decimal price, int volume);

        List<ModelRevocableOrder> HgtRevocableOrders(); // 可撤订单

        List<ModelTodayDeals> HgtTodayDealsList();

        Tuple<ModelAccountStat, List<ModelHoldingStock>> HgtHoldingStockList();

        #endregion

        #region 深港通

        void SgtBuyStock(string stockCode, decimal price, int volume);

        void SgtSellStock(string stockCode, decimal price, int volume);

        List<ModelRevocableOrder> SgtRevocableOrders(); // 可撤订单

        List<ModelTodayDeals> SgtTodayDealsList();

        Tuple<ModelAccountStat, List<ModelHoldingStock>> SgtHoldingStockList();

        #endregion

    }


}
