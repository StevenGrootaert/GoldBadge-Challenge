using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Menu
{
    public class MenuRepo
    {
        private List<Menu> _menuList = new List<Menu>();

        public void AddMealToMenu(Menu item)
        {
            _menuList.Add(item);
        }

        public List<Menu> GetMenuList()
        {
            return _menuList;
        }

        public bool DeleteFromMenu(string mealName)
        {
            Menu menu = GetMenuItemByName(mealName);
            if(mealName == null)
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

        //helper for delete method
        public Menu GetMenuItemByName(string mealName)
        {
            foreach(Menu menu in _menuList)
            {
                if(menu.MealName.ToLower() == mealName.ToLower())
                {
                    return menu;
                }
            }

            return null;
        }
    }
}
