using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseProject
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dateDay = DateTime.Now.Date.ToLongDateString().ToString();
            lblDateDay.Text = dateDay;


            if (Application["DefPageCounter"] == null)
            {
                Application["DefPageCounter"] = 1;
            }
            else
            {
                Application.Lock();
                Application["DefPageCounter"] = (int)Application["DefPageCounter"] + 1;
                Application.UnLock();
            }
            visitCounts.Text = Application["DefPageCounter"].ToString();
        }
    }
}