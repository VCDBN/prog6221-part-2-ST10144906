using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace POE_PART_2
{
    internal class Process1
    {
        List<Recipe> recipes = new List<Recipe>(); // creation of list of recipe objects
        List<Ingredients> ingred; // creation of list of Ingredients object
        List<Steps> stepsOfRecipe; // creation of list of Steps object
        List<Original> org = new List<Original>(); // creation of list of Original object

        delegate void CaloriesNotification(); // creation of delegate

        static event CaloriesNotification CaloriesExceed300; // creation of delegate, event 
        public void createRecipe()// void method used to create recipes
        {
            Console.WriteLine("ENTER THE NAME OF THE RECIPE: "); // // displays message to user, asking for input
            String recipeName = " "; // creation of string variable recipeName
            recipeName = validationString(recipeName); // calls validationString() method and assigns value to recipeName

            Console.WriteLine("ENTER THE NUMBER OF INGREDIENTS NEEDED FOR THIS RECIPE: ");// displays message to user, asking for input
            int numberOfIngredients; // creation of integer variable numberOfIngredients

            while (!int.TryParse(Console.ReadLine(), out numberOfIngredients))// while loop 
            {
                Console.ForegroundColor = ConsoleColor.Red; // changes colour of text in console             
                Console.WriteLine("Invalid datatype entered, please enter a valid integer value:"); // display to user, error message
                Console.ResetColor(); // resets colour of text in console
            }

            for (int j = 0; j < numberOfIngredients; j++)// for loop
            {
                Console.WriteLine("\nENTER THE DETIALS OF INGREDIENT NUMBER " + (j + 1)); // // displays message to user

                Console.WriteLine("ENTER THE NAME OF THE INGREDIENT: ");// displays message to user, asking for input
                string ingredientName = " "; // creates string variable name
                ingredientName = validationString(ingredientName); // calls the validationString method and passes the name variable through it

                Console.WriteLine("ENTER THE QUANTITY OF THE INGREDIENT: ");// displays message to user, asking for input
                double quantity; // creation of double variable quantity

                while (!double.TryParse(Console.ReadLine(), out quantity)) // while loop, captures data entered by user and checks if it is double, if it is not it displays an error message
                {
                    Console.ForegroundColor = ConsoleColor.Red; // changes colour of text in console
                    Console.WriteLine("Invalid datatype entereed, please enter a valid double value:"); // displays message to user, error message
                    Console.ResetColor(); // ressets colour of text in console
                }

                Console.WriteLine("ENTER THE UNIT OF MEASUREMENT OF THE INGREDIENT: ");// displays message to user, asking for input
                string unitOfMearsurement = " "; // creates string variable unitOfMearsurement
                unitOfMearsurement = validationString(unitOfMearsurement);  // calls the validationString method and passes the unitOfMearsurement variable through it

                Console.WriteLine("ENTER THE NUMBER OF CALORIES IN THE INGREDIENT: ");// displays message to user, asking for input
                double calories;// creates double variable calories

                while (!double.TryParse(Console.ReadLine(), out calories)) // while loop, captures data entered by user and checks if it is double, if it is not it displays an error message
                {
                    Console.ForegroundColor = ConsoleColor.Red; // changes colour of text in console
                    Console.WriteLine("Invalid datatype entereed, please enter a valid double value:"); // displays message to user, error message
                    Console.ResetColor(); // resets colour of text in console
                }

                Console.WriteLine("ENTER THE FOOD GROUP OF THE INGREDIENT: ");// displays message to user, asking for input
                string foodGroup = " "; // creates string variable foodGroup
                foodGroup = validationString(foodGroup);// calls the validationString method and passes the foodGroup variable through it

                Console.WriteLine("THE DETIALS OF INGREDIENT NUMBER " + (j + 1) + " HAS BEEN CAPTURED");// displays message to user

                org.Add(new Original { Quan = quantity, Cal = calories}); // populates org list

                ingred = new List<Ingredients>(); // creates new instances of ingred object
                ingred.Add(new Ingredients { Name = ingredientName, Quantity = quantity, UnitOfMeasurement = unitOfMearsurement, Calories = calories, FoodGroup = foodGroup}); // populates ingred list
                
                Console.ForegroundColor = ConsoleColor.Green; // changes colour of text in console
                Console.WriteLine("\nALL THE INGREDIENTS HAVE BEEN CAPTURED \n"); // displays message to user
                Console.ResetColor(); // resets colour of text in console
            }
            Console.WriteLine("ENTER THE NUMBER OF STEPS FOR THE RECIPE: "); // displays message to user
            int numberOfSteps; // creates integer variable steps, 

            while (!int.TryParse(Console.ReadLine(), out numberOfSteps)) // while loop, captures data entered by user and checks if it is int, if it is not it displays an error message
            {
                Console.ForegroundColor = ConsoleColor.Red; // changes colour of text in console
                Console.WriteLine("Invalid datatype entereed, please enter a valid integer value:"); // displays message to user, error message
                Console.ResetColor(); // resets colour of text in console
            }

            for (int j = 0; j < numberOfSteps; j++) // for loop
            {
                Console.WriteLine("ENTER A DESCRIPTION OF STEP " + (j + 1)); // displays message to user
                String description = Console.ReadLine(); // creation and assignemnt of var description using user input
                stepsOfRecipe = new List<Steps>(); // creates new instance of stepsOfRecipe list
                stepsOfRecipe.Add(new Steps { StepDescription = description }); // populates stepsOfRecipe list
            }
            recipes.Add(new Recipe { Name = recipeName, Ingredients = ingred, Steps = stepsOfRecipe }); // populates recipes list

            Console.ForegroundColor = ConsoleColor.Green; // changes colour of text in console
            Console.WriteLine("\nYOUR RECIPE HAS BEEN CAPTURED \n"); // displays message to user, error message
            Console.ResetColor(); // resets colour of text in console
            menu(); // calls method, menu
        }

        public double caloriesCalulation(int p) // calulates the calories in a given recipe
        {
            double total = 0; // creation and assignment of total variable
            for (int i = 0; i < recipes[p].Ingredients.Count; i++) // for loop
            {
                total = total + recipes[p].Ingredients[i].Calories; // adds total to total and the calories in the given recipe
            }

            if (total > 300) // if statement, check if total is greater than 300
            {
                CaloriesExceed300 += CaloriesExceed300Notification; // assigns the method to the event
                CaloriesExceed300?.Invoke(); // invokes the event
            }
            return total; // returns total
        }

        public void CaloriesExceed300Notification() // method used to display error message to user
        {
            Console.ForegroundColor = ConsoleColor.Red; // changes colour of text in console
            Console.WriteLine("Warning: The total calories of the recipe exceed 300!"); // displays error message to user
            Console.ResetColor(); // resets colour of text in console
        }
        public void displayAlphabeticalOrder() // method used to display alphabetical order of recipes
        {
            if (recipes != null && ingred != null && stepsOfRecipe != null) // if statement, checks if the array of object and array is not empty
            {
                recipes.Sort((x, y) => string.Compare(x.Name, y.Name)); // sorts recipes based on the first letter of the recipe name
                for (int i = 0; i < recipes.Count; i++) // for loop
                {
                    Console.WriteLine("Recipe " + (i + 1) + ". " + recipes[i].Name); // displays message to user

                    Console.WriteLine("\nINGREDIENTS: "); // displays message to user
                    for (int j = 0; j < recipes[i].Ingredients.Count; j++)// might change arrIngredient - 1; 
                    {
                        Console.WriteLine((j + 1) + ". " + recipes[i].Ingredients[j].ToString()); // displays ingredients
                    }

                    Console.WriteLine("\nSTEPS: "); // displays message to user
                    for (int j = 0; j < recipes[i].Steps.Count; j++)// might change stepsOfRecipe - 1;
                    {
                        Console.WriteLine("Step " + (j + 1) + ". " + recipes[i].Steps[j].ToString()); // displays steps
                    }

                    Console.WriteLine("\nTHE TOTAL NUMBER OF CALORIES IN THIS RECIPE IS: " + caloriesCalulation(i) + "kcal"); // displays messgae to user

                    Console.ForegroundColor = ConsoleColor.Green; // changes colour of text in console
                    Console.WriteLine("\nRECIPE HAS BEEN DISPLAYED\n"); // displays message to user
                    Console.ResetColor(); // resets colour of text in console
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; // changes colour of text in console
                Console.WriteLine("THE RECIPE HAS NOT BEEN CREATED \n"); // displays message to user, error message
                Console.ResetColor(); // resets colour of text in console
            }
            menu(); // calls method, menu
        }
        public string displaySearch() // method used to search in list of recipe objects for a certian recipe
        { 
            string display = " "; // cretaion and assignment of string variable dispplay

            if (recipes != null && ingred != null && stepsOfRecipe != null) // if statement, checks if the array of object and array is not empty
            {
                Console.WriteLine("ALL RECIPES"); // display message to user
                for (int i = 0; i < recipes.Count; i++) // for loop
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // changes colour of text in console
                    Console.WriteLine((i + 1) + recipes[i].Name); // displays message to user
                    Console.ResetColor(); // resets colour of text in console
                }

                Console.WriteLine("\nENTER THE NAME OF THE RECIPE YOU WANT TO SEARCH FOR: "); // displays message to user
                string findRecipe = " "; // creation and assignment of string variable findRecipe
                findRecipe = validationString(findRecipe); // calls validationString() method and assigns value to findRecipe

                Boolean found = false; // creation and assignment of Boolean variable found

                for (int i = 0; i < recipes.Count; i++) // for loop
                {
                    if (recipes[i].Name == findRecipe) // if statement, checks if name of recipe is equal to findRecipe
                    {
                        found = true; // found set to true
                        display = "Recipe " + (i + 1) + ". " + recipes[i].Name + "\n"; // assigns value to display

                        display += "INGREDIENTS: "; // assigns value to display

                        for (int j = 0; j < recipes[i].Ingredients.Count; j++)// might change arrIngredient - 1; 
                        {
                            display += "\n" + (j + 1) + ". " + recipes[i].Ingredients[j].ToString(); // assigns value to display
                        }

                        display += "\nSTEPS: "; // displays message to user

                        for (int j = 0; j < recipes[i].Steps.Count; j++)// might change stepsOfRecipe - 1;
                        {
                            display += "\nStep " + (j + 1) + "." + recipes[i].Steps[j].ToString(); // // assigns value to display
                        }

                        display += "\nTHE TOTAL NUMBER OF CALORIES IN THIS RECIPE IS: " + caloriesCalulation(i) + "kcal"; // assigns value to display

                        Console.ForegroundColor = ConsoleColor.Green;  // changes colour of text in console
                        display += "\nRECIPE HAS BEEN DISPLAYED\n"; // displays message to user
                        Console.ResetColor();  // resets colour of text in console
                        break;
                    }
                }
                if (found == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;  // changes colour of text in console
                    display += "\nTHE RECIPE WAS NOT FOUND\n"; // assigns value to display
                    Console.ResetColor();  // resets colour of text in console
                    // Console.WriteLine("THE RECIPE WAS NOT FOUND");
                }
            }
            else if (recipes == null && ingred == null && stepsOfRecipe == null) // else if, checks if array of objects and array is empty
            {
                Console.ForegroundColor = ConsoleColor.Red;  // changes colour of text in console
                display += "THE RECIPE HAS NOT BEEN CREATED \n"; // displays message to user, error message
                Console.ResetColor();  // resets colour of text in console
            }
            return display; // returns display
        }

        public void display(int p) // method used to display recipe
        {
            if (recipes != null && ingred != null && stepsOfRecipe != null) // if statement, checks if the array of object and array is not empty
            {
                Console.WriteLine("Recipe " + (p + 1) + ". " + recipes[p].Name); // display message to user

                Console.WriteLine("\nINGREDIENTS: "); // displays message to user
                for (int j = 0; j < recipes[p].Ingredients.Count; j++)// might change arrIngredient - 1; 
                {
                    Console.WriteLine((j + 1) + ". " + recipes[p].Ingredients[j].ToString()); // displays ingredients
                }

                Console.WriteLine("\nSTEPS: "); // displays message to user
                for (int j = 0; j < recipes[p].Steps.Count; j++)// might change stepsOfRecipe - 1;
                {
                    Console.WriteLine("Step " + (j + 1) + "." + recipes[p].Steps[j].ToString()); // displays steps
                }
                Console.WriteLine("\nTHE TOTAL NUMBER OF CALORIES IN THIS RECIPE IS: " + caloriesCalulation(p) + "kcal"); // display message to user

                Console.ForegroundColor = ConsoleColor.Green;  // changes colour of text in console
                Console.WriteLine("\nRECIPE HAS BEEN DISPLAYED \n"); // displays message to user
                Console.ResetColor();  // resets colour of text in console
            }
            else if (recipes == null && ingred == null && stepsOfRecipe == null) // else if, checks if array of objects and array is empty
            {
                Console.ForegroundColor = ConsoleColor.Red;  // changes colour of text in console
                Console.WriteLine("THE RECIPE HAS NOT BEEN CREATED \n"); // displays message to user, error message
                Console.ResetColor();  // resets colour of text in console
            }
            menu(); // calls method, menu
        }

        public string validationString(string s) // validation method, that calls for a string variable
        {
            while (string.IsNullOrWhiteSpace(s) || !s.All(char.IsLetter)) // while loop
            {
                s = Console.ReadLine(); // collects the value of the s variable the user enters

                if (string.IsNullOrWhiteSpace(s) || !s.All(char.IsLetter)) // if statement, checks if the string is null, a white space or contains numbers
                {
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // changes colour of text in console
                        Console.WriteLine("Invalid input, please enter a valid string value containing only letters:"); // displays message to user, error message
                        Console.ResetColor(); // reset colour of text in console
                    }
                }
            }
            return s; // returns the value of the s variable
        }
        public void resetQuantity()// method used to reset the calories and the quantity back to the original amount
        {
            if (recipes != null && ingred != null && stepsOfRecipe != null) // if statemnt, checks if the array of object and array is not empty
            {
                Console.WriteLine("ALL RECIPES"); // displays message to the user
                for (int i = 0; i < recipes.Count; i++) // for loop
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;  // changes colour of text in console
                    Console.WriteLine((i + 1) + ". " + recipes[i].Name); // displays message to user
                    Console.ResetColor();  // resets colour of text in console
                }

                Console.WriteLine("\nENTER THE NAME OF THE RECIPE YOU WANT TO RESET TO IT'S ORIGINAL QUANTITY: "); // displays message to user
                string findRecipe = " "; // creation and assignment of string variable findRecipe
                findRecipe = validationString(findRecipe); // calls validationString() method and assigns value to recipeName

                Boolean found = false; // creation and assignment of Boolean variable found
                int pos = 0; // creation and assignment of integer variable pos 
                for (int i = 0; i < recipes.Count; i++) // for loop
                {
                    if (recipes[i].Name == findRecipe) // if statement, checks if name of recipe is equal to findRecipe
                    {
                        found = true; // found set to true
                        pos = recipes.IndexOf(recipes[i]); // gets index of findRecipe 
                        for (int j = 0; j < recipes[pos].Ingredients.Count; j++) // for loop
                        {
                            recipes[pos].Ingredients[j].Quantity = org[pos].Quan; // sets quantity back to original value
                            recipes[pos].Ingredients[j].Calories = org[pos].Cal; // sets calories back to original value
                        }
                        display(pos);// calls display() method
                        break;
                    }
                }
                if (found == false) // if statement, checks if found is false
                {
                    Console.ForegroundColor = ConsoleColor.Red;  // changes colour of text in console
                    Console.WriteLine("THE RECIPE WAS NOT FOUND"); // displays message to user
                    Console.ResetColor();  // resets colour of text in console
                }
            }
            else if (recipes == null && ingred == null && stepsOfRecipe == null) // else if, checks if array of objects and array is empty
            {
                Console.ForegroundColor = ConsoleColor.Red;  // changes colour of text in console
                Console.WriteLine("THE RECIPE HAS NOT BEEN CREATED \n"); // displays message to user, error message
                Console.ResetColor();  // resets colour of text in console
            }
            menu(); // calls menu() method
        }
        public void IngredientQuantity()// method used to iether half, double or triple the quantity and calories of a certian recipe
        {
            if (recipes != null && ingred != null && stepsOfRecipe != null) // if statemnt, checks if the array of object and array is not empty
            {
                Console.WriteLine("ALL RECIPES"); // displays message to the user
                for (int i = 0; i < recipes.Count; i++) // for loop
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;  // changes colour of text in console
                    Console.WriteLine((i + 1) + recipes[i].Name); // displays message to user
                    Console.ResetColor();  // resets colour of text in console
                }

                Console.WriteLine("\nENTER THE NAME OF THE RECIPE YOU WANT TO INCREASE IN QUANTITY: "); // displays message to user
                string findRecipe = " "; // creation and assignment of string variable findRecipe
                findRecipe = validationString(findRecipe); // calls validationString() method and assigns value to recipeName

                Boolean found = false; // creation and assignment of Boolean variable found
                int pos = 0; // creation and assignment of integer variable pos

                for (int i = 0; i < recipes.Count; i++) // for loop
                {
                    if (recipes[i].Name == findRecipe) // if statement, checks if name of recipe is equal to findRecipe
                    {
                        found = true; // found set to true
                        pos = recipes.IndexOf(recipes[i]); // gets index of findRecipe
                        Console.WriteLine("\nPLEASE SELECT THE NUMBER, WHETHER YOU WOULD LIKE TO UP SCALE THE RECIPE\n" +
                        "1. HALF\n2. DOUBLE\n3. TRIPLE\n\n"); // display message to user

                        int option;// creates integer variable option
                        while (!int.TryParse(Console.ReadLine(), out option)) // while loop, captures data entered by user and checks if it is int, if it is not it displays an error message
                        {
                            Console.ForegroundColor = ConsoleColor.Red;  // changes colour of text in console
                            Console.WriteLine("Invalid datatype entereed, please enter a valid integer value:"); // display message to user, error message
                            Console.ResetColor();  // resets colour of text in console
                        }

                        switch (option)// switch statment
                        {
                            case 1:
                                for (int j = 0; j < recipes[pos].Ingredients.Count; j++) // for loop
                                {
                                    recipes[pos].Ingredients[j].Quantity = recipes[pos].Ingredients[j].Quantity * 0.5;
                                    recipes[pos].Ingredients[j].Calories = recipes[pos].Ingredients[j].Calories * 0.5;
                                }
                                display(pos); // calls method, displayFullRecipe
                                break;

                            case 2:
                                for (int j = 0; j < recipes[pos].Ingredients.Count; j++) // for loop
                                {
                                    recipes[pos].Ingredients[j].Quantity = recipes[pos].Ingredients[j].Quantity * 2;
                                    recipes[pos].Ingredients[j].Calories = recipes[pos].Ingredients[j].Calories * 2;
                                }
                                display(pos); // calls method, displayFullRecipe
                                break;


                            case 3:
                                for (int j = 0; j < recipes[pos].Ingredients.Count; j++) // for loop 
                                {
                                    recipes[pos].Ingredients[j].Quantity = recipes[pos].Ingredients[j].Quantity * 3;
                                    recipes[pos].Ingredients[j].Calories = recipes[pos].Ingredients[j].Calories * 3;
                                }
                                display(pos); // calls method, displayFullRecipe
                                break;
                        }break;
                    }
                }
                if (found == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;  // changes colour of text in console
                    Console.WriteLine("THE RECIPE WAS NOT FOUND"); // display message to user
                    Console.ResetColor();  // resets colour of text in console
                }
            }
            else if (recipes == null && ingred == null && stepsOfRecipe == null) // else if, checks if lists of objects 
            {
                Console.ForegroundColor = ConsoleColor.Red;  // changes colour of text in console
                Console.WriteLine("\nTHE RECIPE DOES NOT EXSIST \n"); // display message to user, error message
                Console.ResetColor();  // resets colour of text in console
            }
            menu();// calls method, menu

        }
        public void clearRecipe() // clearRecipe method, used to clear the ingredients and steps of the collected
        {

            if (recipes != null && ingred != null && stepsOfRecipe != null) // if statemnt, checks if the lists of object 
            {
                Console.WriteLine("ALL RECIPES");
                for (int i = 0; i < recipes.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;  // changes colour of text in console
                    Console.WriteLine((i + 1) + recipes[i].Name);
                    Console.ResetColor();  // resets colour of text in console
                }

                Console.WriteLine("\nENTER THE NAME OF THE RECIPE YOU WANT DELETE: ");
                string findRecipe = " ";
                findRecipe = validationString(findRecipe); // calls validationString() method and assigns value to recipeName

                Boolean found = false;
                int pos = 0;

                for (int i = 0; i < recipes.Count; i++)
                {
                    if (recipes[i].Name == findRecipe)
                    {
                        found = true;
                        pos = recipes.IndexOf(recipes[i]);
                        recipes.RemoveAt(pos);
                        Console.ForegroundColor = ConsoleColor.Yellow;  // changes colour of text in console
                        Console.WriteLine("THE " + findRecipe + " RECIPE HAS BEEN DELETED");
                        Console.ResetColor();  // resets colour of text in console
                        break;
                    }
                }
                if (found == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;  // changes colour of text in console
                    Console.WriteLine("THE RECIPE WAS NOT FOUND");
                    Console.ResetColor();  // resets colour of text in console
                }
            }
            else if (recipes == null && ingred == null && stepsOfRecipe == null) // else if, checks if array of objects and array is empty
            {
                Console.ForegroundColor = ConsoleColor.Red;  // changes colour of text in console
                Console.WriteLine("\nTHE RECIPE DOES NOT EXSIST \n"); // display message to user, error message
                Console.ResetColor();  // resets colour of text in console
            }
            menu();
        }

        public void menu() // menu method, used to display the options to the user and call the nesscary methods
        {
            Console.WriteLine("\nSELECT A OPTION: \n" + "1. CREATE RECIPE \n" + "2. ALL RECIPES IN ALPHABETICAL ORDER \n" + "3. SEARCH FOR A RECIPE \n" + "4. INCREASE RECIPE SIZE \n" + "5. RESET RECIPE SIZE \n" + "6. DELETE THE RECIPE \n" + "7. EXIT THE PROGRAM \n"); // display message to user
            int option; // creates integer variable option
            while (!int.TryParse(Console.ReadLine(), out option))// while loop, captures data entered by user and checks if it is int, if it is not it displays an error message
            {
                Console.ForegroundColor = ConsoleColor.Red;  // changes colour of text in console
                Console.WriteLine("Invalid datatype entereed, please enter a valid integer value:"); // display message to user, error message
                Console.ResetColor();  // resets colour of text in console
            }

            switch (option) // switch statement
            {
                case 1: createRecipe(); break;
                case 2: displayAlphabeticalOrder(); break;
                case 3: Console.WriteLine(displaySearch()); menu(); break;
                case 4: IngredientQuantity(); break;
                case 5: resetQuantity(); break;
                case 6: clearRecipe(); break;
                case 7: Environment.Exit(0); break;   

                default: 
                    Console.ForegroundColor = ConsoleColor.Red;  // changes colour of text in console 
                    Console.WriteLine("YOUR SELECTION WAS INVALID, PLEASE SELECT AN SUITABLE OPTION\n");
                    Console.ResetColor();  // resets colour of text in console
                    menu(); // calls menu method
                    break; // error message
            }
        }
    }
}
