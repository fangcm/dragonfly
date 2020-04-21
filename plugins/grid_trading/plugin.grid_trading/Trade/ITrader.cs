using System;

namespace Dragonfly.Plugin.GridTrading.Trade
{
    // 交易接口
    public interface ITrader
    {
        bool Init();

        void SellStock(String code, float price, int num);

        void BuyStock(String code, float price, int num);

        void CancelStock(String code, float price, int num);

        void TodayDealsList();

        void HoldingStockList();

        void CashInfo();
        
    }
}
