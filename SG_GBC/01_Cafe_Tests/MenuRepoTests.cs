using _01_Cafe_Menu;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Cafe_Tests
{
    [TestClass]
    public class MenuRepoTests
    {
        [TestMethod]
        public void TestAddItem()
        {
            MenuRepo menuRepo = new MenuRepo();
            Meal testMeal = new Meal();
            Assert.AreEqual(0, menuRepo.GetMenuList().Count);
            //This is what I'm testing compare list before and after
            menuRepo.AddMealToMenu(testMeal);
            Assert.AreEqual(1, menuRepo.GetMenuList().Count);
        }

        [TestMethod]
        public void TestDeleteItem()
        {
            MenuRepo menuRepo = new MenuRepo();
            Meal testOldMeal = new Meal(1, "Fries", "Side order of fries", "potatoes, greese, salt, mayo", 2.50m);
            menuRepo.AddMealToMenu(testOldMeal);
            // ensure meal was added to list
            Assert.AreEqual(1, menuRepo.GetMenuList().Count);
            // test that the meal was removed from list
            string mealName = "Fries";
            menuRepo.GetMenuItemByName(mealName);
            menuRepo.DeleteFromMenu(mealName);
            Assert.AreEqual(0, menuRepo.GetMenuList().Count);
        }

        // I'm not sure how I would test is somthing has been displayed i.e. the read methods

    }
}
