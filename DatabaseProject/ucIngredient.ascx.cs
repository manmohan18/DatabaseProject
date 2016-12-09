using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseProject
{
    public partial class ucIngredient : System.Web.UI.UserControl
    {
        public string NameOfIngredient
        {

            get
            {
                if (Name != null) return Name.Text;
                else return "null";
            }

        }
        public double Qty
        {
            get
            {
                if (Quantity != null)
                    return Convert.ToDouble(Quantity.Text);
                else return 0;
            }
        }

        public string Unit
        {
            get
            {
                if (ddlUnit != null)
                    return ddlUnit.SelectedItem.ToString();
                else return "null";
            }
        }
    }
}