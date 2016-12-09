using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseProject.App_Code
{
    public class Ingredient
    {
        public Ingredient()
        {
            //
            // TODO: Add constructor logic here
            //

        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private double quantity;

        public double Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private string unitOfMeasure;

        public string UnitOfMeasure
        {
            get { return unitOfMeasure; }
            set { unitOfMeasure = value; }
        }

    }
}