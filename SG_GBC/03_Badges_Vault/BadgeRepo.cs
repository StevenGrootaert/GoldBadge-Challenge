using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Vault
{
    public class BadgeRepo // where the dictionary/list of badges will be stored 
    {
        // we need something like this:
        private Dictionary<int, Badge> _badges = new Dictionary<int, Badge>();
        
        public void AddBadge(Badge badge)
        {
            // bridge/map between the BadgeID and the Badge; this allows to get badge by its ID
            _badges[badge.BadgeID] = badge;
        }

        public List<Badge> AllBadges()
        {
            // x => x.Value is a shorthand for a function
            // that takes x as an input and returns x.Value
            return _badges.Select(x => x.Value).ToList();
        }
       
        public Badge GetBadge(int badgeID)
        {
            Badge badge;
            
            if (_badges.TryGetValue(badgeID, out badge)) // gets value associated with badgeID key
            {
                return badge;
            }
            else
            {
                // if the badge doesn't exist, throw an exception
                throw new Exception($"badge {badgeID} not found in list: {string.Join(", ", _badges.Keys.ToString())}");
            }
        }
    }
}
