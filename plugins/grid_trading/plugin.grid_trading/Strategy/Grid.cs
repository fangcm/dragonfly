using System;
using System.Collections.Generic;

namespace Dragonfly.Plugin.GridTrading.Strategy
{
    internal class Grid
    {
        internal Dictionary<string, object> config = null;

        internal List<GridItem> gridItemList = new List<GridItem>();
        internal int GridCount { get { return gridItemList.Count; } }

        internal decimal InitPrice { get; set; } //初始价格
        internal int InitVolume { get; set; } //初始股数
        internal decimal MaxPrice { get; set; }
        internal decimal MinPrice { get; set; }

        internal virtual void Init(Dictionary<string, object> config)
        {
            this.config = config;

            object temp;

            if (config.TryGetValue("InitPrice", out temp))
            {
                InitPrice = (decimal)temp;
            }

            if (config.TryGetValue("InitVolume", out temp))
            {
                InitVolume = (int)temp;
            }

            if (config.TryGetValue("MaxPrice", out temp))
            {
                MaxPrice = (decimal)temp;
            }

            if (config.TryGetValue("MinPrice", out temp))
            {
                MinPrice = (decimal)temp;
            }
        }


        // 根据成交价格、方向，获取下一网格交易项
        internal GridItem ExpectedGridItem(decimal tradingPrice)
        {
            List<GridItem> expectedItemList = new List<GridItem>();
            foreach (GridItem gridItem in gridItemList)
            {
                if (tradingPrice < gridItem.BuyOrder.Price && tradingPrice < gridItem.SellOrder.Price)
                {
                    expectedItemList.Add(gridItem);
                }
            }

            if (expectedItemList.Count == 0)
            {
                return null;
            }
            else if (expectedItemList.Count == 1)
            {
                return expectedItemList[0];
            }

            GridItem expectedItem = null;
            decimal maxDist = 0;
            foreach (GridItem gridItem in expectedItemList)
            {
                decimal dist = Math.Min(
                    Math.Abs(gridItem.BuyOrder.Price - tradingPrice),
                    Math.Abs(gridItem.SellOrder.Price - tradingPrice)
                    );
                if (dist > maxDist)
                {
                    expectedItem = gridItem;
                    maxDist = dist;
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
