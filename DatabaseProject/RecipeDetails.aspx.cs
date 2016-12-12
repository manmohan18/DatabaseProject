using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseProject.App_Code;

namespace DatabaseProject
{
    public partial class RecipeDetails : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                if (Session["recipeID"] != null)
                {
                    BindRecipeDetails();
                    BindIngredientDetails();
                }
            }

        }
        private void BindRecipeDetails()
        {

            int recipeID = (int)Session["recipeID"];
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;

            try
            {
                conn.Open();
                string sql = "select * from recipes where recipe_id = :recipeID";
                OracleCommand aCommand = new OracleCommand(sql, conn);

                aCommand.Parameters.Add("recipeID", recipeID);

                OracleDataReader reader = aCommand.ExecuteReader();
                dlRecipes.DataSource = reader;
                dlRecipes.DataKeyNames = new string[] { "recipe_id" };
                dlRecipes.DataBind();
            }
            catch (OracleException ora)
            {
                lblProblem.Text = ora.Message;
            }
            catch (Exception ex)
            {
                lblProblem.Text = ex.Message;
            }

            finally
            {
                conn.Close();
            }



        }

        private void BindIngredientDetails()
        // bind ingredient details information
        {
            OracleConnection conn = null;
            OracleDataAdapter adapter;
            DataSet ds = new DataSet();
            int recipeID = (int)Session["recipeID"];

            if (ViewState["IngredientDataSet"] == null)
            {
                try
                {
                    string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    conn = new OracleConnection(connString);

                    adapter = new OracleDataAdapter("select ingredient_name, quantity, unit_of_measure, recipe_id from ingredients where recipe_id = " + recipeID, conn);
                    adapter.Fill(ds, "Ingredients");
                }
                catch (Exception e)
                {

                    lblProblem.Text = e.Message;
                }

                ViewState["IngredientDataSet"] = ds;
            }

            else
            {
                ds = (DataSet)ViewState["IngredientDataSet"];
            }

            dlIngredients.DataSource = ds.Tables["Ingredients"].DefaultView;
            dlIngredients.DataBind();
        }



        protected void deleteRecipe_Click(object sender, EventArgs e)
        {
            deleteIngredient();
            deleteRecipes();
        }

        private void deleteIngredient()
        {
            int recipeID = (int)Session["recipeID"];
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;

            try
            {
                conn.Open();
                string sql = "delete from ingredients where recipe_id = :recipeID";
                OracleCommand aCommand = new OracleCommand(sql, conn);

                aCommand.Parameters.Add("recipeID", recipeID);

                OracleDataReader reader = aCommand.ExecuteReader();
                dlIngredients.DataSource = reader;
                dlIngredients.DataKeyNames = new string[] { "recipe_id" };
                dlIngredients.DataBind();
            }
            catch (OracleException ora)
            {
                lblProblem.Text = ora.Message;
            }
            catch (Exception ex)
            {
                lblProblem.Text = ex.Message;
            }

            finally
            {
                conn.Close();
            }
        }

        private void deleteRecipes()
        {
            int recipeID = (int)Session["recipeID"];
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;

            try
            {
                conn.Open();
                string sql = "delete from recipes where recipe_id = :recipeID";
                OracleCommand aCommand = new OracleCommand(sql, conn);

                aCommand.Parameters.Add("recipeID", recipeID);

                OracleDataReader reader = aCommand.ExecuteReader();
                dlIngredients.DataSource = reader;
                dlIngredients.DataKeyNames = new string[] { "recipe_id" };
                dlIngredients.DataBind();
            }
            catch (OracleException ora)
            {
                lblProblem.Text = ora.Message;
            }
            catch (Exception ex)
            {
                lblProblem.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }


        protected void dlRecipes_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            dlRecipes.ChangeMode(e.NewMode);
            BindRecipeDetails();
        }



        protected void dlRecipes_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            int recipeID = (int)Session["recipeID"];
            string newRecipeName = ((TextBox)dlRecipes.FindControl("txtNewRecipeName")).Text;
            string newCategory = ((DropDownList)dlRecipes.FindControl("ddlNewCategory")).SelectedItem.Text;
            double newCookingTime = Convert.ToDouble(((TextBox)dlRecipes.FindControl("txtNewCookingTime")).Text);
            int newServings = Convert.ToInt32(((TextBox)dlRecipes.FindControl("txtNewServings")).Text);
            string newDescription = ((TextBox)dlRecipes.FindControl("txtNewDescription")).Text;

            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection conn = new OracleConnection(connString);


            string sql = "updateRecipes";
            OracleCommand updateCommand = new OracleCommand(sql, conn);
            updateCommand.CommandType = CommandType.StoredProcedure;

            updateCommand.Parameters.Add("newRecipeName", OracleDbType.Varchar2).Value = newRecipeName;
            updateCommand.Parameters.Add("newCategory", OracleDbType.Varchar2).Value = newCategory;
            updateCommand.Parameters.Add("newCookingTime", OracleDbType.Double).Value = newCookingTime;
            updateCommand.Parameters.Add("newServings", OracleDbType.Int32).Value = newServings;
            updateCommand.Parameters.Add("newDescription", OracleDbType.Varchar2).Value = newDescription;
            updateCommand.Parameters.Add("recipeID", OracleDbType.Int32).Value = recipeID;

            try
            {
                updateCommand.Connection.Open();
                updateCommand.ExecuteNonQuery();

                dlRecipes.ChangeMode(DetailsViewMode.ReadOnly);
                BindRecipeDetails();
            }
            catch (Exception ex)
            {
                lblProblem.Text = ex.Message;
            }
            finally
            {
                updateCommand.Connection.Close();
            }
        }

        protected void dlIngredients_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dlIngredients.EditIndex = e.NewEditIndex;
            BindIngredientDetails();
        }



        protected void dlIngredients_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dlIngredients.EditIndex = -1;
            BindIngredientDetails();
        }



        protected void dlIngredients_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dTable = ((DataSet)ViewState["IngredientDataSet"]).Tables["Ingredients"];
            GridViewRow row = dlIngredients.Rows[e.RowIndex];
            string ingredientName = ((TextBox)row.Cells[0].Controls[1]).Text;
            int quantity = Convert.ToInt32(((TextBox)row.Cells[1].Controls[1]).Text);

            dTable.Rows[e.RowIndex]["Ingredient_name"] = ingredientName;
            dTable.Rows[e.RowIndex]["Quantity"] = quantity;
            dlIngredients.EditIndex = -1;
            BindIngredientDetails();
        }



        protected void saveBtn_Click(object sender, EventArgs e)
        {
            int recipeID = (int)Session["recipeID"];
            OracleConnection conn = null;
            OracleDataAdapter adapter;
            OracleCommandBuilder commandBuilder;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            conn = new OracleConnection(connectionString);

            adapter = new OracleDataAdapter("select ingredient_name, quantity, unit_of_measure from ingredients where recipe_id = " + recipeID, conn);
            commandBuilder = new OracleCommandBuilder(adapter);
            adapter.Update(((DataSet)ViewState["IngredientDataSet"]).Tables["Ingredients"]);
        }
    }
}