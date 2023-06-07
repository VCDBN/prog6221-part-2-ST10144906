# POE PART 2

RECIPE APPILCATION

This application is a consosole application/command-line application built using C# in Visual Studio. The application allows the use to create, store, increase, display and delete recipes.

USAGE
Here are the basic steps to use the application:

Once the program runs a menu will be displayed providing the suer with 7 options 
"SELECT A OPTION:
1. CREATE RECIPE
2. ALL RECIPES IN ALPHABETICAL ORDER
3. SEARCH FOR A RECIPE
4. INCREASE RECIPE SIZE
5. RESET RECIPE SIZE
6. DELETE THE RECIPE
7. EXIT THE PROGRAM"

Option 1 "CREATE RECIPE"
Enter the name of the recpie
Enter the number of ingredients for the recipe.
For each ingredient, provide the name, quantity,unit of measurement, calories and foodgroup.
Enter the number of steps for the recipe.
For each step, provide a description of what the user should do.
If all the data entered meets the validation standard the recipe will be captured and stored in the List of recipe objects

Option 2 "ALL RECIPES IN ALPHABETICAL ORDER"
Displays a lsit of all the recipes in alphabetical order in a neat structure to the user.

Option 3 "SEARCH FOR A RECIPE"
A lsit will be displayed to you of all the recipes stored in the program.
Enter the name of the recipe you want to search for
The recipe will be displayed to you in a neat structure

Option 4 "INCREASE RECIPE SIZE"
A lsit will be displayed to you of all the recipes stored in the program.
Enter the name of the recipe you want to increase the quantity for
A menu such as this will be displayed
"
PLEASE SELECT THE NUMBER, WHETHER YOU WOULD LIKE TO UP SCALE THE RECIPE
1. HALF
2. DOUBLE
3. TRIPLE"
Select the number based on whether you want to half, double or triple the quantity of the recipe.
The recipe will be displayed to you after accordingly in a neat structure
NOTE: as you increase the quantity or decrease the quantity the calories of the ingredients will increase and decrease accordingly.

Option 5 "RESET RECIPE SIZE"
A lsit will be displayed to you of all the recipes stored in the program.
Enter the name of the recipe you want to reset the quantity for
The recipe will be displayed to you after accordingly in a neat structure
NOTE: The quantity and calories will be reset to the original amount
 
Option 6 "DELETE THE RECIPE"
A lsit will be displayed to you of all the recipes stored in the program.
Enter the name of the recipe you want to delete
A confirmation message will be displayed after

Option 7 "EXIT THE PROGRAM"
The program will close

CHANGELOG

1. The menu has been updated providing more options to the user.
2. More colour was incoporated into the application. Colour was used for error and confirmation messages when possible to make it more user-friendly.
3. The reseting of quantites was done using it's own method versus before when oit was doen using the IngredientIncrease method.

ADDITINAL FEATURES
The following features have been added to the application in addition to the previously introduced features and the current functionalities:

1. An infinite number of different recipes
Users can now enter an infinite number of recipes into the application. Within the application, users may create and manage multiple recipes.

2. Name of Recipe
Each recipe that users create can have a name. The application asks users to submit a name for the recipe when adding a new one, making it simpler to locate and choose particular recipes. Each name must be unique.

3. An alphabetical list of recipes
The recipes are displayed in alphabetical order according to the names of the recipes.

4. Choose a recipe from the menu from the menu to display 
From the list of recipes, users can select which one to display. The user is shown a list of recipes by the application, and they are asked to choose the name of the recipe they want to be displayed. 

5. Further Ingredient Information
Users can now enter additional data for each ingredient, such as:
The caloric amount
The food group

6. Calorie Total Calculation
The calories in each ingredient of a recipe are calculated by the program and shown. The application computes and displays the total amount of calories for the entire recipe once the user enters the ingredient information, including the calories for each item.

7. Warning for Going Over 300 Calories
The software has a notice feature that notifies the user when a recipe has more calories than 300. The app alerts the user with a message in order to notify them.
