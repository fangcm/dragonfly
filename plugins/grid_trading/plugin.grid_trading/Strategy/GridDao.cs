using Dragonfly.Plugin.GridTrading.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

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

            string sql = @"select id,grid_type,strategy_json,disable_flag
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
                GridType gridType = (GridType)Convert.ToInt32(row["grid_type"]);
                switch (gridType)
                {
                    case GridType.ManualGrid:
                        ManualGrid g = Grid.FromJson<ManualGrid>(Convert.ToString(row["strategy_json"]));
                        grids.Add(g);
                        break;
                }

            }
            return grids;
        }
    }
}
