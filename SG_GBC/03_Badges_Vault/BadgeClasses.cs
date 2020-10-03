using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Vault
{
    public class Badge
    {
        public int BadgeID { get; set; }

        private HashSet<string> doorAccess = new HashSet<string>();
        public bool AddAccess(string doorNumber)
        {
            return doorAccess.Add(doorNumber);
        }

        public bool RemoveAccess(string doorNumber)
        {
            return doorAccess.Remove(doorNumber);
        }

        public List<string> AllAccess()
        {
            return doorAccess.ToList();
        }

        public Badge() { } // blank constructor
        // not forcing the addition of a door access bc it's possible to not have access to any doors
        public Badge(int badgeID)
        {
            BadgeID = badgeID;
        }
    }
}
