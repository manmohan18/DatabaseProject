using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseProject.App_Code;

namespace DatabaseProject
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            HttpCookie themeCookie = Request.Cookies["pageTheme"];
            if (themeCookie != null)
            {
                Page.Theme = themeCookie.Value;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}