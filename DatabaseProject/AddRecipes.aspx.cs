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
    public partial class AddRecipes : System.Web.UI.Page
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
            BindCategory();
        }

        private void BindCategory()
        {
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection conn = new OracleConnection(connString);

            try
            {
                string sql = "select * from category";
                OracleCommand aCommand = new OracleCommand(sql, conn);

                aCommand.Connection.Open();
                OracleDataReader reader = aCommand.ExecuteReader();
                drpDwnCat.DataSource = reader;
                drpDwnCat.DataValueField = "category_id";
                drpDwnCat.DataTextField = "category_type";
                drpDwnCat.DataBind();
            }
            catch (OracleException ex)
            {
                lblResult.Text = ex.Message;
            }

            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void addRecipeeProceed_Click(object sender, EventArgs e)
        {
            
            Recipe aRecipe = new Recipe();
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection conn = new OracleConnection(connString);
            try
            {
                aRecipe.NameOfRecipe = txtRecipeName.Text;
                aRecipe.SubmittedBy = txtSubmittedBy.Text;
                aRecipe.Category = drpDwnCat.SelectedItem.Text;
                aRecipe.CookingTime = Convert.ToDouble(txtCookTime.Text);
                aRecipe.NumberOfServings = Convert.ToInt32(txtServings.Text);
                aRecipe.RecipeDescription = txtDescription.Text;
                AddIngredientToRecipe(aRecipe);


                string sql = "INSERT into recipes values(recipes_recipe_id_seq.nextval,:RecipeName,:SubmittedBy,:Category,:CookingTime,:Servings,:Description)";
                OracleCommand insertRecipe = new OracleCommand(sql, conn);

                insertRecipe.Parameters.Add("RecipeName", OracleDbType.Varchar2);
                insertRecipe.Parameters["RecipeName"].Value = aRecipe.NameOfRecipe;

                insertRecipe.Parameters.Add("SubmittedBy", OracleDbType.Varchar2);
                insertRecipe.Parameters["SubmittedBy"].Value = aRecipe.SubmittedBy;

                insertRecipe.Parameters.Add("Category", OracleDbType.Varchar2);
                insertRecipe.Parameters["Category"].Value = aRecipe.Category;

                insertRecipe.Parameters.Add("CookingTime", OracleDbType.Double);
                insertRecipe.Parameters["CookingTime"].Value = aRecipe.CookingTime;

                insertRecipe.Parameters.Add("Servings", OracleDbType.Double);
                insertRecipe.Parameters["Servings"].Value = aRecipe.NumberOfServings;

                insertRecipe.Parameters.Add("Description", OracleDbType.Varchar2);
                insertRecipe.Parameters["Description"].Value = aRecipe.RecipeDescription;

                insertRecipe.Connection.Open();
                insertRecipe.ExecuteNonQuery();
                //conn.Close();

                var Need = aRecipe.Needs;
                //OracleCommand insertIngredient ;
                foreach (var item in Need)
                {
                    if (item != null)
                    {
                        sql = "INSERT into ingredients values(ingredients_ingredient_id_seq.nextval,:IngredientName,:Quantity,:UnitOfMeasure,recipes_recipe_id_seq.currval)";
                        OracleCommand insertIngredient = new OracleCommand(sql, conn);

                        insertIngredient.Parameters.Add("IngredientName", OracleDbType.Varchar2);
                        insertIngredient.Parameters["IngredientName"].Value = item.Name;

                        insertIngredient.Parameters.Add("Quantity", OracleDbType.Double);
                        insertIngredient.Parameters["Quantity"].Value = item.Quantity;

                        insertIngredient.Parameters.Add("UnitOfMeasure", OracleDbType.Varchar2);
                        insertIngredient.Parameters["UnitOfMeasure"].Value = item.UnitOfMeasure;

                        insertIngredient.ExecuteNonQuery();
                        insertIngredient.Parameters.Clear();

                    }

                }
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }

            finally
            {
                conn.Close();
            }

        }

        private void AddIngredientToRecipe(Recipe aRecipe)
        {
            for (int i = 1; i < 16; i++)
            {
                ucIngredient uc = (ucIngredient)PlaceHolder1.FindControl("ucIngredient" + i);
                if (uc != null && uc.Visible == true)
                {
                    PlaceHolder1.Controls.Add(uc);
                    var ing = new Ingredient();
                    ing.Name = uc.NameOfIngredient;
                    ing.Quantity = uc.Qty;
                    ing.UnitOfMeasure = uc.Unit;
                    //lblResult.Text += " "+ing.Name + " " + ing.Quantity + " " + ing.UnitOfMeasure+" ";
                    aRecipe.Needs[i - 1] = ing;
                }
            }
        }

        static int count = 2;
        protected void addIngredient_Click(object sender, EventArgs e)
        {
            count++;
            for (int j = 2; j < count; j++)
            {
                string uControl = "ucIngredient" + j;
                ucIngredient uc = (ucIngredient)PlaceHolder1.FindControl(uControl);
                uc.Visible = true;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddRecipes.aspx");
        }

        protected void addCategory_Click(object sender, EventArgs e)
        {
            if (txtNewCat.Text != null)
            {
                string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                OracleConnection conn = new OracleConnection(connString);

                try
                {
                    string sql = "proc_category";
                    OracleCommand insertCategory = new OracleCommand(sql, conn);
                    insertCategory.CommandType = CommandType.StoredProcedure;
                    OracleParameter inputCategory = new OracleParameter("categoryType", OracleDbType.Varchar2);
                    inputCategory.Direction = ParameterDirection.Input;
                    inputCategory.Value = txtNewCat.Text;
                    insertCategory.Parameters.Add(inputCategory);
                    insertCategory.Connection.Open();
                    insertCategory.ExecuteNonQuery();
                    BindCategory();
                }
                catch (OracleException ex)
                {
                    lblResult.Text = ex.Message;
                }

                catch (Exception ex)
                {
                    lblResult.Text = ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }

        }
    }
}