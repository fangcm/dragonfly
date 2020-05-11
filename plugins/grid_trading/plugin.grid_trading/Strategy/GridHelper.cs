using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragonfly.Plugin.GridTrading.Strategy
{
    internal class GridHelper
    {
        internal static List<GridNode> BuildGridNodes(string strategy, decimal initPrice, int initHoldingVolume,
            decimal minPrice, decimal maxPrice)
        {
            List<GridNode> gridNodes = new List<GridNode>();

            gridNodes.Add(new GridNode()
            {
                TradingPrice = initPrice,
                HoldingVolume = initHoldingVolume,
            });

            decimal pricePercent = (decimal)0.02;
            decimal volumePercent = (decimal)0.20;
            decimal priceUp = initPrice, priceDown = initPrice;
            int holdingVolumeUp = initHoldingVolume, holdingVolumeDown = initHoldingVolume;
            while (true)
            {
                priceUp = priceUp * (1 + pricePercent);
                priceDown = priceDown * (1 - pricePercent);
                holdingVolumeUp = (int)(holdingVolumeUp * (1 - volumePercent));
                holdingVolumeDown = (int)(holdingVolumeDown * (1 + volumePercent));

                gridNodes.Add(new GridNode()
                {
                    TradingPrice = priceUp,
                    HoldingVolume = holdingVolumeUp,
                });
                gridNodes.Add(new GridNode()
                {
                    TradingPrice = priceDown,
                    HoldingVolume = holdingVolumeDown,
                });

                if (priceUp > maxPrice || priceDown < minPrice)
                {
                    break;
                }
            }
            return gridNodes;
        }
    }
}
