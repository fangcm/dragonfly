using System.Collections.Generic;

namespace Dragonfly.Plugin.GridTrading.Trade
{
    // 交易接口
    public interface ITrader
    {
        bool Init();

        void SellStock(string code, float price, int num);

        void BuyStock(string code, float price, int num);

        void CancelStock(string code, float price, int num);

        List<Dictionary<string, string>> TodayDealsList();

        List<Dictionary<string, string>> HoldingStockList();

    }
}
