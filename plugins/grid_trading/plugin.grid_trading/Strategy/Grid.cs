using System;
using System.Collections.Generic;

namespace Dragonfly.Plugin.GridTrading.Strategy
{
    internal class Grid
    {
        private List<GridItem> gridItemList = new List<GridItem>();

        internal int GridCount { get { return gridItemList.Count; } }

        internal decimal InitPrice { get; set; } //初始价格
        internal decimal MaxPrice { get; set; }
        internal decimal MinPrice { get; set; }

        internal virtual void Init(Dictionary<string, object> config)
        {
            object temp;
            if (config.TryGetValue("InitPrice", out temp))
            {
                InitPrice = (decimal)temp;
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
        internal GridItem ExpectedGridItem(decimal dealPrice)
        {
            List<GridItem> expectedList = new List<GridItem>();
            foreach (GridItem gridItem in gridItemList)
            {
                if (dealPrice < gridItem.BuyOrder.Price && dealPrice < gridItem.SellOrder.Price)
                {
                    expectedList.Add(gridItem);
                }
            }

            if (expectedList.Count == 0)
            {
                return null;
            }
            else if (expectedList.Count == 1)
            {
                return expectedList[0];
            }

            GridItem expectedItem = null;
            decimal maxDist = 0;
            foreach (GridItem gridItem in expectedList)
            {
                decimal dist = Math.Min(
                    Math.Abs(gridItem.BuyOrder.Price - dealPrice),
                    Math.Abs(gridItem.SellOrder.Price - dealPrice)
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
        internal decimal TradePrice { get; set; }

        //持仓股数
        internal int HoldingNum { get; set; }

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
        internal int Num { get; set; }

    }
}
