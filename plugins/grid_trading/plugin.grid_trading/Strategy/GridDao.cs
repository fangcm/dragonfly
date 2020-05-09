using Dragonfly.Plugin.GridTrading.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Dragonfly.Plugin.GridTrading.Strategy
{

    internal static class GridDao
    {
        public static List<Grid> GetAllGrids(bool onlyEnabled = true)
        {
            List<SQLiteParameter> paramList = new List<SQLiteParameter>();

            string sql = @"select id,strategy_json,disable_flag
                from grid_strategy
                where delete_flag = 0 ";

            if (onlyEnabled)
            {
                sql += "and disable_flag=@disable_flag ";
                paramList.Add(new SQLiteParameter("disable_flag") { Value = 0 });
            }
            sql += "order by id ";

            List<Grid> grids = new List<Grid>();
            DataTable dt = SqliteHelper.ExecuteDataTable(sql, paramList.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                Grid g = Grid.FromJson(Convert.ToString(row["strategy_json"]));

                if (g != null)
                {
                    g.Id = Convert.ToInt32(row["id"]);
                    g.DisableFlag = Convert.ToInt32(row["disable_flag"]);
                    grids.Add(g);
                }
            }
            return grids;
        }
    }
}
