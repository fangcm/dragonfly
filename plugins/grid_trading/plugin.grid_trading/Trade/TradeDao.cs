using System;
using System.Collections.Generic;
using Dragonfly.Plugin.GridTrading.Strategy;
using Dragonfly.Plugin.GridTrading.Trade.GuoHai;
using System.Data.SQLite;
using System.Data;
using Dragonfly.Plugin.GridTrading.Utils;

namespace Dragonfly.Plugin.GridTrading.Trade
{
    internal class TradeDao
    {

        internal static void SaveOrUpdateTodayDeals(StockMarket market, List<ModelTodayDeals> todayDeals)
        {
            if(todayDeals==null || todayDeals.Count==0)
            {
                return;
            }

            List<SQLiteParameter> paramList = new List<SQLiteParameter>();

            string sql = @"select id,direction,stock_code,trade_price,trade_volume,trade_status,order_no,trade_no
                from trade_record
                where direction = @direction
                and trade_date = @trade_date 
                and stockMarket = @stockMarket ";

            paramList.Add(new SQLiteParameter("disable_flag") { Value = 0 });
            paramList.Add(new SQLiteParameter("stock_market") { Value = (int)market });

            Dictionary<Grid> grids = new List<Grid>();
            DataTable dt = SqliteHelper.ExecuteDataTable(sql, paramList.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                GridType gridType = (GridType)Convert.ToInt32(row["grid_type"]);
                switch (gridType)
                {
                    case GridType.ManualGrid:
                        ManualGrid g = Grid.FromJson<ManualGrid>(Convert.ToString(row["strategy_json"]));
                        grids.Add(g);
                        break;
                }

            }

            foreach (ModelTodayDeals td in todayDeals)
            {

            }
        }

        internal static TradingRecord FindLastTradingRecord(StockMarket stockMarket, string stockCode)
        {
            throw new NotImplementedException();
        }
    }

    internal class TradingRecord : ModelTodayDeals
    {
        internal int id = 0; // db主键
        internal int stockMarket = 0; // 市场
        internal string createTime = string.Empty; // 创建时间 yyyy-mm-dd hh:mm:ss
    }
}