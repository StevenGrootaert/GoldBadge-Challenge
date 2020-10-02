using _02_Claims_Department;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Console
{
    class Claims_ProgramUI
    {
        private ClaimsRepo _claimsQueue = new ClaimsRepo();

        public void Run()
        {
            SeedClaimsList();
            MenuUI();
        }

        private void MenuUI()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("---- Komodo Claims Department Editor ----\n" +
                    "Type a number to select a menu option:\n\n" +
                    "1. View all claims\n\n" +
                    "2. Process next claim\n\n" +
                    "3. Update an existing claim\n\n" +
                    "4. Enter a new claim\n\n" +
                    "5. Exit Menu Editor\n");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        DisplayClaims();
                        break;
                    case "2":
                        // bring up next claim in queue
                        NextClaim();
                        break;
                    case "3":
                        // update method
                        UpdateClaim();
                        break;
                    case "4":
                        // enter new claim method
                        CreateClaim();
                        break;
                    case "5":
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
        private void DisplayClaims() // this is formated to look like a table.
        {
            Console.Clear();
            Console.WriteLine("Claim ID".PadRight(8, ' ') + "\tType".PadRight(12, ' ') + "\tDescription".PadRight(40, ' ') + "\tAmount".PadRight(16, ' ') + "\tDate of Accident".PadRight(18, ' ') + "\tDate of Claim".PadRight(18, ' ') + "\t\tIs Valid".PadRight(8, ' ') + "\n");

            string test = "steven";
            string testing = "grootaert";
            Console.WriteLine("{0,-10}{1,-10}", test, testing);
            Queue<Claim> listOfClaims = _claimsQueue.GetClaimList();
                    // string interp of CLAIM01
                    // string interp of CLAIM02
            foreach(Claim claim in listOfClaims)
            {
                Console.WriteLine($"  {claim.ClaimID}".PadRight(8,' ') + $"\t{claim.TypeOfClaim}".PadRight(12, ' ') + $"\t{claim.Description}".PadRight(40, '.') + $"\t${claim.ClaimAmount}".PadRight(16, ' ') + $"\t{claim.DateOfIncident.ToShortDateString()}".PadRight(18, ' ') + $"\t{claim.DateOfClaim.ToShortDateString()}".PadRight(18, ' ') + $"\t\t{claim.IsValid}\n".PadRight(8, ' '));
            }
        }

        private void NextClaim()
        {
            // this will have somthing to do with the queue collection type. put claims made with the class and put them in here?
        }

        private void UpdateClaim()
        {

        }

        private void CreateClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            bool hasValidClaimID = false;
            while (hasValidClaimID == false)
            {
                Console.WriteLine("Enter the claim number for this incident:");
                string newClaimNumAsString = Console.ReadLine();
                try
                {
                    newClaim.ClaimID = int.Parse(newClaimNumAsString);
                    hasValidClaimID = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"{ex.Message} Please enter as a numeric number.\n"+
                    "Press enter to try again. . .");
                    Console.ReadLine();
                }
            }

            Console.WriteLine("\nEnter the Type of incident by entering the corrisponding number:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft" );
            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newClaim.TypeOfClaim = (ClaimType)claimTypeAsInt;

            Console.WriteLine("\nEnter the decription of the incident:\n");
            newClaim.Description = Console.ReadLine();

            bool hasVaildClaimAmountNumber = false;
            while (hasVaildClaimAmountNumber == false)
            {
            Console.WriteLine("\nEnter the claim amount (including cents):\n"+
                "Example format 1234.00\n");
                string newClaimAmountString = Console.ReadLine();
                try
                {
                    newClaim.ClaimAmount = decimal.Parse(newClaimAmountString, System.Globalization.NumberStyles.AllowCurrencySymbol | System.Globalization.NumberStyles.Number);
                    hasVaildClaimAmountNumber = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"{ex.Message} please enter as a numeric number.\n" +
                        "Example: 12.34 or $12.34\n" +
                        "Press enter to try again. . .");
                    Console.ReadLine();
                }

            }

            Console.WriteLine("\nEnter the 4 digit YEAR, 2 digit Month, 2 digit DAY the Incident took place:\n");
            string newClaimDateIncidentString = Console.ReadLine();
            DateTime newClaimIncidentDate = DateTime.Parse(newClaimDateIncidentString);
            newClaim.DateOfIncident = newClaimIncidentDate;

            Console.WriteLine("\nEnter the 4 digit YEAR, 2 digit Month, 2 digit DAY the Claim was made:\n");
            string newClaimDateMadeString = Console.ReadLine();
            DateTime newClaimMadeDate = DateTime.Parse(newClaimDateMadeString);
            newClaim.DateOfClaim = newClaimMadeDate;


            //if (newClaimMadeDate - newClaimIncidentDate <= DateTime. 
            int isValid = DateTime.Compare(newClaimMadeDate, newClaimIncidentDate);
            if (isValid <= 30)
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            //Console.WriteLine("\nWas the Claim made within 30 Days of the Incident? (y/n)"); // would like to make with automatic with a TimeSpan calc..
            //string isClaimValidString = Console.ReadLine().ToLower();
            //if (isClaimValidString == "y")
            //{
            //    newClaim.IsValid = true;
            //}
            //else
            //{
            //    newClaim.IsValid = false;
            //}

            _claimsQueue.AddClaimToList(newClaim);

            //Console.WriteLine("\n Enter the 4 digit YEAR the incident took place.\n");
            //string newClaimYearString = Console.ReadLine();
            //DateTime newClaimYearInt = DateTime.Parse(newClaimYearString);

            //Console.WriteLine("\n Enter the 2 digit MONTH the incident took place.\n");
            //string newClaimMonthString = Console.ReadLine();
            //DateTime newClaimMonthInt = DateTime.Parse(newClaimMonthString);

            //Console.WriteLine("\n Enter the 2 digit DAY the incident took place.\n");
            //string newClaimDayString = Console.ReadLine();
            //DateTime newClaimDayInt = DateTime.Parse(newClaimDayString);


            //Console.WriteLine("\n Enter the 4 digit YEAR the incident took place.\n");
            //string newClaimYearString = Console.ReadLine();
            //int newClaimYearInt = int.Parse(newClaimYearString);

            //Console.WriteLine("\n Enter the 2 digit MONTH the incident took place.\n");
            //string newClaimMonthString = Console.ReadLine();
            //int newClaimMonthInt = int.Parse(newClaimMonthString);

            //Console.WriteLine("\n Enter the 2 digit DAY the incident took place.\n");
            //string newClaimDayString = Console.ReadLine();
            //int newClaimDayInt = int.Parse(newClaimDayString);

            //newClaim.DateOfIncident = new DateTime(newClaimYearInt, newClaimMonthInt, newClaimDayInt);

        }

        private void SeedClaimsList()
        {
            DateTime dateOfIncident01 = new DateTime(2018, 04, 25);
            DateTime dateOfClaim01 = new DateTime(2018, 04, 27);
            Claim claim01 = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00m, dateOfIncident01, dateOfClaim01, true);

            DateTime dateOfIncident02 = new DateTime(2018, 04, 11);
            DateTime dateOfClaim02  = new DateTime(2018, 04, 12);
            Claim claim02 = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, dateOfIncident02, dateOfClaim02, true);

            DateTime dateOfIncident03 = new DateTime(2018, 04, 27);
            DateTime dateOfClaim03 = new DateTime(2018, 06, 01);
            Claim claim03 = new Claim(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, dateOfIncident03, dateOfClaim03, false);

            _claimsQueue.AddClaimToList(claim01);
            _claimsQueue.AddClaimToList(claim02);
            _claimsQueue.AddClaimToList(claim03);
        }
    }
}
