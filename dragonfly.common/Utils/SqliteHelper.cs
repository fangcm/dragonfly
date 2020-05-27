using System;
using System.Data;
using System.Data.SQLite;

namespace Dragonfly.Common.Utils
{
    public class SqliteHelper
    {
        private static SQLiteConnectionStringBuilder connectionString = new SQLiteConnectionStringBuilder();

        public static SQLiteConnectionStringBuilder ConnectionString
        {
            get { return SqliteHelper.connectionString; }
            set { SqliteHelper.connectionString = value; }
        }

        public static string DataSource
        {
            get { return SqliteHelper.connectionString.DataSource; }
            set { SqliteHelper.connectionString.DataSource = value; }
        }

        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, string cmdText, params object[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Parameters.Clear();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 30;
            cmd.Parameters.AddRange(cmdParms);
        }

        public static object ToDBValue(object value)
        {
            return value == null ? DBNull.Value : value;
        }

        public static object FromDBValue(object dbValue)
        {
            return dbValue == DBNull.Value ? null : dbValue;
        }


        public static int ExecuteNonQuery(string cmdText, params object[] cmdParms)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString.ConnectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    PrepareCommand(command, conn, cmdText, cmdParms);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string cmdText, params object[] cmdParms)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString.ConnectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    PrepareCommand(command, conn, cmdText, cmdParms);
                    if (command.ExecuteNonQuery() > 0)
                    {
                        command.CommandText = "select last_insert_rowid()";
                        return command.ExecuteScalar();
                    }
                    return null;
                }
            }
        }

        public static DataTable ExecuteDataTable(string cmdText, params object[] cmdParms)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString.ConnectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    DataTable dt = new DataTable();
                    PrepareCommand(command, conn, cmdText, cmdParms);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                    da.Fill(dt);
                    return dt;
                }
            }
        }

    }
}
