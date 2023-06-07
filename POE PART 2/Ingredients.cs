using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_PART_2
{
    internal class Ingredients
    {
        private string name; // creation of priavte string variable name
        private double quantity;  // creation of private double variable quantity
        private string unitOfMeasurement;  // creation of priavte string variable unitOfMeasurement
        private double calories; // creation of priavte double variable calories
        private string foodGroup; // creation of priavte string variable unitOfMeasurement

        // getter and setter
        public string Name { get => name; set => name = value; }
        public double Quantity { get => quantity; set => quantity = value; } 
        public string UnitOfMeasurement { get => unitOfMeasurement; set => unitOfMeasurement = value; } 
        public double Calories { get => calories; set => calories = value; }
        public string FoodGroup { get => foodGroup; set => foodGroup = value; }

        public override string ToString() // creation of override ToString() method
        {
            string ingredient = Quantity + " " + UnitOfMeasurement + " " + Name + " ,contains " + Calories + " kcl (" + FoodGroup + ")"; // creation and assignment of string variable ingredient

            return ingredient; // returns string variable
        }
    }
}
