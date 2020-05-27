using Dragonfly.Common.Utils;
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
                from grid_strategy ";

            if (onlyEnabled)
            {
                sql += "where disable_flag=@disable_flag ";
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

        internal static void SaveGrid(Grid grid)
        {
            if (grid.Id == 0)
            {
                InsertGrid(grid);
            }
            else
            {
                UpdateGrid(grid);
            }
        }

        internal static void InsertGrid(Grid grid)
        {
            string sql = @"INSERT INTO grid_strategy(strategy_json, disable_flag) 
                VALUES ( @strategy_json, @disable_flag)";

            string strategy_json = grid.ToJson();

            List<SQLiteParameter> paramList = new List<SQLiteParameter>();
            paramList.Add(new SQLiteParameter("strategy_json") { Value = strategy_json });
            paramList.Add(new SQLiteParameter("disable_flag") { Value = grid.DisableFlag });

            SqliteHelper.ExecuteNonQuery(sql, paramList.ToArray());
        }

        internal static void UpdateGrid(Grid grid)
        {
            string sql = @"UPDATE grid_strategy SET strategy_json=@strategy_json, disable_flag=@disable_flag
                WHERE id=@id";

            string strategy_json = grid.ToJson();

            List<SQLiteParameter> paramList = new List<SQLiteParameter>();
            paramList.Add(new SQLiteParameter("id") { Value = grid.Id });
            paramList.Add(new SQLiteParameter("strategy_json") { Value = strategy_json });
            paramList.Add(new SQLiteParameter("disable_flag") { Value = grid.DisableFlag });

            SqliteHelper.ExecuteNonQuery(sql, paramList.ToArray());
        }

        internal static void DeleteGrid(int gridId)
        {
            string sql = @"DELETE FROM grid_strategy WHERE id=@id";

            List<SQLiteParameter> paramList = new List<SQLiteParameter>();
            paramList.Add(new SQLiteParameter("id") { Value = gridId });

            SqliteHelper.ExecuteNonQuery(sql, paramList.ToArray());
        }

    }
}
