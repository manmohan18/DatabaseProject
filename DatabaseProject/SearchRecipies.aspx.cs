using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            string category = drpCategory.SelectedItem.Text;
            string submittedBy = drpDwnUsers.SelectedItem.Text;
            string ingredientName = drpIngredient.SelectedItem.Text;

            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection conn = new OracleConnection(connString);

            string sql = "SELECT recipe_name from recipes join ingredients using (recipe_id) where submitted_by = :submittedBy and category = :category and ingredients.ingredient_name = :ingredientName";
            OracleCommand aCommand = new OracleCommand(sql, conn);
            aCommand.Parameters.Add("submittedBy", OracleDbType.Varchar2).Value = submittedBy;
            aCommand.Parameters.Add("category", OracleDbType.Varchar2).Value = category;
            aCommand.Parameters.Add("ingredientName", OracleDbType.Varchar2).Value = ingredientName;

            try
            {
                aCommand.Connection.Open();
                OracleDataReader reader = aCommand.ExecuteReader();
                searchGrid.DataSource = reader;
                searchGrid.DataBind();
            }

            catch (OracleException ex)
            {
                lblResult.Text = ex.Message;
            }
        }




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadDropDowns();
        }

        private void LoadDropDowns()
        {
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection conn = new OracleConnection(connString);

            string sql = "SELECT * from users";
            OracleCommand aCommand = new OracleCommand(sql, conn);
            try
            {
                aCommand.Connection.Open();
                OracleDataReader reader = aCommand.ExecuteReader();
                drpDwnUsers.DataSource = reader;
                drpDwnUsers.DataValueField = "user_id";
                drpDwnUsers.DataTextField = "username";
                drpDwnUsers.DataBind();

                aCommand = new OracleCommand("SELECT * from category", conn);
                reader = aCommand.ExecuteReader();
                drpCategory.DataSource = reader;
                drpCategory.DataValueField = "category_id";
                drpCategory.DataTextField = "category_type";
                drpCategory.DataBind();

                aCommand = new OracleCommand("SELECT * from ingredient_list", conn);
                reader = aCommand.ExecuteReader();
                drpIngredient.DataSource = reader;
                drpIngredient.DataValueField = "ingredient_id";
                drpIngredient.DataTextField = "ingredient_name";
                drpIngredient.DataBind();

            }
            catch (OracleException e)
            {
                lblResult.Text = e.Message;
            }

            drpDwnUsers.Items.Insert(0, new ListItem("ALL", "-1"));
            drpCategory.Items.Insert(0, new ListItem("ALL", "-1"));
            drpIngredient.Items.Insert(0, new ListItem("ALL", "-1"));
        }

    }


}