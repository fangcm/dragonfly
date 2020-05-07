using Dragonfly.Plugin.GridTrading.Strategy;
using System;
using System.Collections.Generic;


namespace Dragonfly.Plugin.GridTrading.Trade
{

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

        internal static List<ModelHoldingStock> Parse(List<string[]> param)
        {
            if (param == null || param.Count == 0)
                return null;
            List<ModelHoldingStock> holdStockList = new List<ModelHoldingStock>();
            
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

            return holdStockList;
        }
    }

    internal class ModelTodayDeals
    {
        internal int tradeDate = 0; // 成交日期
        internal string tradingTime = string.Empty; // 成交时间 hh:mm:ss
        internal string direction = string.Empty; // 买卖标志(buy or sell)
        internal string stockCode = string.Empty; // 证券代码                                      
        internal string stockName = string.Empty; // 证券名称
        internal decimal tradePrice = 0; // 成交价格 or 成交价格(港币)
        internal int tradeVolume = 0; // 成交数量
        internal decimal tradeAmount = 0; // 成交金额 or 成交金额(港币) 
        internal string tradeStatus = string.Empty; // 成交状态 (A没有) (成交\废单)
        internal string orderNo = string.Empty; // 委托编号
        internal string tradeNo = string.Empty; // 成交编号
        internal string accountNo = string.Empty; // 股东代码
        internal string tradeClassify = string.Empty; // 成交类型 （买卖）

        internal Direction ConvertDirectionToInt()
        {
            Direction d = 0;
            switch (direction)
            {
                case "买入":
                    d = Direction.buy;
                    break;
                case "卖出":
                    d = Direction.sell;
                    break;
            }
            return d;

        }

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
                        case "成交日期":
                            item.tradeDate = int.Parse(value);
                            break;
                        case "成交时间":
                            item.tradingTime = value;
                            break;
                        case "买卖标志":
                            item.direction = value;
                            break;
                        case "证券代码":
                            item.stockCode = value;
                            break;
                        case "证券名称":
                            item.stockName = value;
                            break;
                        case "成交价格":
                        case "成交价格(港币)":
                            item.tradePrice = decimal.Parse(value);
                            break;
                        case "成交数量":
                            item.tradeVolume = (int)decimal.Parse(value);
                            break;
                        case "成交金额":
                        case "成交金额(港币)":
                            item.tradeAmount = decimal.Parse(value);
                            break;
                        case "成交状态":
                            item.tradeStatus = value;
                            break;
                        case "委托编号":
                            item.orderNo = value;
                            break;
                        case "成交编号":
                            item.tradeNo = value;
                            break;
                        case "股东代码":
                            item.accountNo = value;
                            break;
                        case "成交类型":
                            item.tradeClassify = value;
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
        internal int tradeDate = 0; // 成交日期
        internal string tradingTime = string.Empty; // 成交时间 hh:mm:ss
        internal string stockCode = string.Empty; // 证券代码                                      
        internal string stockName = string.Empty; // 证券名称
        internal string direction = string.Empty; // 买卖标志(buy or sell)
        internal string orderType = string.Empty; // 委托类别 （委托）
        internal string orderStatus = string.Empty; // 状态说明 （已报）
        internal decimal orderPrice = 0; // 委托价格
        internal int orderVolume = 0; // 委托数量
        internal string orderNo = string.Empty; // 委托编号
        internal decimal tradePrice = 0; // 成交价格 or 成交价格(港币)
        internal int tradeVolume = 0; // 成交数量
        internal string orderClassify = string.Empty; // 委托属性 （买卖）
        internal string accountNo = string.Empty; // 股东代码

        internal Direction ConvertDirectionToInt()
        {
            Direction d = 0;
            switch (direction)
            {
                case "买入":
                    d = Direction.buy;
                    break;
                case "卖出":
                    d = Direction.sell;
                    break;
            }
            return d;

        }

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
                        case "成交日期":
                            item.tradeDate = int.Parse(value);
                            break;
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
                        case "委托类别":
                            item.orderType = value;
                            break;
                        case "状态说明":
                            item.orderStatus = value;
                            break;
                        case "委托价格":
                            item.orderPrice = decimal.Parse(value);
                            break;
                        case "委托数量":
                            item.orderVolume = (int)decimal.Parse(value);
                            break;
                        case "委托编号":
                            item.orderNo = value;
                            break;
                        case "成交价格":
                            item.tradePrice = decimal.Parse(value);
                            break;
                        case "成交数量":
                            item.tradeVolume = (int)decimal.Parse(value);
                            break;
                        case "委托属性":
                            item.orderClassify = value;
                            break;
                        case "股东代码":
                            item.accountNo = value;
                            break;
                    }
                }

                revocableOrderList.Add(item);
            }

            return revocableOrderList;
        }
    }
}