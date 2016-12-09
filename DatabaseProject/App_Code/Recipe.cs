using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseProject.App_Code
{
    public class Recipe
    {
        public Recipe()
        {
            Needs = new Ingredient[15];
        }

        private string nameOfRecipe;

        public string NameOfRecipe
        {
            get { return nameOfRecipe; }
            set { nameOfRecipe = value; }
        }

        private string submittedBy;

        public string SubmittedBy
        {
            get { return submittedBy; }
            set { submittedBy = value; }
        }

        private string category;

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        private double cookingTime;

        public double CookingTime
        {
            get { return cookingTime; }
            set { cookingTime = value; }
        }

        private int numberOfServings;

        public int NumberOfServings
        {
            get { return numberOfServings; }
            set { numberOfServings = value; }
        }


        private string recipeDescription;
        public string RecipeDescription
        {
            get { return recipeDescription; }
            set { recipeDescription = value; }
        }

        private Ingredient[] needs;
        public Ingredient[] Needs
        {
            get { return needs; }
            set { needs = value; }
        }

    }
}