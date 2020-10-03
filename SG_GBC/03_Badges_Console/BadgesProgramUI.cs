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
            Console.WriteLine($"adding access to {inputDoorAdd}\n");
            badge.AddAccess(inputDoorAdd);

            bool keepRunning = true;
            while (keepRunning)
            {
            Console.WriteLine("Are there other doors you wish to add? (y/n)");
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
            Console.WriteLine($"adding access to {doorIDAdd}\n");
            return badge.AddAccess(doorIDAdd);
        }

        private int InputBadgeID()
        {
            Console.WriteLine("input a badge ID #"); // if not a number that can be parsed Ex throws.. 
            string input = Console.ReadLine();
            return int.Parse(input);
        }

        /* . . . I can't get this Try Catch to work in my current state
        private int InputBadgeID() // not all code paths return value 
            
        {
            bool hasValidBadgeID = false;
            while (hasValidBadgeID == false)
            {
                Console.WriteLine("input a badge ID #");
                string stringInput = Console.ReadLine();
                try
                {
                    return int.Parse(stringInput);
                    hasValidBadgeID = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"{ex.Message} Please enter as a numeric number.\n" +
                    "Press enter to try again. . .");
                    Console.ReadLine();
                }
            }
        }
        */

        private void EditBadgeDoors(Badge badge)
        {
            DisplayBadge(badge);
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
                    Console.WriteLine($"removing access to {doorIDRemove}\n");
                    badge.RemoveAccess(doorIDRemove);
                    break;
                case "3":
                    //3.remove all doors
                    Console.WriteLine($"removing access to ALL doors");
                    badge.RemoveAllAccess();
                    break;
                default:
                    Console.WriteLine("Please enter a valid menu option number."); // return to maain try to return to this menu withou looping?
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
            catch
            {
                Console.WriteLine($"could not find badge with ID {badgeID}");
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

        private void DisplayBadge(Badge badge)
        {
            var allDoors = string.Join(", ", badge.AllAccess());
            bool allDoorsBool = string.IsNullOrEmpty(allDoors);
            if (allDoorsBool == true)
            {
                Console.WriteLine($"\nBadge ID # {badge.BadgeID} doesn't have access to ANY door\n");
            }
            else
            {
            Console.WriteLine($"\nBadge ID #{badge.BadgeID} has access to doors: {allDoors}\n");
            }
        }

        private void SeedBadgeMenu()
        {
            Badge badge01 = new Badge(12345);
            badge01.AddAccess("A7");
            _badgeAccess.AddBadge(badge01);

            Badge badge02 = new Badge(22345);
            badge02.AddAccess("A1");
            badge02.AddAccess("A4");
            badge02.AddAccess("B1");
            badge02.AddAccess("B2");
            _badgeAccess.AddBadge(badge02);

            Badge badge03 = new Badge(32345);
            badge03.AddAccess("A4");
            badge03.AddAccess("A5");
            _badgeAccess.AddBadge(badge03);
        }

    }



}
