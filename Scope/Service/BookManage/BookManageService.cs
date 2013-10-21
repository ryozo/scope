using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scope.Entity;
using Scope.Dto;
using Scope.Dao;
using Scope.DbAccessor;

namespace Scope.Service.BookManage
{

    /// <summary>
    /// 書籍管理用のサービス
    /// </summary>
    public class BookManageService
    {
        /// <summary>
        /// 書籍情報を登録する。
        /// </summary>
        /// <param name="?"></param>
        public void regist(BookInfo bookInfo)
        {
            if (bookInfo == null) {
                throw new NullReferenceException("BookInfo is null");
            }

            // TODO 宣言的トランザクションに対応する。
            DataBaseAccessor accessor = new DataBaseAccessor();
            accessor.open();

            BookEval eval = null;
            // Evalのマスタ存在チェック
            if (bookInfo.EvalType != null) {
                BookEvalDao evalDao = new BookEvalDao(accessor);
                eval = evalDao.findById(bookInfo.EvalType);
                if (eval == null)
                {
                    // TODO Exceptionを確認
                    throw new ApplicationException("評価マスタ上に存在しない評価です。");
                }
            }

            // BookEntityの作成
            Book book = new Book();
            book.BookType = bookInfo.BookType;
            book.Title = bookInfo.Title;
            book.Isbn = bookInfo.Isbn;
            book.Publisher = bookInfo.Publisher;
            book.Price = bookInfo.Price;
            book.BuyDate = bookInfo.BuyDate;
            book.Status = bookInfo.Status;
            book.BookEval = eval;
            book.Eval = bookInfo.Eval;

            BookDao bookDao = new BookDao(accessor);
            bookDao.insert(book);
        }

    }
}