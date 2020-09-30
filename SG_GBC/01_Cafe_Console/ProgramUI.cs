using _01_Cafe_Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Console
{
    class ProgramUI
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
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add Meal Item to the Cafe Menu\n" +
                    "2. Delete Meal Item from the Cafe Menu\n" +
                    "3. View Cafe Menu\n");

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
                    default:
                        Console.WriteLine("Please enter a valid menu option number");
                        break;
                }
                Console.WriteLine("\nplease pres any key to contiune. . .");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateMenuItem()
        {
            Console.Clear();
            Menu newMeal = new Menu();

            Console.WriteLine("Enter the item number for the meal:");    // is there a way to auto generate this number? use dictionay or directory?
            string newMealNumAsString = Console.ReadLine();
            newMeal.MealNumber = int.Parse(newMealNumAsString);         //if I enter words not numbers here it breaks

            Console.WriteLine("\nEnter the name of the meal:");
            newMeal.MealName = Console.ReadLine();

            Console.WriteLine("Enter the description of the meal:");
            newMeal.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the ingrediants of the meal:");
            newMeal.MealIngredients = Console.ReadLine();

            Console.WriteLine("\nEnter the price of the meal \n ex 12.75 not $12.75");  //can we accept both?
            string newMealPriceAsString = Console.ReadLine();
            newMeal.MealPrice = decimal.Parse(newMealPriceAsString);

            _menuRepo.AddMealToMenu(newMeal);
        }
        private void DisplayMenu()
        {
            Console.Clear();
            List<Menu> listOfMenu = _menuRepo.GetMenuList();
            foreach(Menu menu in listOfMenu)
            {
                Console.WriteLine(      // work on formatting this
                    $"Meal Number: {menu.MealNumber}\n"+
                    $"Meal Name: {menu.MealName}\n" +
                    $"Meal Description: {menu.MealDescription}\n" +
                    $"Price: ${menu.MealPrice}\n"
                    );
            }
        }
        private void RemoveMenuItem()
        {
            DisplayMenu();
            Console.WriteLine("\nEnter the menu item you wish to remove"); //change helper method to list by menu number
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
            Menu clubSandwich = new Menu(1, "Club Sandwich", "A classic when you want everything", "bread, tomotoes, lettuce, bacon, ham, turkey, mayo, S&P",6.75m);
            Menu bltSandwich = new Menu(2, "BLT", "Classic minimalism as a sandwich", "bread, bacon, lettuce, tomato", 4.50m);

            _menuRepo.AddMealToMenu(clubSandwich);
            _menuRepo.AddMealToMenu(bltSandwich);
        }
    }
}
