using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Scope.Dto;
using Scope.Const;

namespace Scope.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Login_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = Service.Login.LoginService.login(userId.Text, password.Text);
            if (userInfo != null)
            {
                Session[SystemConstants.SessionKey.USER_INFO] = userInfo;
                Response.Redirect("~/View/Menu/Menu.aspx");
            }

            messages.HeaderText = "エラーメッセージ";

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Call PageLoad");
        }
    }
}