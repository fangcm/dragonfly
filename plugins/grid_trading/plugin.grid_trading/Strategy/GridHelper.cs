using System.Collections.Generic;

namespace Dragonfly.Plugin.GridTrading.Strategy
{
    internal class GridHelper
    {
        internal static List<GridNode> BuildGridNodes(decimal priceStrategy, int volumeStrategy, decimal initPrice, int initHoldingVolume,
            decimal minPrice, decimal maxPrice, int priceDecimalPlace)
        {
            List<GridNode> gridNodes = new List<GridNode>();

            gridNodes.Add(new GridNode()
            {
                TradingPrice = decimal.Round(initPrice, priceDecimalPlace),
                HoldingVolume = initHoldingVolume,
            });

            decimal pricePercent = priceStrategy / 100;
            decimal priceUp = initPrice, priceDown = initPrice;
            int holdingVolumeUp = initHoldingVolume, holdingVolumeDown = initHoldingVolume;
            while (true)
            {
                priceUp = decimal.Round(priceUp * (1 + pricePercent), priceDecimalPlace);
                if (maxPrice > (decimal)0.001 && priceUp <= maxPrice && holdingVolumeUp > 0)
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

                priceDown = decimal.Round(priceDown * (1 - pricePercent), priceDecimalPlace);
                if (minPrice > (decimal)0.001 && priceDown >= minPrice)
                {
                    holdingVolumeDown += volumeStrategy;
                    gridNodes.Add(new GridNode()
                    {
                        TradingPrice = priceDown,
                        HoldingVolume = holdingVolumeDown,
                    });
                }

                if (priceUp > maxPrice && priceDown < minPrice)
                {
                    break;
                }
            }
            return gridNodes;
        }
    }
}
