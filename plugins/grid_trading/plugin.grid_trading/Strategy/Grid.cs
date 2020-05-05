using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Dragonfly.Plugin.GridTrading.Strategy
{
    internal enum Direction : int
    {
        buy = 1,
        sell = 2,
    }

    internal enum StockMarket : int
    {
        A = 1,
        Hgt = 2,
        Sgt = 3,
    }

    internal abstract class Grid
    {
        [JsonIgnore]
        internal GridOrder LastTradingOrder { get; set; }

        [JsonProperty(Required = Required.Always)]
        internal StockMarket StockMarket { get; set; }

        [JsonProperty(Required = Required.Always)]
        internal string StockCode { get; set; }

        [JsonProperty(Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        internal string StockName { get; set; }

        [JsonProperty(Required = Required.Always)]
        internal decimal InitPrice { get; set; } //初始价格

        [JsonProperty(Required = Required.Always)]
        internal int InitHoldingVolume { get; set; } //初始持有股数

        [JsonProperty(Required = Required.AllowNull)]
        internal decimal MaxPrice { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        internal decimal MinPrice { get; set; }

        // 根据价格排序的网格
        [JsonIgnore]
        internal SortedList<decimal, GridNode> gridNodeList = new SortedList<decimal, GridNode>();

        [JsonProperty(Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        internal IList<GridNode> GridNodes
        {
            get
            {
                return gridNodeList.Values;
            }
            set
            {
                gridNodeList.Clear();
                foreach (GridNode node in value)
                {
                    gridNodeList.Add(node.TradingPrice, node);
                }
            }
        }


        internal string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }


        // 根据持仓量，获取下一网格交易项
        internal virtual GridNode ExpectedGridItem(int holdingVolume)
        {
            if (gridNodeList.Count == 0)
            {
                return null;
            }
            else if (gridNodeList.Count == 1)
            {
                return gridNodeList[0];
            }

            GridNode expectedItem = null;
            decimal minDist = holdingVolume;
            foreach (GridNode gridItem in gridNodeList.Values)
            {
                decimal dist = Math.Abs(gridItem.HoldingVolume - holdingVolume);
                if (dist < minDist)
                {
                    expectedItem = gridItem;
                    minDist = dist;
                }
            }

            return expectedItem;
        }

    }

    internal class GridNode
    {
        //交易价格档位
        internal decimal TradingPrice { get; set; }

        //持仓股数
        internal int HoldingVolume { get; set; }

        //买单
        internal GridOrder BuyOrder { get; set; }

        //卖单
        internal GridOrder SellOrder { get; set; }
    }


    internal class GridOrder
    {
        internal Direction Direction { get; set; }
        //交易价
        internal decimal Price { get; set; }

        //数量
        internal int Volume { get; set; }

    }
}
