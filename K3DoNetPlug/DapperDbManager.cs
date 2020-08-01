using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace K3DoNetPlug
{
    public class DapperDbManager
    {
        #region 对单元测试进行支持
        private static bool SupplyTest = false;

        private static string SupplyTestConnString = "";

        /// <summary>
        /// 调用后，将采用初始化的链接串进行数据为访问，可脱离开K3进行单元测试
        /// </summary>
        /// <param name="connString"></param>
        public static void DoSupplyTest(string connString)
        {
            SupplyTest = true;
            SupplyTestConnString = connString;
        }

        /// <summary>
        /// 支持单元测试
        /// </summary>
        private void DoSupplyTest()
        {
            if (SupplyTest)
            {
                conn = new SqlConnection(SupplyTestConnString);
            }
        }

        #endregion
        public DapperDbManager()
        {
            DoSupplyTest();
        }

        public DapperDbManager(string connString)
        {
            this.connString = connString;
            DoSupplyTest();
        }

        private string connString = "";        

        private SqlConnection conn= null;

        public SqlConnection Conn
        {
            get
            {
                if (conn == null)
                {
                    if (string.IsNullOrEmpty(this.connString))
                    {
                        this.connString = DBUnit.GlobalConnString;
                    }
                    this.conn = new SqlConnection(this.connString);
                }
                return conn;
            }
        }


        public IEnumerable<T> Query<T>(CommandDefinition command)
        {
            return this.Conn.Query<T>(command);
        }
        public IEnumerable<T> Query<T>(string sql, object param)
        {
            return this.Conn.Query<T>(sql, param);
        }
        public IEnumerable<IDictionary<string, object>> Query(string sql, object param)
        {
            return this.Conn.Query(sql, param);
        }
        public IEnumerable<T> Query<T>(string sql, object param, CommandType commandType)
        {
            return this.Conn.Query<T>(sql, param, commandType);
        }
        public IEnumerable<IDictionary<string, object>> Query(string sql, object param, CommandType? commandType)
        {
            return this.Conn.Query(sql, param, commandType);
        }
        public IEnumerable<IDictionary<string, object>> Query(string sql, object param, IDbTransaction transaction)
        {
            return this.Conn.Query(sql, param, transaction);
        }

        public IEnumerable<T> Query<T>(string sql, object param, IDbTransaction transaction)
        {
            return this.Conn.Query<T>(sql, param, transaction);
        }
        public IEnumerable<T> Query<T>(string sql, object param, IDbTransaction transaction, CommandType commandType)
        {
            return this.Conn.Query<T>(sql, param, transaction, commandType);
        }
        public IEnumerable<IDictionary<string, object>> Query(string sql, object param, IDbTransaction transaction, CommandType? commandType)
        {
            return this.Conn.Query(sql, param, transaction, commandType);               
        }
        public IEnumerable<T> Query<T>(string sql, object param, IDbTransaction transaction, bool buffered, int? commandTimeout, CommandType? commandType)
        {
            return this.Conn.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
        }

        //public IEnumerable<IDictionary<string, object>> Query(this IDbConnection cnn, string sql, object param, IDbTransaction transaction, bool buffered, int? commandTimeout, CommandType? commandType)
        //{

        //}
        //public IEnumerable<object> Query(this IDbConnection cnn, Type type, string sql, object param, IDbTransaction transaction, bool buffered, int? commandTimeout, CommandType? commandType);
        //public IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TReturn> map, object param, IDbTransaction transaction, bool buffered, string splitOn, int? commandTimeout, CommandType? commandType);
        //public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param, IDbTransaction transaction, bool buffered, string splitOn, int? commandTimeout, CommandType? commandType);
        //public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param, IDbTransaction transaction, bool buffered, string splitOn, int? commandTimeout, CommandType? commandType);

        public int Execute(CommandDefinition command)
        {
            return this.Conn.Execute(command);
        }
        public int Execute(string sql, object param)
        {
            return this.Conn.Execute(sql, param);
        }
        public int Execute(string sql, object param, CommandType commandType)
        {
            return this.Conn.Execute(sql, param, commandType);
        }
        public int Execute(string sql, object param, IDbTransaction transaction)
        {
            return this.Conn.Execute(sql, param, transaction);
        }
        public int Execute(string sql, object param, IDbTransaction transaction, CommandType commandType)
        {
            return this.Conn.Execute(sql, param, transaction, commandType);
        }
        public int Execute(string sql, object param, IDbTransaction transaction, int? commandTimeout, CommandType? commandType)
        {
            return this.Conn.Execute(sql, param, transaction, commandTimeout, commandType);
        }

 
    }
}
