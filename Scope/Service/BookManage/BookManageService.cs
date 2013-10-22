using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scope.Entity;
using Scope.Dto;
using Scope.Dao;
using Scope.DbAccessor;
using Scope.Exception;

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
                    throw new ApplicationRuntimeException("評価マスタ上に存在しない評価です。");
                }
            }

            // Bookの存在有無チェック
            BookDao bookDao = new BookDao(accessor);
            Book existsBook = bookDao.findByIsbn(bookInfo.Isbn);
            if (existsBook != null)
            {
                throw new ApplicationRuntimeException("この本は既に登録済みです。入力内容をご確認ください");
            }

            // BookEntityの作成
            Book registBook = new Book();
            registBook.BookType = bookInfo.BookType;
            registBook.Title = bookInfo.Title;
            registBook.Isbn = bookInfo.Isbn;
            registBook.Publisher = bookInfo.Publisher;
            registBook.Price = bookInfo.Price;
            registBook.BuyDate = bookInfo.BuyDate;
            registBook.Status = bookInfo.Status;
            registBook.BookEval = eval;
            registBook.Eval = bookInfo.Eval;

            bookDao.insert(registBook);
        }

    }
}