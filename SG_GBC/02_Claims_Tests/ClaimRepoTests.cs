using _02_Claims_Department;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Claims_Tests
{
    [TestClass]
    public class ClaimRepoTests
    {
        [TestMethod]
        public void TestAddToQueue()
        {
            ClaimsRepo claimsRepo = new ClaimsRepo();
            Claim testClaim = new Claim();
            Assert.AreEqual(0, claimsRepo.GetClaimQueue().Count);
            claimsRepo.AddClaimToQueue(testClaim);
            Assert.AreEqual(1, claimsRepo.GetClaimQueue().Count);
        }

        [TestMethod]
        public void TestProcessClaim()
        {
            ClaimsRepo claimsRepo = new ClaimsRepo();

            DateTime dateOfIncident01 = new DateTime(2018, 04, 25);
            DateTime dateOfClaim01 = new DateTime(2018, 04, 27);
            Claim testClaim01 = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00m, dateOfIncident01, dateOfClaim01, true);
            claimsRepo.AddClaimToQueue(testClaim01);
            // ensuring claim was added to queue before testing dequeue
            Assert.AreEqual(1, claimsRepo.GetClaimQueue().Count);
            // testing that dequeue removed the one added claim from queue
            claimsRepo.ProcessClaim();
            Assert.AreEqual(0, claimsRepo.GetClaimQueue().Count);
        }

        // I'm not sure how I would test is somthing has been displayed i.e. the read methods
    }
}
