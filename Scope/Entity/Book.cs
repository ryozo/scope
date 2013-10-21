using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scope.Entity
{
    public class Book
    {
        private Int64? id;
        private BookType bookType;
        private String title;
        private String isbn;
        private String publisher;
        private Int32? price;
        private DateTime buyDate;
        private BookStatus status;
        private BookEval bookEval;
        private String eval;

        public Int64? Id
        {
            set { this.id = value; }
            get { return id; }
        }

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

        public BookEval BookEval
        {
            set { this.bookEval = value; }
            get { return bookEval; }
        }

        public String Eval
        {
            set { this.eval = value; }
            get { return eval; }
        }
    }
}