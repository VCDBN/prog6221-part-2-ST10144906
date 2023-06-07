using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_PART_2
{
    internal class Steps
    {
        private string stepDescription; // creation of priavte string variable stepDescription

        public string StepDescription { get => stepDescription; set => stepDescription = value; } // getter and setter

        public override string ToString() // creation of override ToString() method
        {
            string display = "" + StepDescription;
            return display;
        }
    }
}
