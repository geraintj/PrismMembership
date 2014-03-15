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
    public class MemberServiceTests
    {
        [TestMethod]
        public void GetAllMembersTest()
        {
            var mockRepo = new Mock<IRepo<Member>>();
            mockRepo.Setup(m => m.All()).Returns(Enumerable.Range(1, 10).Select(i => new Member() { FID = i.ToString() }));

            var service = new MemberService(mockRepo.Object);

            Assert.AreEqual(10, service.GetAllMembers().Count());
        }

        [TestMethod]
        public void GetMembersForMembershipTests()
        {
            var mockRepo = new Mock<IRepo<Member>>();
            mockRepo.Setup(m => m.Query(It.IsAny<Expression<Func<Member, bool>>>()))
                .Returns(new List<Member>()
                {
                    new Member() {FID = "One", PID = "One", Surname = "Name"},
                    new Member() {FID = "One", PID="Two", Surname = "Name"}
                });

            var service = new MemberService(mockRepo.Object);

            var results = service.GetMembersForMembership("One");

            Assert.AreEqual(2, results.Count());
            Assert.IsTrue(results.First().FID == "One");
        }

        [TestMethod]
        public void GetMemberTest()
        {
            var mockRepo = new Mock<IRepo<Member>>();
            mockRepo.Setup(m => m.Single(It.IsAny<Expression<Func<Member, bool>>>()))
                .Returns(new Member() {FID = "One", PID = "Two", Surname = "Name"});

            var service = new MemberService(mockRepo.Object);

            Assert.AreEqual("Two", service.GetMember("One", "Two").PID);
        }
    }

}
