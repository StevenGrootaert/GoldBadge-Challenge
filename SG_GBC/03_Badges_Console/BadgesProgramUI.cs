using _03_Badges_Vault;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console
{
    class BadgesProgramUI
    {
        private BadgeRepo _badgeAccess = new BadgeRepo();
        private BadgeRepo _doorAccess = new BadgeRepo(); // added to try and fix
        private List<Badge> _doorList = new List<Badge>(); // and this is another try I think this might work for the if else door NONe thing
        public void Run()
        {
            SeedBadgeMenu();
            MenuUI();
        }
        private void MenuUI()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("---- Komodo Badge Access Manager ---- \n" +
                    "Type a number to select a menu option:\n\n" +
                    "1. Create a new badge\n\n" +
                    "2. Edit an existing badge\n\n" +
                    "3. List all badges\n\n" +
                    "4. Exit Access Manager\n");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        CreateBadge();
                        break;
                    case "2":
                        Console.Clear();
                        EditBadge();
                        break;
                    case "3":
                        Console.Clear();
                        DisplayAllBadges();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Goodbye.\n");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu option number.");
                        break;
                }
                Console.WriteLine("\nPlease press any key to contiune. . .");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateBadge()
        {
            int badgeID = InputBadgeID();
            var badge = new Badge(badgeID);

            Console.WriteLine("List a door that it needs access to:");
            string inputDoorAdd = Console.ReadLine();
            Console.WriteLine($"adding access to {inputDoorAdd}");
            badge.AddAccess(inputDoorAdd);

            bool keepRunning = true;
            while (keepRunning)
            {
            Console.WriteLine("are there other doors you wish to add? (y/n)");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "y":
                    Console.Clear();
                    EditBadgeDoors(badge);
                    break;
                case "n":
                    Console.Clear();
                    _badgeAccess.AddBadge(badge);
                    MenuUI();
                    break;
                default:
                    Console.WriteLine("Please enter a valid menu option number.");
                    break;
                }
            }
            _badgeAccess.AddBadge(badge);
        }

        private bool AddDoorToBadge(Badge badge)
        {
            Console.WriteLine("which door do you want to add?");
            string doorIDAdd = Console.ReadLine();
            Console.WriteLine($"adding access to {doorIDAdd}");
            return badge.AddAccess(doorIDAdd);
        }

        private int InputBadgeID()
        {
            Console.WriteLine("input a badge ID");
            string input = Console.ReadLine();
            return int.Parse(input);
        }

        private void EditBadgeDoors(Badge badge)
        {
            DisplayBadge(badge);
            // badge 1243 has access to door A2 A3
            Console.WriteLine("What would you like to do?\n" +
                "Type a number to select a menu option:\n\n" +
                "1. Add a door\n\n" +
                "2. Remove a door\n\n" +
                "3. Remove access to ALL doors\n");
            string badgeOperation = Console.ReadLine();
            switch (badgeOperation)
            {
                case "1":
                    AddDoorToBadge(badge);
                    //1.add a door
                    break;
                case "2":
                    //2.remove a door
                    Console.WriteLine("which door do you want to remove?");
                    string doorIDRemove = Console.ReadLine();
                    Console.WriteLine($"removing access to {doorIDRemove}");
                    badge.RemoveAccess(doorIDRemove);
                    break;
                case "3":
                    //3.remove all doors
                    Console.WriteLine($"removing access to ALL doors");
                    badge.RemoveAllAccess();
                    break;
                default:
                    Console.WriteLine($"Don't know what to do with {badgeOperation}.");
                    break;
            }
        }

        // edit all badges to add or remove door access
        private void EditBadge()
        {
            Console.Clear();
            DisplayAllBadges();
            int badgeID = InputBadgeID();
            try
            {
                var badge = _badgeAccess.GetBadge(badgeID);
                EditBadgeDoors(badge);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"could not find badge with ID {badgeID}: {ex.Message}");
            }
        }

        // Display all badges with the doors they access
        private void DisplayAllBadges()
        {
            Console.Clear();
            List<Badge> badges = _badgeAccess.AllBadges();
            foreach(Badge badge in badges)
            {
                DisplayBadge(badge);
            }
        }

        private void DisplayBadge(Badge badge) // if badge has no doors, say have access to NONE. 
        {
            var allDoors = string.Join(", ", badge.AllAccess());
            Console.WriteLine($"\nBadge {badge.BadgeID} has access to {allDoors}\n");
        }

        /*
        private void DisplayBadge(Badge badge)
        {
            if (badge.AllAccess() = false)
            {
                Console.WriteLine($"\nBadge {badge.BadgeID} has access to NONE\n");
            }
            else
            {
            string allDoors = string.Join(", ", badge.AllAccess());
            Console.WriteLine($"\nBadge {badge.BadgeID} has access to {allDoors}\n");
            }
        }
        */

        private void SeedBadgeMenu()
        {
            Badge badge01 = new Badge(98765);
            badge01.AddAccess("A5");
            badge01.AddAccess("A3");
            _badgeAccess.AddBadge(badge01);

            Badge badge02 = new Badge(12345);
            badge02.AddAccess("A4");
            badge02.AddAccess("A2");
            _badgeAccess.AddBadge(badge02);
        }

    }



}
