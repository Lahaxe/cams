using cams.model.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cams.Tests.Model.Users
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestUserContructor()
        {
            var user = new User();

            Assert.IsNotNull(user);
            Assert.IsNull(user.Id);
            Assert.IsNull(user.Name);
        }

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
