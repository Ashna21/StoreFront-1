using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreFrontDal;
using System.Linq;

namespace StoreFront.Data.Tests
{
    [TestClass]
    public class UserTests
    {

        private const string TestUserPrefix = "Test User";

        [ClassCleanup]
        public static void CleanUp()
        {
            using (var context = new StoreFrontRepository())
            {
                var users = context.GetUsers();
                foreach(var user in users.Where(x => x.UserName.StartsWith(TestUserPrefix))){
                    context.DeleteUser(user.UserID);
                }
            }
        }

        [TestMethod]
        public void InsertUser()
        {
            //Arrange
            using (var context = new StoreFrontRepository())
            {
                var users = context.GetUsers();
                var newUserName = TestUserPrefix + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                var countPrevious = users.Count(x => x.UserName == newUserName);

                //Act
                context.InsertUser(newUserName, "testAddress", false, "Unit Test");

                //Assert
                users = context.GetUsers();
                var countAfter = users.Count(x => x.UserName == newUserName);
                Assert.AreNotEqual(countPrevious, countAfter, "Number of users prior to insert is equal to number of users after insert.");
            }
        }

        [TestMethod]
        public void GetUsers()
        {
            //Arrange
            using (var context = new StoreFrontRepository()){

                //Act
                var results = context.GetUsers();

                //Assert
                Assert.IsTrue(results.Count > 0, "No users were returned from the database.");
            }
        }

        [TestMethod]
        public void UpdateUser()
        {
            using (var context = new StoreFrontRepository())
            {
                var newUserName = TestUserPrefix + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                context.InsertUser(newUserName, "", false, "Unit Test");

                var user = context.GetUsers().Single(x => x.UserName == newUserName);

                var newerUserName = TestUserPrefix + DateTime.Now.ToString("yyyyMMdd_HHmmss") + " Updated";

                context.UpdateUser(user.UserID, newerUserName, user.EmailAddress, user.IsAdmin ?? false, "Unit Test Update");

                user = context.GetUsers().Single(x => x.UserName == newerUserName);

                Assert.IsNotNull(user, "Couldn't find updated user.");
            }
        }
    }
}
