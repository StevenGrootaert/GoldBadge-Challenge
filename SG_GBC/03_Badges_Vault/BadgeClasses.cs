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

        private HashSet<string> _doorAccess = new HashSet<string>();
        public bool AddAccess(string doorNumber)
        {
            return _doorAccess.Add(doorNumber);
        }

        public bool RemoveAccess(string doorNumber)
        {
            return _doorAccess.Remove(doorNumber);
        }

        public void RemoveAllAccess()
        {
            _doorAccess = new HashSet<string>();
        }

        public List<string> AllAccess()
        {
            return _doorAccess.ToList();
        }

        public Badge() { } // blank constructor
        // not forcing the addition of a door access bc it's possible for a badgeID to not have access to any doors
        public Badge(int badgeID)
        {
            BadgeID = badgeID;
        }
    }
}
