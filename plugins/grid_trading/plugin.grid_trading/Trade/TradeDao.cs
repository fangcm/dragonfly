using System;
using System.Collections.Generic;
using Dragonfly.Plugin.GridTrading.Strategy;
using System.Data.SQLite;
using System.Data;
using Dragonfly.Plugin.GridTrading.Utils;

namespace Dragonfly.Plugin.GridTrading.Trade
{
    internal class TradeDao
    {

        internal static void SaveOrUpdateTodayDeals(StockMarket market, List<ModelTodayDeals> todayDealsList)
        {
            if (todayDealsList == null || todayDealsList.Count == 0)
            {
                return;
            }

            List<SQLiteParameter> paramList = new List<SQLiteParameter>();

            string sql = @"select id,trade_time,direction,stock_code,trade_price,trade_volume,trade_status,order_no,trade_no
                from trade_record
                where trade_date = @trade_date and stock_market = @stock_market ";

            int tradeDate = int.Parse(DateTime.Now.ToString("yyyyMMdd"));

            paramList.Add(new SQLiteParameter("trade_date") { Value = tradeDate });
            paramList.Add(new SQLiteParameter("stock_market") { Value = (int)market });

            Dictionary<string, ModelTodayDeals> existTodayDeals = new Dictionary<string, ModelTodayDeals>();
            DataTable dt = SqliteHelper.ExecuteDataTable(sql, paramList.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                ModelTodayDeals td = new ModelTodayDeals()
                {
                    tradeTime = Convert.ToString(row["trade_time"]),
                    direction = Convert.ToString(row["direction"]),
                    stockCode = Convert.ToString(row["stock_code"]),
                    tradePrice = Convert.ToDecimal(row["trade_price"]),
                    tradeVolume = Convert.ToInt32(row["trade_volume"]),
                    tradeStatus = Convert.ToString(row["trade_status"]),
                    orderNo = Convert.ToString(row["order_no"]),
                    tradeNo = Convert.ToString(row["trade_no"]),
                };
                existTodayDeals[td.tradeNo] = td;
            }

            foreach (ModelTodayDeals td in todayDealsList)
            {
                ModelTodayDeals existItem;
                if (existTodayDeals.TryGetValue(td.tradeNo, out existItem))
                {
                    if ((td.tradeTime == existItem.tradeTime) &&
                        (td.direction == existItem.direction) &&
                        (td.stockCode == existItem.stockCode) &&
                        (td.tradePrice == existItem.tradePrice) &&
                        (td.tradeVolume == existItem.tradeVolume) &&
                        (td.tradeStatus == existItem.tradeStatus) &&
                        (td.orderNo == existItem.orderNo))
                    {
                        continue;
                    }
                }

                InsertTradingRecord(market, td);

            }
        }

        private static void InsertTradingRecord(StockMarket market, ModelTodayDeals td)
        {
            string sql = @"INSERT INTO trade_record(stock_market, trade_date, trade_time, direction, 
                  stock_code, stock_name, trade_price, trade_volume, trade_amount, trade_status, order_no, trade_no, 
                  account_no, trade_classify, create_time) 
                VALUES ( @stock_market, @trade_date, @trade_time, @direction,
                  @stock_code,@stock_name,@trade_price,@trade_volume,@trade_amount,@trade_status,@order_no,@trade_no,
                  @account_no,@trade_classify,@create_time)";

            int tradeDate = td.tradeDate;
            if (td.tradeDate == 0)
            {
                tradeDate = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            }
            string createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            List<SQLiteParameter> paramList = new List<SQLiteParameter>();
            paramList.Add(new SQLiteParameter("stock_market") { Value = (int)market });
            paramList.Add(new SQLiteParameter("trade_date") { Value = tradeDate });
            paramList.Add(new SQLiteParameter("trade_time") { Value = td.tradeTime });
            paramList.Add(new SQLiteParameter("direction") { Value = td.direction });
            paramList.Add(new SQLiteParameter("stock_code") { Value = td.stockCode });
            paramList.Add(new SQLiteParameter("stock_name") { Value = td.stockName });
            paramList.Add(new SQLiteParameter("trade_price") { Value = td.tradePrice });
            paramList.Add(new SQLiteParameter("trade_volume") { Value = td.tradeVolume });
            paramList.Add(new SQLiteParameter("trade_amount") { Value = td.tradeAmount });
            paramList.Add(new SQLiteParameter("trade_status") { Value = td.tradeStatus });
            paramList.Add(new SQLiteParameter("order_no") { Value = td.orderNo });
            paramList.Add(new SQLiteParameter("trade_no") { Value = td.tradeNo });
            paramList.Add(new SQLiteParameter("account_no") { Value = td.accountNo });
            paramList.Add(new SQLiteParameter("trade_classify") { Value = td.tradeClassify });
            paramList.Add(new SQLiteParameter("create_time") { Value = createTime });

            SqliteHelper.ExecuteNonQuery(sql, paramList.ToArray());
        }

        internal static ModelTodayDeals FindLastTradingPrice(StockMarket stockMarket, string stockCode)
        {
            List<SQLiteParameter> paramList = new List<SQLiteParameter>();

            string sql = @"select trade_date,trade_time,direction,stock_code,trade_price
                from trade_record
                where stock_market= @stock_market and stock_code=@stock_code
                order by trade_date desc,trade_time desc
                limit 1 ";

            paramList.Add(new SQLiteParameter("stock_market") { Value = (int)stockMarket });
            paramList.Add(new SQLiteParameter("stock_code") { Value = stockCode });

            DataTable dt = SqliteHelper.ExecuteDataTable(sql, paramList.ToArray());
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = dt.Rows[0];
            ModelTodayDeals mtd = new ModelTodayDeals()
            {
                tradeDate = Convert.ToInt32(row["trade_date"]),
                tradeTime = Convert.ToString(row["trade_time"]),
                direction = Convert.ToString(row["direction"]),
                stockCode = Convert.ToString(row["stock_code"]),
                tradePrice = Convert.ToDecimal(row["trade_price"]),
            };
            return mtd;
        }
    }


}