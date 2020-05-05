using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Dragonfly.Plugin.GridTrading.Strategy
{
    internal abstract class Grid
    {
        internal Dictionary<string, object> config = null;

        // 根据价格排序
        internal SortedList<decimal, GridItem> gridItemList = new SortedList<decimal, GridItem>();
        internal int GridCount { get { return gridItemList.Count; } }

        internal decimal InitPrice { get; set; } //初始价格
        internal int InitHoldingVolume { get; set; } //初始持有股数
        internal decimal MaxPrice { get; set; }
        internal decimal MinPrice { get; set; }

        internal virtual void Init(Dictionary<string, object> config)
        {
            this.config = config;

            object temp;

            if (config.TryGetValue("InitPrice", out temp))
            {
                InitPrice = decimal.Parse(temp.ToString());
            }

            if (config.TryGetValue("InitHoldingVolume", out temp))
            {
                InitHoldingVolume = int.Parse(temp.ToString());
            }

            if (config.TryGetValue("MaxPrice", out temp))
            {
                MaxPrice = decimal.Parse(temp.ToString());
            }

            if (config.TryGetValue("MinPrice", out temp))
            {
                MinPrice = decimal.Parse(temp.ToString());
            }
        }

        internal virtual void Init(string jsonData)
        {
            Dictionary<string, object> dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
            Init(dict);
        }


        // 根据持仓量，获取下一网格交易项
        internal GridItem ExpectedGridItem(int holdingVolume)
        {
            if (gridItemList.Count == 0)
            {
                return null;
            }
            else if (gridItemList.Count == 1)
            {
                return gridItemList[0];
            }

            GridItem expectedItem = null;
            decimal minDist = holdingVolume;
            foreach (GridItem gridItem in gridItemList.Values)
            {
                decimal dist = Math.Abs(gridItem.HoldingVolume- holdingVolume);
                if (dist < minDist)
                {
                    expectedItem = gridItem;
                    minDist = dist;
                }
            }

            return expectedItem;
        }

    }

    internal class GridItem
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
        //交易价
        internal decimal Price { get; set; }

        //数量
        internal int Volume { get; set; }

    }
}
