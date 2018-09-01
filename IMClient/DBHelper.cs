using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMClient
{
    class DBHelper
    {
        static String connnectStr = "server=127.0.0.1;port=3306;user=root;password=lqn.091023; database=network;SslMode = none;";

        public static DataTable QueryData(string sqlStr, params SqlParameter[] parameter)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connnectStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    DataSet dt = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    cmd.Parameters.AddRange(parameter);
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                    conn.Close();
                    return dt.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("查询数据异常" + ex.Message);
            }
        }

        public static bool UpdateData(string sqlStr, params SqlParameter[] parameter)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connnectStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    cmd.Parameters.AddRange(parameter);
                    var row = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (row > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("更新数据异常" + ex.Message);
            }
        }

        public static bool DeleteData(string sqlStr, params SqlParameter[] parameter)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connnectStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    cmd.Parameters.AddRange(parameter);
                    var row = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (row > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("删除数据异常" + ex.Message);
            }
        }

        public static bool AddData(string sqlStr, params SqlParameter[] parameter)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connnectStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    cmd.Parameters.AddRange(parameter);
                    var row = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (row > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("添加数据异常" + ex.Message);
            }
        }
    }
}
