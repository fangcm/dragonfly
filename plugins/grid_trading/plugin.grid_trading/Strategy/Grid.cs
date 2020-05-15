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
        internal List<GridNode> GridNodes { get; set; }


        internal string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        internal static Grid FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Grid>(jsonData);
        }

        internal string GetStockMarketDesc()
        {
            string desc = "";
            switch (StockMarket)
            {
                case StockMarket.A:
                    desc = "A股";
                    break;
                case StockMarket.Hgt:
                    desc = "沪港通";
                    break;
                case StockMarket.Sgt:
                    desc = "深港通";
                    break;
            }
            return desc;

        }

        internal void SetStockMarketByDesc(string desc)
        {
            switch (desc)
            {
                case "A股":
                    StockMarket = StockMarket.A;
                    break;
                case "沪港通":
                    StockMarket = StockMarket.Hgt;
                    break;
                case "深港通":
                    StockMarket = StockMarket.Sgt;
                    break;
                default:
                    StockMarket = StockMarket.A;
                    break;
            }

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

        internal void ReBuildGridNodes(decimal priceStrategy, int volumeStrategy, decimal initPrice, int initHoldingVolume,
                decimal minPrice, decimal maxPrice, int priceDecimalPlace)
        {
            List<GridNode> gridNodes = new List<GridNode>();

            gridNodes.Add(new GridNode()
            {
                TradingPrice = decimal.Round(initPrice, priceDecimalPlace),
                HoldingVolume = initHoldingVolume,
            });

            int maxLoop = 30;
            decimal pricePercent = priceStrategy / 100;
            decimal priceUp = initPrice, priceDown = initPrice;
            int holdingVolumeUp = initHoldingVolume, holdingVolumeDown = initHoldingVolume;
            while (true)
            {
                maxLoop--;
                if (maxLoop <= 0)
                {
                    //最多网格N个
                    break;
                }

                if (maxPrice > (decimal)0.001 && priceUp < maxPrice && holdingVolumeUp > 0)
                {
                    priceUp = decimal.Round(priceUp * (1 + pricePercent), priceDecimalPlace);
                    if (priceUp <= maxPrice)
                    {
                        holdingVolumeUp -= volumeStrategy;
                        if (holdingVolumeUp < 0)
                        {
                            holdingVolumeUp = 0;
                        }
                        gridNodes.Add(new GridNode()
                        {
                            TradingPrice = priceUp,
                            HoldingVolume = holdingVolumeUp,
                        });
                    }
                }

                if (minPrice > (decimal)0.001 && priceDown > minPrice)
                {
                    priceDown = decimal.Round(priceDown * (1 - pricePercent), priceDecimalPlace);
                    if (priceDown >= minPrice)
                    {
                        holdingVolumeDown += volumeStrategy;
                        gridNodes.Add(new GridNode()
                        {
                            TradingPrice = priceDown,
                            HoldingVolume = holdingVolumeDown,
                        });
                    }
                }

                if (priceUp > maxPrice && priceDown < minPrice)
                {
                    break;
                }
            }
            GridNodes = gridNodes;
            ResetOrders();
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
