using _02_Claims_Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Console
{
    class Claims_ProgramUI
    {
        private ClaimsRepo _claimsList = new ClaimsRepo();

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
                        break;
                    case "3":
                        // update method
                        break;
                    case "4":
                        // enter new claim method
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

            //string test = "steven";
            //string testing = "grootaert";
            //Console.WriteLine("{0,-10}{1,-10}", test, testing);
            List<Claim> listOfClaims = _claimsList.GetClaimList();
                    // string interp of CLAIM01
                    // string interp of CLAIM02
            foreach(Claim claim in listOfClaims)
            {
                Console.WriteLine($"  {claim.ClaimID}".PadRight(8,' ') + $"\t{claim.TypeOfClaim}".PadRight(12, ' ') + $"\t{claim.Description}".PadRight(40, ' ') + $"\t${claim.ClaimAmount}".PadRight(16, ' ') + $"\t{claim.DateOfIncident.ToShortDateString()}".PadRight(18, ' ') + $"\t{claim.DateOfClaim.ToShortDateString()}".PadRight(18, ' ') + $"\t\t{claim.IsValid}\n".PadRight(8, ' '));
            }
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

            _claimsList.AddClaimToList(claim01);
            _claimsList.AddClaimToList(claim02);
            _claimsList.AddClaimToList(claim03);
        }
    }
}
