using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Menu
{
    public class Menu  // CHANGE this class name to "Meal" with properties, constructors, and fields
                       // meal number (#5), meal name, description, list of ingredients, price
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string MealIngredients { get; set; } // should this be an actual list??
        public decimal MealPrice { get; set; }

        public Menu() { } // blank constructor that I don't want but need bc my UI
        public Menu (int mealNumber, string mealName, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealPrice = mealPrice;
        }
        public Menu (int mealNumber, string mealName, string mealDescription, string mealIngredients, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngredients = mealIngredients;
            MealPrice = mealPrice;
        }
    }
}
