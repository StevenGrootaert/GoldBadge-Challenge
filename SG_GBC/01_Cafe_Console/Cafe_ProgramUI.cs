using _01_Cafe_Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Console
{
    class Cafe_ProgramUI
    {
        private MenuRepo _menuRepo = new MenuRepo();

        public void Run()
        {
            SeedMenuList();
            MenuUI();
        }

        private void MenuUI()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("---- Komodo Cafe Menu Editor ----\n" +
                    "Type a number to select a menu option:\n\n" +
                    "1. Add a new Meal to the Cafe Menu\n\n" +
                    "2. Delete a Meal from the Cafe Menu\n\n" +
                    "3. View the Cafe Menu\n\n" +
                    "4. Exit Menu Editor\n");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreateMenuItem();
                        break;
                    case "2":
                        RemoveMenuItem();
                        break;
                    case "3":
                        DisplayMenu();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye.\n");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu option number.");
                        break;
                }
                Console.WriteLine("\nPlease press any key to contiune. . .");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateMenuItem()
        {
            Console.Clear();
            Meal newMeal = new Meal();

            bool hasValidItemNumber = false;
            while (hasValidItemNumber == false)
            {
            Console.WriteLine("Enter the item number for the meal:");
            string newMealNumAsString = Console.ReadLine();
                try
                {
                newMeal.MealNumber = int.Parse(newMealNumAsString);
                    hasValidItemNumber = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"{ex.Message} Please enter as a numeric number.\n" +
                    "Press enter to try again. . .");
                    Console.ReadLine();
                }
            }

            Console.WriteLine("\nEnter the name of the meal:");
            newMeal.MealName = Console.ReadLine();

            Console.WriteLine("\nEnter the description of the meal:");
            newMeal.MealDescription = Console.ReadLine();

            Console.WriteLine("\nEnter the ingrediants of the meal:");
            newMeal.MealIngredients = Console.ReadLine();

            bool hasValidPriceNumber = false;
            while (hasValidPriceNumber == false)
            {
            Console.WriteLine("\nEnter the price of the meal:");
            string newMealPriceAsString = Console.ReadLine();
            try
            {
            newMeal.MealPrice = decimal.Parse(newMealPriceAsString, System.Globalization.NumberStyles.AllowCurrencySymbol | System.Globalization.NumberStyles.Number);
                    hasValidPriceNumber = true;
            }
                catch(Exception ex)
                {
                    Console.WriteLine($"{ex.Message} please enter as a numeric number.\n" +
                    "Example: 12.34 or $12.34\n"+
                    "Press enter to try again. . .");
                    Console.ReadLine();
                }
            }
            _menuRepo.AddMealToMenu(newMeal);
        }
        private void DisplayMenu()
        {
            Console.Clear();
            List<Meal> listOfMenu = _menuRepo.GetMenuList();
            foreach(Meal menu in listOfMenu)
            {
                Console.WriteLine(
                    $"#{menu.MealNumber}    {menu.MealName}\n"+
                    $"      Description: {menu.MealDescription}\n" +
                    $"      Ingredients: {menu.MealIngredients}\n"+
                    $"      ${menu.MealPrice}\n"
                    );
            }
        }
        private void RemoveMenuItem()
        {
            DisplayMenu();
            Console.WriteLine("\nType the name of the menu item you wish to remove"); //would like to delete by menu number - convert string to int problems
            string input = Console.ReadLine();

            bool wasDeleted = _menuRepo.DeleteFromMenu(input);
            if (wasDeleted)
            {
                Console.WriteLine("The menu item was removed.");
            }
            else
            {
                Console.WriteLine("The menu item wasn't removed! was it entered correctly?");
            }
        }
        private void SeedMenuList()
        {
            Meal clubSandwich = new Meal(1, "Club Sandwich", "For when you want everything", "bread, tomotoes, lettuce, bacon, ham, turkey, mayo, S&P",6.75m);
            Meal bltSandwich = new Meal(2, "BLT", "Classic minimalism as a sandwich", "bread, bacon, lettuce, tomato", 4.50m);

            _menuRepo.AddMealToMenu(clubSandwich);
            _menuRepo.AddMealToMenu(bltSandwich);
        }
    }
}
