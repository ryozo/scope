using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Scope.DbAccessor
{
    /// <summary>
    /// DBアクセスを行うクラス
    /// </summary>
    public class DataBaseAccessor
    {
        private SqlConnection connection;
        private String url;

        public DataBaseAccessor()
        {
            url = String.Empty;
            url += "Data Source            = .\\SQLEXPRESS;";
            url += "AttachDbFilename      = |DataDirectory|\\Database1.mdf;";
            url += "Integrated Security   = True;";
            url += "User Instance         = True";
        }

        /// <summary>
        /// DB接続を行います。
        /// </summary>
        public void open()
        {
            lock (this)
            {
                connection = new SqlConnection(url);
                connection.Open();
            }
        }

        /// <summary>
        /// 引数に受け取ったSQLを実行し、検索結果を保持するSqlDataReaderを返します。
        /// </summary>
        /// <param name="sql">実行対象のSQL</param>
        /// <returns></returns>
        public SqlDataReader select(String sql, params SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(sql, connection);
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    command.Parameters.Add(parameters[i]);
                }
            }
            return command.ExecuteReader();
        }

        /// <summary>
        /// DB接続を閉じます。
        /// </summary>
        public void close()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// デストラクタ。Connectionをクローズします。
        /// </summary>
        ~DataBaseAccessor()
        {
            close();
        }
    }
}