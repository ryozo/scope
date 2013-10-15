using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scope.Entity;
using Scope.DbAccessor;
using System.Data.SqlClient;

namespace Scope.Dao
{
    /// <summary>
    /// Userテーブルへのアクセスを担当するDao
    /// </summary>
    public class UserDao : AbstractDao
    {
        public UserDao(DataBaseAccessor accessor) : base(accessor) {}

        /// <summary>
        /// 引数に指定されたユーザIDを保持するユーザを検索する。
        /// </summary>
        /// <param name="userId">検索対象のユーザID</param>
        /// <returns>検索結果を保持するUserエンティティ</returns>
        public User findByUserId(String userId)
        {
            String sql = "select * from user where userid = @userid";
            SqlParameter param = new SqlParameter("@userid", userId);
            SqlDataReader reader = null;
            User user = null;

            try
            {
                reader = accessor.select(sql, param);
                if (reader.Read())
                {
                    user = new User();
                    user.UserId = reader["userId"].ToString();
                    user.Password = reader["password"].ToString();
                }
            }
            finally
            {
                closeReader(reader);
            }

            return user;
        }

        /// <summary>
        /// ユーザIDとパスワードを利用してユーザを検索する。
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User findByUserIdAndPassword(String userId, String password)
        {
            String sql = "select * from [User] where userid = @userid and password = @password";
            SqlParameter userIdParam = new SqlParameter("@userid", userId);
            SqlParameter passwordParam = new SqlParameter("@password", password);

            SqlDataReader reader = null;
            User user = null;

            try
            {
                reader = accessor.select(sql, userIdParam, passwordParam);

                if (reader.Read())
                {
                    user = new User();
                    user.UserId = reader["userId"].ToString();
                    user.Password = reader["password"].ToString();
                    return user;
                }

            }
            finally
            {
                closeReader(reader);
            }

            return user;
        }
    }
}