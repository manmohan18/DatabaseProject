using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseProject
{
    public partial class SearchRecipies : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            HttpCookie themeCookie = Request.Cookies["pageTheme"];
            if (themeCookie != null)
            {
                Page.Theme = themeCookie.Value;
            }

        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}