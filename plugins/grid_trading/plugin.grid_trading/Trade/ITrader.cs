using Dragonfly.Plugin.GridTrading.Trade.GuoHai;
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

        bool BuyStock(string stockCode, decimal price, int volume);

        bool SellStock(string stockCode, decimal price, int volume);

        List<ModelRevocableOrder> RevocableOrders(); // 可撤订单

        List<ModelTodayDeals> TodayDealsList();

        List<ModelHoldingStock> HoldingStockList();

        #endregion

        #region 沪港通

        bool HgtBuyStock(string stockCode, decimal price, int volume);

        bool HgtSellStock(string stockCode, decimal price, int volume);

        List<ModelRevocableOrder> HgtRevocableOrders(); // 可撤订单

        List<ModelTodayDeals> HgtTodayDealsList();

        List<ModelHoldingStock> HgtHoldingStockList();

        #endregion

        #region 深港通

        bool SgtBuyStock(string stockCode, decimal price, int volume);

        bool SgtSellStock(string stockCode, decimal price, int volume);

        List<ModelRevocableOrder> SgtRevocableOrders(); // 可撤订单

        List<ModelTodayDeals> SgtTodayDealsList();

        List<ModelHoldingStock> SgtHoldingStockList();

        #endregion

    }


}
