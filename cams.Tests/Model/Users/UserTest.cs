using cams.model.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cams.Tests.Model.Users
{
    /// <summary>
    /// Defines unit tests for <see cref="User"/>.
    /// </summary>
    [TestClass]
    public class UserTest
    {
        /// <summary>
        /// Test Constructor.
        /// </summary>
        [TestMethod]
        public void TestUserContructor()
        {
            var user = new User();

            Assert.IsNotNull(user);
            Assert.IsNull(user.Id);
            Assert.IsNull(user.Name);
        }

        /// <summary>
        /// Test Getters and setters.
        /// </summary>
        [TestMethod]
        public void TestUserGetAndSet()
        {
            var user = new User { Id = "userId", Name = "userName" };
            Assert.IsNotNull(user);

            Assert.AreEqual(user.Id, "userId");
            Assert.AreEqual(user.Name, "userName");

            user.Id = "newUserId";
            user.Name = "newUserName";

            Assert.AreEqual(user.Id, "newUserId");
            Assert.AreEqual(user.Name, "newUserName");
        }
    }
}