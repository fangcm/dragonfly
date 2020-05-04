using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragonfly.Plugin.GridTrading.Trade
{
    internal class ModelAccountStat
    {
        internal decimal remainingMoney = 0; // 余额
        internal decimal availableMoney = 0; // 可用
        internal decimal transferableMoney = 0; // 可取
        internal decimal marketValue = 0; // 参考市值
        internal decimal totalAssets = 0; // 资产
        internal decimal profit = 0; // 盈亏

        internal static ModelAccountStat Parse(string[] param)
        {
            if (param == null || param.Length == 0)
                return null;

            var stat = new ModelAccountStat();
            for (int i = 0; i < param.Length; i++)
            {
                string[] raw = param[i].Split(':');
                if (raw.Length != 2)
                    continue;
                string key = raw[0];
                string value = raw[1];
                switch (key)
                {
                    case "余额":
                        stat.remainingMoney = decimal.Parse(value);
                        break;
                    case "可用":
                        stat.availableMoney = decimal.Parse(value);
                        break;
                    case "可取":
                        stat.transferableMoney = decimal.Parse(value);
                        break;
                    case "参考市值":
                        stat.marketValue = decimal.Parse(value);
                        break;
                    case "资产":
                        stat.totalAssets = decimal.Parse(value);
                        break;
                    case "盈亏":
                        stat.profit = decimal.Parse(value);
                        break;
                }

            }

            return stat;
        }
    }

    internal class ModelHoldingStock
    {
        internal string code = string.Empty; // 证券代码
        internal string name = string.Empty; // 证券名称
        internal int holdingNum = 0; // 证券数量
        internal int availableNum = 0; // 可卖数量
        internal decimal costPrice = 0; // 成本价
        internal decimal currPrice = 0; // 当前价
        internal decimal marketValue = 0; // 最新市值
        internal decimal profit = 0; // 浮动盈亏
        internal decimal profitPercent = 0; // 盈亏比例(%)

        internal static Tuple<ModelAccountStat, List<ModelHoldingStock>> Parse(List<string[]> param)
        {
            if (param == null || param.Count == 0)
                return null;
            List<ModelHoldingStock> holdStockList = new List<ModelHoldingStock>();

            var stat = ModelAccountStat.Parse(param[0]);
            if (param == null || param.Count <= 2)
            {
                return new Tuple<ModelAccountStat, List<ModelHoldingStock>>(stat, holdStockList);
            }

            string[] header = param[1];
            for (int row = 2; row < param.Count; row++)
            {
                string[] rawHoldingStock = param[row];
                if (rawHoldingStock.Length != header.Length)
                    continue;

                ModelHoldingStock holdingStock = new ModelHoldingStock();
                for (int col = 0; col < header.Length; col++)
                {
                    string key = header[col];
                    string value = rawHoldingStock[col];
                    switch (key)
                    {
                        case "证券代码":
                            holdingStock.code = value;
                            break;
                        case "证券名称":
                            holdingStock.name = value;
                            break;
                        case "证券数量":
                            holdingStock.holdingNum = (int)decimal.Parse(value);
                            break;
                        case "可卖数量":
                            holdingStock.availableNum = (int)decimal.Parse(value);
                            break;
                        case "成本价":
                            holdingStock.costPrice = decimal.Parse(value);
                            break;
                        case "当前价":
                            holdingStock.currPrice = decimal.Parse(value);
                            break;
                        case "最新市值":
                            holdingStock.marketValue = decimal.Parse(value);
                            break;
                        case "浮动盈亏":
                            holdingStock.profit = decimal.Parse(value);
                            break;
                        case "盈亏比例(%)":
                            holdingStock.profitPercent = decimal.Parse(value);
                            break;
                    }
                }

                holdStockList.Add(holdingStock);
            }

            return new Tuple<ModelAccountStat, List<ModelHoldingStock>>(stat, holdStockList);
        }
    }
}
