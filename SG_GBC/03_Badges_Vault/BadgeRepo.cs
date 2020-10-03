using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Vault
{
    public class BadgeRepo // where the list of badges will be stored
    {
        // do we need a door list? 
       //private List<Badge> _doorList = new List<Badge>();

        // seems like we'd need something like this:
        private Dictionary<int, Badge> _badges = new Dictionary<int, Badge>();
        
        public void AddBadge(Badge badge)
        {
            // just to be clear, we are creating a bridge
            // between the BadgeID and the Badge; this allows
            // us to do is to easily get a badge by its ID
            _badges[badge.BadgeID] = badge;
        }

        public List<Badge> AllBadges()
        {
            // x => x.Value is a shorthand for a function
            // that takes x as an input and returns x.Value
            return _badges.Select(x => x.Value).ToList();
        }
        /*
            var repo = new BadgeRepo();
            // repo is populated here
            var badge = repo.GetBadge(someBadgeID);
            var allAccess = string.Join(", ", badge.AllAccess());
            Console.WriteLine($"badge {badge.BadgeID} has access to {allAccess}");
        */
        // remove ALL doors from a badge
        //public void RemoveAllDoorsFromBadge(int badgeID)
        //{
        //    var badge = GetBadge(badgeID);
        //    badge.RemoveAllAccess();
        //}
        //public bool RemoveDoorFromBadge(int badgeID, string doorID)
        //{
        //    var badge = GetBadge(badgeID);
        //    return badge.RemoveAccess(doorID);
        //}

       

        public Badge GetBadge(int badgeID)
        {
            Badge badge;
            
            if (_badges.TryGetValue(badgeID, out badge))
            {
                return badge;
            }
            else
            {
                // if the badge doesn't exist, throw an exception
                throw new Exception($"badge {badgeID} not found in list: {string.Join(", ", _badges.Keys.ToString())}");
            }
        }


        // remove doors from a badge ID (one at a time by door name)
                

        /*
            // IN THE UI

            // user story: I want to grant access to a door to a specific badge
            // 1) I need to have my badge repo set up
            var badgeRepo = new BadgeRepo();
            // 2) I need to ensure that a badge with a given ID exists
            // question: what happens if a badge with the given badge ID does not exist? should it be created?
            var badge = badgeRepo.GetBadge(badgeID);
        */

    }
}
