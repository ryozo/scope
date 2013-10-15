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
    }
}