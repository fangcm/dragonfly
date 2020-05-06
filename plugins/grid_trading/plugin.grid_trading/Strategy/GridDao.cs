using Dragonfly.Plugin.GridTrading.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragonfly.Plugin.GridTrading.Strategy
{
    internal enum GridType : int
    {
        ManualGrid = 1,
        EqualRatioGrid = 2,
    }

    internal static class GridDao
    {
        public static List<Grid> GetAllGrids(bool onlyEnabled = true)
        {
            List<SQLiteParameter> paramList = new List<SQLiteParameter>();

            string sql = @"
                select id,stock_market,stock_code,stock_name,init_price,init_holding_volume,
                  max_price,min_price,strategy_json,disable_flag,delete_flag
                from grid_strategy
                where delete_flag = 0 ";

            if (onlyEnabled)
            {
                sql += "and disable_flag=@disable_flag ";
                paramList.Add(new SQLiteParameter("disable_flag") { Value = 0 });
            }
            sql += "order by id ";


            DataTable dt = SqliteHelper.ExecuteDataTable(sql, paramList.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(row.ToString());
            }
            return null;
        }
    }
}
