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

        }

        private void SeedClaimsList()
        {
            DateTime dateOfIncident = new DateTime(2018, 04, 27);
            DateTime dateOfClaim = new DateTime(2018, 04, 29);  //rename?? dateOfClaim to something almost like it
            Claim claim01 = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00m, dateOfIncident, dateOfClaim, true);
        }
    }
}
