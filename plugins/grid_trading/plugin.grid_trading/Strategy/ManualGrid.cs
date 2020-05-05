using System.Collections.Generic;
using System.Linq;

namespace Dragonfly.Plugin.GridTrading.Strategy
{
    internal class ManualGrid : Grid
    {
        internal Dictionary<string, object> priceAndHoldingVolume = new Dictionary<string, object>();

        internal override void Init(Dictionary<string, object> config)
        {
            base.Init(config);

            object temp;

            if (config.TryGetValue("PriceAndHoldingVolume", out temp))
            {
                priceAndHoldingVolume = (Dictionary<string, object>)temp;
                foreach (var cfg in priceAndHoldingVolume)
                {

                    GridItem item = new GridItem()
                    {
                        TradingPrice = decimal.Parse(cfg.Key),
                        HoldingVolume = int.Parse(cfg.Value.ToString()),
                    };
                    gridItemList.Add(item.TradingPrice, item);
                }

                buildTradingGrid();
            }
        }

        private void buildTradingGrid()
        {
            foreach (var item in gridItemList)
            {
                int index = gridItemList.IndexOfKey(item.Key);

                GridOrder buyOrder = null;
                GridOrder sellOrder = null;
                if (index > 0)
                {
                    var temp = gridItemList.ElementAt(index - 1);
                    buyOrder = new GridOrder()
                    {
                        Price = temp.Value.TradingPrice,
                        Volume = temp.Value.HoldingVolume - item.Value.HoldingVolume,
                    };
                }

                if (index < gridItemList.Count - 1)
                {
                    var temp = gridItemList.ElementAt(index + 1);
                    sellOrder = new GridOrder()
                    {
                        Price = temp.Value.TradingPrice,
                        Volume = item.Value.HoldingVolume - temp.Value.HoldingVolume,
                    };
                }

                item.Value.SellOrder = sellOrder;
                item.Value.BuyOrder = buyOrder;

                if (index == 0)
                {
                    this.MinPrice = item.Value.TradingPrice;
                }
                else if (index == gridItemList.Count - 1)
                {
                    this.MaxPrice = item.Value.TradingPrice;
                }

            }
        }
    }
}
