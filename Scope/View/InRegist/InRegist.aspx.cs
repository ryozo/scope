using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Scope.Dto;
using Scope.Entity;
using Scope.Service.BookManage;
using Scope.Const;

namespace Scope.View.InRegist
{
    public partial class InRegist : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ListItem emptyEvalItem = new ListItem();
            emptyEvalItem.Text = SystemConstants.ViewLayerConstants.EMPTY_DRPDWN_TEXT;
            emptyEvalItem.Value = SystemConstants.ViewLayerConstants.EMPTY_DRPDWN_VALUE;
            BookEval.Items.Insert(0, emptyEvalItem);
        }

        protected void Regist_Click(object sender, EventArgs e)
        {
            // Service呼び出し用のDto作成
            BookInfo bookInfo = new BookInfo();
            bookInfo.BookType = getBookType();
            bookInfo.Title = trim(title.Text);
            bookInfo.Isbn = trim(isbn.Text);
            bookInfo.Publisher = trim(publisher.Text);
            if (!String.IsNullOrEmpty(price.Text))
            {
                bookInfo.Price = int.Parse(price.Text);
            }
            bookInfo.BuyDate = buyDate.SelectedDate;
            if (!SystemConstants.ViewLayerConstants.EMPTY_DRPDWN_VALUE.Equals(BookEval.SelectedItem.Value))
            {
                bookInfo.EvalType = Int64.Parse(BookEval.SelectedItem.Value);
            }
            bookInfo.Eval = trim(eval.Text);

            BookManageService service = new BookManageService();
            service.regist(bookInfo);

        }

        private BookType getBookType()
        {
            if (BookTypeBiz.Checked)
            {
                return BookType.BUSINESS;
            }
            if (BookTypeComic.Checked)
            {
                return BookType.COMMIC;
            }
            if (BookTypeMagazine.Checked)
            {
                return BookType.MAGAZINE;
            }
            return BookType.LIBRARY;
        }

        private String trim(String target)
        {
            if (target == null)
            {
                return null;
            }
            return isEmptyToNull(target.Trim());
        }

        /// <summary>
        /// 引数に受け取った文字列が空文字である場合、Nullに変換して返す。
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private String isEmptyToNull(String target)
        {
            return String.Empty.Equals(target) ? null : target;
        }
    }
}