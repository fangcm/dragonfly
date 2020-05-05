using System;
using System.Collections.Generic;

// 术语：
// trading 成交、交易
// ContractNo tradingNo ActualAmount
// turnover 成交额
// trading volume 成交量
// Market Price 市场价格  
// TransactionId  Volume  
// Direction : Order side (buy or sell)
// balance: Order contracts balance
// Commission  佣金
// PnL : The profit, realized by trade

namespace Dragonfly.Plugin.GridTrading.Trade
{
    internal class ModelAccountStat
    {
        internal decimal remainingAmount = 0; // 余额
        internal decimal availableAmount = 0; // 可用
        internal decimal transferableAmount = 0; // 可取
        internal decimal marketValue = 0; // 参考市值
        internal decimal totalAssets = 0; // 资产
        internal decimal pnl = 0; // 盈亏

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
                        item.remainingAmount = decimal.Parse(value);
                        break;
                    case "可用":
                        item.availableAmount = decimal.Parse(value);
                        break;
                    case "可取":
                        item.transferableAmount = decimal.Parse(value);
                        break;
                    case "参考市值":
                        item.marketValue = decimal.Parse(value);
                        break;
                    case "资产":
                        item.totalAssets = decimal.Parse(value);
                        break;
                    case "盈亏":
                        item.pnl = decimal.Parse(value);
                        break;
                }

            }

            return item;
        }
    }

    internal class ModelHoldingStock
    {
        internal string stockCode = string.Empty; // 证券代码
        internal string stockName = string.Empty; // 证券名称
        internal int holdingVolume = 0; // 证券数量
        internal int availableVolume = 0; // 可卖数量
        internal decimal costPrice = 0; // 成本价
        internal decimal currPrice = 0; // 当前价
        internal decimal marketValue = 0; // 最新市值
        internal decimal pnl = 0; // 浮动盈亏
        internal decimal pnlPercent = 0; // 盈亏比例(%)

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
                            item.stockCode = value;
                            break;
                        case "证券名称":
                            item.stockName = value;
                            break;
                        case "证券数量":
                            item.holdingVolume = (int)decimal.Parse(value);
                            break;
                        case "可卖数量":
                            item.availableVolume = (int)decimal.Parse(value);
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
                            item.pnl = decimal.Parse(value);
                            break;
                        case "盈亏比例(%)":
                            item.pnlPercent = decimal.Parse(value);
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
        internal string tradingTime = string.Empty; // 成交时间
        internal string stockCode = string.Empty; // 证券代码                                      
        internal string stockName = string.Empty; // 证券名称
        internal string direction = string.Empty; // 买卖标志(buy or sell)
        internal decimal price = 0; // 成交价格
        internal int volume = 0; // 成交数量
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
                            item.tradingTime = value;
                            break;
                        case "证券代码":
                            item.stockCode = value;
                            break;
                        case "证券名称":
                            item.stockName = value;
                            break;
                        case "买卖标志":
                            item.direction = value;
                            break;
                        case "成交价格":
                            item.price = decimal.Parse(value);
                            break;
                        case "成交数量":
                            item.volume = (int)decimal.Parse(value);
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


    // 可撤订单（撤单页面）
    internal class ModelRevocableOrder
    {
        internal string tradingTime = string.Empty; // 成交时间
        internal string stockCode = string.Empty; // 证券代码                                      
        internal string stockName = string.Empty; // 证券名称
        internal string direction = string.Empty; // 买卖标志(buy or sell)
        internal decimal price = 0; // 成交价格
        internal int volume = 0; // 成交数量
        internal decimal amount = 0; // 成交金额
        internal string type = string.Empty; // 成交类型

        internal static List<ModelRevocableOrder> Parse(List<string[]> param)
        {
            if (param == null || param.Count <= 1)
                return null;
            List<ModelRevocableOrder> revocableOrderList = new List<ModelRevocableOrder>();

            string[] header = param[0];
            for (int row = 1; row < param.Count; row++)
            {
                string[] rawRevocableOrder = param[row];
                if (rawRevocableOrder.Length != header.Length)
                    continue;

                ModelRevocableOrder item = new ModelRevocableOrder();
                for (int col = 0; col < header.Length; col++)
                {
                    string key = header[col];
                    string value = rawRevocableOrder[col];
                    switch (key)
                    {
                        case "成交时间":
                            item.tradingTime = value;
                            break;
                        case "证券代码":
                            item.stockCode = value;
                            break;
                        case "证券名称":
                            item.stockName = value;
                            break;
                        case "买卖标志":
                            item.direction = value;
                            break;
                        case "成交价格":
                            item.price = decimal.Parse(value);
                            break;
                        case "成交数量":
                            item.volume = (int)decimal.Parse(value);
                            break;
                        case "成交金额":
                            item.amount = decimal.Parse(value);
                            break;
                        case "成交类型":
                            item.type = value;
                            break;
                    }
                }

                revocableOrderList.Add(item);
            }

            return revocableOrderList;
        }
    }
}