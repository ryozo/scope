using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scope.DbAccessor;
using Scope.Entity;
using System.Data.SqlClient;

namespace Scope.Dao
{
    /// <summary>
    /// BookEvalマスタへのアクセスを担当するDao
    /// </summary>
    public class BookEvalDao : AbstractDao
    {
        public BookEvalDao(DataBaseAccessor accessor) : base(accessor) {}
        public List<BookEval> findAll()
        {
            String sql = "select * from BookEval";
            SqlDataReader reader = null;
            List<BookEval> evalList = new List<BookEval>();

            try
            {
                reader = accessor.select(sql);
                while (reader.Read())
                {
                    BookEval eval = new BookEval();
                    eval.Id = long.Parse(reader["id"].ToString());
                    eval.Eval = reader["eval"].ToString();
                    evalList.Add(eval);
                }
            }
            finally
            {
                closeReader(reader);
            }
            return evalList;
        }

        public BookEval findById(Int64? id)
        {
            if (id == null)
            {
                return null;
            }
            String sql = "select * from BookEval where id = @id";
            SqlDataReader reader = null;
            SqlParameter param = new SqlParameter("@id", id);
            BookEval eval = null;

            try
            {
                reader = accessor.select(sql, param);
                if (reader.Read())
                {
                    eval = new BookEval();
                    eval.Id = long.Parse(reader["id"].ToString());
                    eval.Eval = reader["evaluation"].ToString();
                }
            }
            finally
            {
                closeReader(reader);
            }

            return eval;
        }
    }
}