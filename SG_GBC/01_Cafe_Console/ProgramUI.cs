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
                    "1. Add Meal Item to the Cafe Menu" +
                    "2. Delete Meal Item from the Cafe Menu" +
                    "3. View Cafe Menu");

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
                Console.WriteLine("please pres any key to contiune. . .");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateMenuItem()
        {
            Console.Clear();
            Menu newMeal = new Menu();

            Console.WriteLine("Enter the item number for the Meal:");    // is there a way to auto generate this number? use dictionay or directory?
            string newMealNumAsString = Console.ReadLine();
            newMeal.MealNumber = Convert.ToDecimal(newMealNumAsString); // why not?!

            //string newMeal.MealNumber = Console.ReadLine();
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
