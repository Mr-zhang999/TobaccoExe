using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobaccoApp
{
    class DataOperator
    {
        private static string connString = "Data Source=localhost;Initial Catalog=Tobacco;Integrated Security=True";//数据库连接字符串
        public static SqlConnection connection = new SqlConnection(connString);//数据库连接对象
        public static void ExecSQL(string sql)
        {
            SqlCommand command = new SqlCommand(sql, connection);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.ExecuteScalar();
            connection.Close();
        }
        public static int ExecSQLResult(string sql)
        {
            SqlCommand command = new SqlCommand(sql, connection);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;//返回受影响的行数
        }
        public static string GetDataReader(string sql)
        {
            SqlCommand command = new SqlCommand(sql, connection);
            if (connection.State == ConnectionState.Open)
                connection.Close();
            connection.Open();
            string datareader = command.ExecuteScalar().ToString();
            return datareader;
        }
        public static SqlDataReader GetDataReaderChart(string sql)
        {
            SqlCommand command = new SqlCommand(sql, connection);
            if (connection.State == ConnectionState.Open)
                connection.Close();
            connection.Open();
            SqlDataReader datareader = command.ExecuteReader();
            // datareader.Close();
            return datareader;
        }
        public static bool openTrans(string sql)
        {
            SqlCommand command = new SqlCommand(sql, connection);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            //开启事务
            SqlTransaction trans = connection.BeginTransaction();
            command.Transaction = trans;//添加事务
            try
            {
                command.ExecuteNonQuery();//执行                    
                trans.Commit();//执行完成之后提交            
                return true;
            }
            catch (Exception e)
            {
                //执行sql语句失败，事务回滚
                trans.Rollback();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
