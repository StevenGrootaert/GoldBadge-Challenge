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
                    "2. Update an existing claim\n\n" +
                    "3. Enter a new claim\n\n" +
                    "4. Exit Menu Editor\n");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        DisplayClaims();
                        break;
                }
            }
        }

        private void DisplayClaims() // this has to be a table I don't know how to do that.
        {
            Console.Clear();
            List<Claim> listOfClaims = _claimsList.GetClaimList();
            foreach(Claim claim in listOfClaims)
            {
                Console.WriteLine(
                    $"Claim #{claim.ClaimID}\n" +
                    $"Type {claim.TypeOfClaim}\n" +
                    $"Description {claim.Description}\n" +
                    $"Ammount {claim.ClaimAmount}\n" +
                    $"Date of Accident {claim.DateOfIncident}\n" +
                    $"Date of Claim {claim.DateOfClaim}\n" +
                    $"Is Valid {claim.IsValid}"
                    );
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
            Claim claim03 = new Claim(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, dateOfIncident03, dateOfClaim03, true);

            _claimsList.AddClaimToList(claim01);
            _claimsList.AddClaimToList(claim02);
            _claimsList.AddClaimToList(claim03);
        }
    }
}
