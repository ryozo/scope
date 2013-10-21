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
    /// Bookテーブルへのアクセスを担当するDao
    /// </summary>
    public class BookDao : AbstractDao
    {
        public BookDao(DataBaseAccessor accessor) : base(accessor) {}

        public Book insert(Book book)
        {
            String sql = "insert into book (bookType, title, isbn, publisher, price, buydate, status, bookEval_id, eval) values (@bookType, @title, @isbn, @publisher, @price, @buydate, @status, @bookEval_id, @eval)";

            SqlParameter bookTypeParam = new SqlParameter("@bookType", book.BookType);
            SqlParameter titleParam = new SqlParameter("@title", book.Title);
            SqlParameter isbnParam = new SqlParameter("@isbn", book.Isbn);            
            SqlParameter publichserParam = new SqlParameter("@publisher", book.Publisher);
            SqlParameter priceParam = new SqlParameter("@price", book.Price);
            SqlParameter buyDateParam = new SqlParameter("@buydate", book.BuyDate);
            SqlParameter statusParam = new SqlParameter("@status", book.Status);
            SqlParameter evalTypeParam = null;
            if (book.BookEval != null)
            {
                evalTypeParam = new SqlParameter("@bookEval_id", book.BookEval.Id);
            }
            else
            {
                evalTypeParam = new SqlParameter("@bookEval_id", null);
            }
            SqlParameter evalParam = new SqlParameter("@eval", book.Eval);

            SqlParameter[] sqlParameters = new SqlParameter[] {
                bookTypeParam, titleParam, isbnParam, publichserParam, priceParam, buyDateParam, statusParam, evalTypeParam, evalParam
            };

            if (accessor.executeNonQuery(sql, sqlParameters) == 0)
            {
                throw new ApplicationException("DBInsertに失敗しました");
            }

            // IDの取得
            // TODO 改善
            Book insertedBook = findByIsbn(book.Isbn);
            book.Id = insertedBook.Id;

            return book;
        }

        public Book findByIsbn(String isbn)
        {
            String sql = "select * from book where isbn = @isbn";
            SqlParameter param = new SqlParameter("@isbn", isbn);
            SqlDataReader reader = null;

            Book book = null;
            try
            {
                reader = accessor.select(sql, param);
                if (reader.Read())
                {
                    book = new Book();
                    book.Id = (Int64)reader["id"];
                    book.BookType = (BookType)Enum.ToObject(typeof(BookType), (Int32) reader["bookType"]);
                    book.Title = (String)reader["title"];
                    book.Isbn = (String)reader["isbn"];
                    book.Publisher = (String)reader["publisher"];
                    book.Price = (Int32)reader["price"];
                    book.BuyDate = (DateTime)reader["buydate"];
                    book.Status = (BookStatus)Enum.ToObject(typeof(BookStatus), (Int32) reader["status"]);
                    // TODO BookEvalをたどって取得する？
                    book.Eval = (String)reader["eval"];
                }
            }
            finally
            {
                closeReader(reader);
            }

            return book;
        }


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