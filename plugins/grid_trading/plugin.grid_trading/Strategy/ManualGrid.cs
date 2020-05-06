using System.Linq;

namespace Dragonfly.Plugin.GridTrading.Strategy
{
    internal class ManualGrid : Grid
    {

        protected override void Init()
        {
            base.Init();

            if (GridNodes == null || GridNodes.Count == 0)
            {
                return;
            }

            foreach (var node in GridNodes)
            {
                int index = GridNodes.FindIndex(x => x.TradingPrice == node.TradingPrice);

                GridOrder buyOrder = null;
                GridOrder sellOrder = null;
                if (index > 0)
                {
                    var temp = GridNodes.ElementAt(index - 1);
                    buyOrder = new GridOrder()
                    {
                        Price = temp.TradingPrice,
                        Volume = temp.HoldingVolume - node.HoldingVolume,
                    };
                }

                if (index < GridNodes.Count - 1)
                {
                    var temp = GridNodes.ElementAt(index + 1);
                    sellOrder = new GridOrder()
                    {
                        Price = temp.TradingPrice,
                        Volume = node.HoldingVolume - temp.HoldingVolume,
                    };
                }

                node.SellOrder = sellOrder;
                node.BuyOrder = buyOrder;

                if (index == 0)
                {
                    MinPrice = node.TradingPrice;
                }
                else if (index == GridNodes.Count - 1)
                {
                    MaxPrice = node.TradingPrice;
                }

            }
        }
    }
}
