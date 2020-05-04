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

            var item = new ModelAccountStat();
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
                        item.remainingMoney = decimal.Parse(value);
                        break;
                    case "可用":
                        item.availableMoney = decimal.Parse(value);
                        break;
                    case "可取":
                        item.transferableMoney = decimal.Parse(value);
                        break;
                    case "参考市值":
                        item.marketValue = decimal.Parse(value);
                        break;
                    case "资产":
                        item.totalAssets = decimal.Parse(value);
                        break;
                    case "盈亏":
                        item.profit = decimal.Parse(value);
                        break;
                }

            }

            return item;
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

                ModelHoldingStock item = new ModelHoldingStock();
                for (int col = 0; col < header.Length; col++)
                {
                    string key = header[col];
                    string value = rawHoldingStock[col];
                    switch (key)
                    {
                        case "证券代码":
                            item.code = value;
                            break;
                        case "证券名称":
                            item.name = value;
                            break;
                        case "证券数量":
                            item.holdingNum = (int)decimal.Parse(value);
                            break;
                        case "可卖数量":
                            item.availableNum = (int)decimal.Parse(value);
                            break;
                        case "成本价":
                            item.costPrice = decimal.Parse(value);
                            break;
                        case "当前价":
                            item.currPrice = decimal.Parse(value);
                            break;
                        case "最新市值":
                            item.marketValue = decimal.Parse(value);
                            break;
                        case "浮动盈亏":
                            item.profit = decimal.Parse(value);
                            break;
                        case "盈亏比例(%)":
                            item.profitPercent = decimal.Parse(value);
                            break;
                    }
                }

                holdStockList.Add(item);
            }

            return new Tuple<ModelAccountStat, List<ModelHoldingStock>>(stat, holdStockList);
        }
    }

    internal class ModelTodayDeals
    {
        internal string dealTime = string.Empty; // 成交时间
        internal string code = string.Empty; // 证券代码                                      
        internal string name = string.Empty; // 证券名称
        internal string flag = string.Empty; // 买卖标志
        internal decimal price = 0; // 成交价格
        internal int num = 0; // 成交数量
        internal decimal amount = 0; // 成交金额
        internal string type = string.Empty; // 成交类型

        internal static List<ModelTodayDeals> Parse(List<string[]> param)
        {
            if (param == null || param.Count <= 1)
                return null;
            List<ModelTodayDeals> todayDealsList = new List<ModelTodayDeals>();

            string[] header = param[0];
            for (int row = 1; row < param.Count; row++)
            {
                string[] rawTodayDeals = param[row];
                if (rawTodayDeals.Length != header.Length)
                    continue;

                ModelTodayDeals item = new ModelTodayDeals();
                for (int col = 0; col < header.Length; col++)
                {
                    string key = header[col];
                    string value = rawTodayDeals[col];
                    switch (key)
                    {
                        case "成交时间":
                            item.dealTime = value;
                            break;
                        case "证券代码":
                            item.code = value;
                            break;
                        case "证券名称":
                            item.name = value;
                            break;
                        case "买卖标志":
                            item.flag = value;
                            break;
                        case "成交价格":
                            item.price = decimal.Parse(value);
                            break;
                        case "成交数量":
                            item.num = (int)decimal.Parse(value);
                            break;
                        case "成交金额":
                            item.amount = decimal.Parse(value);
                            break;
                        case "成交类型":
                            item.type = value;
                            break;
                    }
                }

                todayDealsList.Add(item);
            }

            return todayDealsList;
        }
    }
}