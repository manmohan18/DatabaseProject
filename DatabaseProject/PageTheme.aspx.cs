using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseProject.App_Code;

namespace DatabaseProject
{
    public partial class PageTheme : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            HttpCookie themeCookie = Request.Cookies["pageTheme"];
            if (themeCookie != null)
            {
                Page.Theme = themeCookie.Value;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie pageSetup;
            pageSetup = Request.Cookies["pageTheme"];

            if (radLight.Checked)
            {
                pageSetup = new HttpCookie("pageTheme", "Light");
            }
            else if (radDark.Checked)
            {
                pageSetup = new HttpCookie("pageTheme", "Dark");
            }
            pageSetup.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Add(pageSetup);
            Response.Redirect("pageTheme.aspx");

        }
    }
}