using cams.model.Users;
using cams.MongoDBConnector.Sessions;
using cams.MongoDBConnector.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cams.Tests.MongoDBConnector.Users
{
    [TestClass]
    public class UserRepositoryTest
    {
        /// <summary>
        /// Gets or sets Session used for all tests.
        /// </summary>
        public static IUserRepository Repository { get; set; }

        /// <summary>
        /// Initializes the test class.
        /// </summary>
        /// <param name="context"></param>
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            var Session = new MongoDBSession();
            Session.Connect();
            Repository = new UserRepository(Session);
        }

        /// <summary>
        /// Initializes each test.
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
        }

        /// <summary>
        /// Cleans each test.
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
        }

        /// <summary>
        /// Cleans the test class.
        /// </summary>
        [ClassCleanup()]
        public static void ClassCleanup()
        {
        }

        [TestMethod]
        public void TestUserRepositoryContructor()
        {
            Assert.IsNotNull(Repository);
        }
    }
}