using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scope.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Login_Click(object sender, EventArgs e)
        {
            
            Service.Login.LoginService.login(userId, password);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Call PageLoad");
        }
    }
}