using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Menu
{
    public class MenuRepo
    {
        private List<Meal> _menuList = new List<Meal>();

        public void AddMealToMenu(Meal item)
        {
            _menuList.Add(item);
        }

        public List<Meal> GetMenuList()
        {
            return _menuList;
        }

        public bool DeleteFromMenu(string mealName)
        {
            Meal menu = GetMenuItemByName(mealName);
            if (mealName == null)
            {
                return false;
            }
            int intialCount = _menuList.Count;
            _menuList.Remove(menu);

            if (intialCount > _menuList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //  helper methods
        public Meal GetMenuItemByName(string mealName)
        {
            foreach (Meal menu in _menuList)
            {
                if (menu.MealName.ToLower() == mealName.ToLower())
                {
                    return menu;
                }
            }
            return null;
        }

        // DELETE method for delete by number -- not working out so well)
        //public bool DeleteFromMenu(int mealNumber)
        //{
        //    Meal menu = GetMenuItemByNumber(mealNumber);
        //    if (mealNumber == null)
        //    {
        //        return false;
        //    }
        //    int intialCount = _menuList.Count;
        //    _menuList.Remove(menu);

        //    if (intialCount > _menuList.Count)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        // helper for delete method (get by number -- not working out so well)
        //public Meal GetMenuItemByNumber(int mealNumber)
        //{
        //    foreach(Meal menu in _menuList)
        //    {
        //        if(menu.MealNumber == mealNumber)
        //        {
        //            return menu;
        //        }
        //    }
        //    return null;
        //}

        //helper for delete method (get by name)
    }
}
