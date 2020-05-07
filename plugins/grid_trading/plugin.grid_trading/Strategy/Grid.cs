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

        [JsonProperty(Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        internal decimal MaxPrice { get; set; }

        [JsonProperty(Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        internal decimal MinPrice { get; set; }

        [JsonProperty(Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        internal List<GridNode> GridNodes { get; set; }


        internal string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        internal static T FromJson<T>(string jsonData) where T : Grid
        {
            T grid = JsonConvert.DeserializeObject<T>(jsonData);
            grid.Init();

            return (T)Convert.ChangeType(grid, typeof(T));
        }

        protected virtual void Init()
        {
            if (GridNodes == null || GridNodes.Count == 0)
            {
                return;
            }
            GridNodes.Sort((x, y) => x.TradingPrice.CompareTo(y.TradingPrice));
        }

        // 根据持仓量，获取下一网格交易项
        internal virtual GridNode ExpectedGridNodeByHoldingVolume(int holdingVolume)
        {
            if (GridNodes == null || GridNodes.Count == 0)
            {
                return null;
            }
            else if (GridNodes.Count == 1)
            {
                return GridNodes[0];
            }

            GridNode expectedNode = null;
            decimal minDist = holdingVolume;
            foreach (GridNode node in GridNodes)
            {
                decimal dist = Math.Abs(node.HoldingVolume - holdingVolume);
                if (dist < minDist)
                {
                    expectedNode = node;
                    minDist = dist;
                }
            }

            return expectedNode;
        }

        internal GridNode ExpectedGridNodeByPrice(decimal price)
        {
            if (GridNodes == null || GridNodes.Count == 0)
            {
                return null;
            }
            else if (GridNodes.Count == 1)
            {
                return GridNodes[0];
            }

            GridNode expectedNode = null;
            decimal minDist = price;
            foreach (GridNode node in GridNodes)
            {
                decimal dist = Math.Abs(node.TradingPrice - price);
                if (dist < minDist)
                {
                    expectedNode = node;
                    minDist = dist;
                }
            }

            return expectedNode;
        }
    }

    internal class GridNode
    {
        //交易价格档位
        [JsonProperty(Required = Required.Always)]
        internal decimal TradingPrice { get; set; }

        //持仓股数
        [JsonProperty(Required = Required.Always)]
        internal int HoldingVolume { get; set; }

        //买单
        [JsonIgnore]
        internal GridOrder BuyOrder { get; set; }

        //卖单
        [JsonIgnore]
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
