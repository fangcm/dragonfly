using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragonfly.Plugin.GridTrading.Strategy
{
    internal class ManualGrid : Grid
    {
        internal List<Tuple< decimal,int>> prices = new List<Tuple<decimal, int>>();

        internal override void Init(Dictionary<string, object> config)
        {
            base.Init(config);

            object temp;

            if (config.TryGetValue("Price", out temp))
            {
                InitPrice = (decimal)temp;
            }
        }
    }
}
