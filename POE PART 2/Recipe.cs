using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_PART_2
{
    internal class Recipe
    {
        private string name; // creation of priavte string variable name
        private List<Ingredients> ingredients; // creation of private List of Ingredient objects
        private List<Steps> steps; // creation of private List of Steps objects

        //getter and setter
        public string Name { get => name; set => name = value; }
        internal List<Ingredients> Ingredients { get => ingredients; set => ingredients = value; }
        internal List<Steps> Steps { get => steps; set => steps = value; }

    }
}
