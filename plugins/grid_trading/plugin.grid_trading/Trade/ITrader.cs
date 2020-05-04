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

        void BuyStock(string code, float price, int num);

        void SellStock(string code, float price, int num);

        List<ModelRevocableOrder> RevocableOrders(); // 可撤订单

        List<ModelTodayDeals> TodayDealsList();

        Tuple<ModelAccountStat, List<ModelHoldingStock>> HoldingStockList();

        #endregion

        #region 沪港通

        void HgtBuyStock(string code, float price, int num);

        void HgtSellStock(string code, float price, int num);

        List<ModelRevocableOrder> HgtRevocableOrders(); // 可撤订单

        List<ModelTodayDeals> HgtTodayDealsList();

        Tuple<ModelAccountStat, List<ModelHoldingStock>> HgtHoldingStockList();

        #endregion

        #region 深港通

        void SgtBuyStock(string code, float price, int num);

        void SgtSellStock(string code, float price, int num);

        List<ModelRevocableOrder> SgtRevocableOrders(); // 可撤订单

        List<ModelTodayDeals> SgtTodayDealsList();

        Tuple<ModelAccountStat, List<ModelHoldingStock>> SgtHoldingStockList();

        #endregion

    }


}
