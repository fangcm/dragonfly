using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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

    internal class Grid
    {
        [JsonIgnore]
        internal int Id { get; set; }
        [JsonIgnore]
        internal int DisableFlag { get; set; }

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

        internal static Grid FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Grid>(jsonData);
        }

        internal virtual void ResetOrders()
        {
            if (GridNodes == null || GridNodes.Count == 0)
            {
                return;
            }
            GridNodes.Sort((x, y) => x.TradingPrice.CompareTo(y.TradingPrice));

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
            }

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
        [JsonProperty(Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        internal GridOrder BuyOrder { get; set; }

        //卖单
        [JsonProperty(Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        internal GridOrder SellOrder { get; set; }
    }


    internal class GridOrder
    {
        [JsonProperty(Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        internal Direction Direction { get; set; }
        //交易价
        [JsonProperty(Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        internal decimal Price { get; set; }
        //数量
        [JsonProperty(Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        internal int Volume { get; set; }
    }
}
