using Dragonfly.Plugin.GridTrading.Trade.GuoHai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragonfly.Plugin.GridTrading.Trade
{
    public class TraderHelper
    {
        private static TraderHelper instance = new TraderHelper();
        ITrader trader = new JinbeikeTrader();

        public void Init()
        {
            trader.Init();
        }

        public static TraderHelper Instance
        {
            get { return instance; }
        }

        public void BuyStock(String code, float price, int num)
        {
            // TODO: 检查？分钟内是否重复购买
            trader.BuyStock(code, price, num);
            // 保存下单记录到文件
        }

        public void SellStock(String code, float price, int num)
        {
            // TODO: 检查？分钟内是否重复卖出
            trader.SellStock(code, price, num);
            // 保存下单记录到文件
        }

        public void CancelStock(String code, float price, int num)
        {
            // TODO: 检查？分钟内是否重复卖出
            trader.CancelStock(code, price, num);
            // 保存下单记录到文件
        }
    }
}
