using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseProject.App_Code;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;

namespace DatabaseProject
{
    public partial class Recipes : System.Web.UI.Page
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
            BindRecipeList();
        }

        private void BindRecipeList()
        {
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            OracleCommand comm = new OracleCommand();
            comm = conn.CreateCommand();

            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT * from recipes";

            try
            {
                comm.Connection.Open();
                OracleDataReader reader = comm.ExecuteReader();
                gvRecipes.DataSource = reader;
                gvRecipes.DataKeyNames = new string[] { "recipe_id" };
                gvRecipes.DataBind();
                reader.Close();
            }
            catch (Exception ex)
            {
                lblProblem.Text = ex.Message;
            }


        }

        protected void gvRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = gvRecipes.SelectedIndex;
            GridViewRow row = gvRecipes.Rows[selectedIndex];
            string recipeName = row.Cells[0].Text;
            lblProblem.Text = "You have selected: " + recipeName;
            int recipeID = int.Parse(gvRecipes.DataKeys[gvRecipes.SelectedIndex].Value.ToString());
            Session["recipeID"] = recipeID;
            Response.Redirect("~/RecipeDetails.aspx");
        }

    }
}