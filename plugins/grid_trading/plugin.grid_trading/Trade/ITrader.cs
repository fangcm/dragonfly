using System;

namespace Dragonfly.Plugin.GridTrading.Trade
{
    // 交易接口
    public interface ITrader
    {
        bool Init();

        void SellStock(string code, float price, int num);

        void BuyStock(string code, float price, int num);

        void CancelStock(string code, float price, int num);

        void TodayDealsList();

        void HoldingStockList();
        
    }
}
