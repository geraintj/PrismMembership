using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PrismMembership.Data;

namespace PrismMembership.Services.Tests
{
    [TestClass]
    public class MembershipServiceTests
    {
        [TestMethod]
        public void GetAllMembershipsTest()
        {
            var mockRepo = new Mock<IRepo<Membership>>();
            mockRepo.Setup(m => m.All()).Returns(Enumerable.Range(1,10).Select(i => new Membership() { FID = i.ToString()}));

            var service = new MembershipService(mockRepo.Object);

            Assert.AreEqual(10, service.GetAllMemberships().Count());
        }

        [TestMethod]
        public void SearchMembershipsTest()
        {
            var mockRepo = new Mock<IRepo<Membership>>();
            mockRepo.Setup(m => m.Query(It.IsAny<Expression<Func<Membership, bool>>>()))
                .Returns(new List<Membership>()
                {
                    new Membership() {FID = "One", Surname = "NameOne"},
                    new Membership() {FID = "Two", Surname = "NameTwo"}
                });

            var service = new MembershipService(mockRepo.Object);

            var results = service.SearchMemberships("Name");
            
            Assert.AreEqual(2, results.Count());
            Assert.IsTrue(results.First().Surname.StartsWith("Name"));
        }

        [TestMethod]
        public void GetMembershipTest()
        {
            var mockRepo = new Mock<IRepo<Membership>>();
            mockRepo.Setup(m => m.Single(It.IsAny<Expression<Func<Membership, bool>>>()))
                .Returns(new Membership() {FID = "One", Surname = "Name"});

            var service = new MembershipService(mockRepo.Object);

            Assert.AreEqual("One", service.GetMembership("One").FID);
        }
    }
}
