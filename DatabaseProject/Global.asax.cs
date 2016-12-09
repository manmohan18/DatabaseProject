using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using DatabaseProject.App_Code;

namespace DatabaseProject
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            List<Recipe> recipies = new List<Recipe>();
            Application["recipe"] = recipies;
            recipies.Add(new Recipe { NameOfRecipe = "Pasta", SubmittedBy = "Bob", Category = "Fast Food", CookingTime = 7, NumberOfServings = 2, RecipeDescription = "Convenient food, ready within 7 minutes" });
            recipies.Add(new Recipe { NameOfRecipe = "Pizza", SubmittedBy = "Robert", Category = "Canadian Special", CookingTime = 10, NumberOfServings = 2, RecipeDescription = "Ready within 10 minutes" });
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}