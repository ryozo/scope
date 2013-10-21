using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scope.DbAccessor;
using System.Data.SqlClient;
using System.Data;

namespace Scope.Dao
{
    /// <summary>
    /// Dao共通の抽象クラス。
    /// </summary>
    public class AbstractDao
    {
        protected DataBaseAccessor accessor;
        protected AbstractDao(DataBaseAccessor accessor)
        {
            this.accessor = accessor;
        }

        /// <summary>
        /// Readerをcloseします。
        /// </summary>
        /// <param name="reader">close対象のreader</param>
        protected void closeReader(IDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                reader.Close();
            }
        }

        /// <summary>
        /// SQLParameterを作成します。
        /// </summary>
        /// <param name="parameterName">パラメータ名</param>
        /// <param name="value">Value</param>
        /// <returns></returns>
        protected SqlParameter makeParameter(String parameterName, Object value)
        {
            SqlParameter parameter = null;
            if (value == null)
            {
                parameter = new SqlParameter(parameterName, System.DBNull.Value);
            }
            else
            {
                parameter = new SqlParameter(parameterName, value);
            }
            return parameter;
        }

        /// <summary>
        /// SqlDataReaderの内容を読み取ります。
        /// </summary>
        /// <param name="reader">読み取り対象のSQLDataReader</param>
        /// <param name="param">読み取り対象列</param>
        /// <returns></returns>
        protected Object read(SqlDataReader reader, String param)
        {
            Object value = reader[param];
            if (value is System.DBNull)
            {
                return null;
            }
            return value;
        }
    }
}