using System.Linq;

namespace Dragonfly.Plugin.GridTrading.Strategy
{
    internal class ManualGrid : Grid
    {
        internal static ManualGrid FromJson(string jsonData)
        {
            ManualGrid grid = Newtonsoft.Json.JsonConvert.DeserializeObject<ManualGrid>(jsonData);

            grid.gridNodeList.Add(10,new GridNode() { TradingPrice = 10, HoldingVolume = 100, });

            grid.buildTradingGrid();
            return grid;
        }

        internal void buildTradingGrid()
        {
            foreach (var item in gridNodeList)
            {
                int index = gridNodeList.IndexOfKey(item.Key);

                GridOrder buyOrder = null;
                GridOrder sellOrder = null;
                if (index > 0)
                {
                    var temp = gridNodeList.ElementAt(index - 1);
                    buyOrder = new GridOrder()
                    {
                        Price = temp.Value.TradingPrice,
                        Volume = temp.Value.HoldingVolume - item.Value.HoldingVolume,
                    };
                }

                if (index < gridNodeList.Count - 1)
                {
                    var temp = gridNodeList.ElementAt(index + 1);
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
                    MinPrice = item.Value.TradingPrice;
                }
                else if (index == gridNodeList.Count - 1)
                {
                    MaxPrice = item.Value.TradingPrice;
                }

            }
        }
    }
}
