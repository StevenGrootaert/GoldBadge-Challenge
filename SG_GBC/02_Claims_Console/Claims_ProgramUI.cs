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
            SeedClaimsQueue();
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
                    "3. Enter a new claim\n\n" +
                    "4. Exit Menu Editor\n");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        DisplayClaims();
                        break;
                    case "2":
                        ProcessNextClaim();
                        break;
                    case "3":
                        CreateClaim();
                        break;
                    case "4":
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

            //string test = "steven";
            //string testing = "grootaert";
            //Console.WriteLine("{0,-10}{1,-10}", test, testing);
            Queue<Claim> queueOfClaims = _claimsQueue.GetClaimQueue();
                    // string interp of CLAIM01
                    // string interp of CLAIM02
            foreach(Claim claim in queueOfClaims)
            {
                Console.WriteLine($"  {claim.ClaimID}".PadRight(8,' ') + $"\t{claim.TypeOfClaim}".PadRight(12, ' ') + $"\t{claim.Description}".PadRight(40, ' ') + $"\t${claim.ClaimAmount}".PadRight(16, ' ') + $"\t{claim.DateOfIncident.ToShortDateString()}".PadRight(18, ' ') + $"\t{claim.DateOfClaim.ToShortDateString()}".PadRight(18, ' ') + $"\t\t{claim.IsValid}\n".PadRight(8, ' '));
            }
        }

        private void ProcessNextClaim() // try catch Execption for when claim queue is empty... maybe come back to this
        {
            Console.Clear();
            Claim nextClaim =_claimsQueue.ViewNextClaim();
            Console.WriteLine("The first claim on the queue is:\n");
            Console.WriteLine("Claim ID".PadRight(8, ' ') + "\tType".PadRight(12, ' ') + "\tDescription".PadRight(40, ' ') + "\tAmount".PadRight(16, ' ') + "\tDate of Accident".PadRight(18, ' ') + "\tDate of Claim".PadRight(18, ' ') + "\t\tIs Valid".PadRight(8, ' ') + "\n");
            Console.WriteLine($"  {nextClaim.ClaimID}".PadRight(8, ' ') + $"\t{nextClaim.TypeOfClaim}".PadRight(12, ' ') + $"\t{nextClaim.Description}".PadRight(40, ' ') + $"\t${nextClaim.ClaimAmount}".PadRight(16, ' ') + $"\t{nextClaim.DateOfIncident.ToShortDateString()}".PadRight(18, ' ') + $"\t{nextClaim.DateOfClaim.ToShortDateString()}".PadRight(18, ' ') + $"\t\t{nextClaim.IsValid}\n".PadRight(8, ' '));
            
            Console.WriteLine("\nDo you wish to process this Claim? (y/n)");
            string processClaimString = Console.ReadLine().ToLower();
            if (processClaimString == "y")
            {
                _claimsQueue.ProcessClaim();
            }
            else
            {
                Console.Clear();
                MenuUI();
            }
        }

        //private void UpdateClaim() // this is a lot of UI to write I may not have time to do this esp when I don't think it's needed as per the prompt
        //{

        //}

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

            int isValid = DateTime.Compare(newClaimMadeDate, newClaimIncidentDate);
            if (isValid <= 30)
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            //Console.WriteLine("\nWas the Claim made within 30 Days of the Incident? (y/n)"); // would like to make with automatic with a calculation ^^ see above
            //string isClaimValidString = Console.ReadLine().ToLower();
            //if (isClaimValidString == "y")
            //{
            //    newClaim.IsValid = true;
            //}
            //else
            //{
            //    newClaim.IsValid = false;
            //}

            _claimsQueue.AddClaimToQueue(newClaim);

        }

        private void SeedClaimsQueue()
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

            _claimsQueue.AddClaimToQueue(claim01);
            _claimsQueue.AddClaimToQueue(claim02);
            _claimsQueue.AddClaimToQueue(claim03);
        }
    }
}
