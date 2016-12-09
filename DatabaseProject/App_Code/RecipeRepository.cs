using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseProject.App_Code
{
    public class RecipeRepository
    {
        public RecipeRepository()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public List<Recipe> GetRecipies()
        {
            HttpApplication RecipeWebApp = HttpContext.Current.ApplicationInstance;
            return (List<Recipe>)RecipeWebApp.Application["recipe"];
        }
    }
}