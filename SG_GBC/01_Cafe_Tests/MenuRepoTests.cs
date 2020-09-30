using _01_Cafe_Menu;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Cafe_Tests
{
    [TestClass]
    public class MenuRepoTests  //no idea how to do this yet. build out the other apps today and be ready with questions 
    {
        [TestMethod]
        public void TestAddItem()
        {
            MenuRepo menuRepo = new MenuRepo();
            Meal testMeal = new Meal();
            Assert.AreEqual(0, menuRepo.GetMenuList().Count);
            //This is what I'm testing compair list before and after
            menuRepo.AddMealToMenu(testMeal);
            Assert.AreEqual(1, menuRepo.GetMenuList().Count);
        }
    }
}
