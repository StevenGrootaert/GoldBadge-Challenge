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
    }
}
