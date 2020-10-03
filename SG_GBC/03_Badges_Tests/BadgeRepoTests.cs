using _03_Badges_Vault;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badges_Tests
{
    [TestClass]
    public class BadgeRepoTests
    {
        [TestMethod]
        public void TestAddBadge()
        {
            BadgeRepo badgeRepo = new BadgeRepo();
            Badge testBadge = new Badge();
            Assert.AreEqual(0, badgeRepo.AllBadges().Count);
            badgeRepo.AddBadge(testBadge);
            Assert.AreEqual(1, badgeRepo.AllBadges().Count);
        }

        // not even sure how to test GetBadge in BadgeRepo
    }
}
