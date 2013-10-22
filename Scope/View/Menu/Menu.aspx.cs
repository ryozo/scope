using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scope.View
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InRegistLink.NavigateUrl = "~/View/InRegist/InRegist.aspx";
            SearchLink.NavigateUrl = "~/View/Search/SearchCondition.aspx";
        }
    }
}