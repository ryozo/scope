using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scope.Entity;

namespace Scope.Dto
{
    /// <summary>
    /// 書籍情報を保持するDto
    /// </summary>
    public class BookInfo
    {
        public BookType bookType;
        private String title;
        private String isbn;
        private String publisher;
        private Int32? price;
        private DateTime buyDate;
        private BookStatus status;
        private Int64? evalType;
        private String eval;

        public BookType BookType
        {
            set { this.bookType = value; }
            get { return bookType; }
        }

        public String Title
        {
            set { this.title = value; }
            get { return title; }
        }

        public String Isbn
        {
            set { this.isbn = value; }
            get { return isbn; }
        }

        public String Publisher
        {
            set { this.publisher = value; }
            get { return publisher; }
        }

        public Int32? Price
        {
            set { this.price = value; }
            get { return price; }
        }

        public DateTime BuyDate
        {
            set { this.buyDate = value; }
            get { return buyDate; }
        }

        public BookStatus Status
        {
            set { this.status = value; }
            get { return status; }
        }

        public Int64? EvalType
        {
            set { this.evalType = value; }
            get { return evalType; }
        }

        public String Eval
        {
            set { this.eval = value; }
            get { return eval; }
        }
    }
}