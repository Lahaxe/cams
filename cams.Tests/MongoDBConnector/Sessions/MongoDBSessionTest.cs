using cams.MongoDBConnector.Sessions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cams.Tests.MongoDBConnector.Sessions
{
    [TestClass]
    public class MongoDBSessionTest
    {
        /// <summary>
        /// Gets or sets Session used for all tests.
        /// </summary>
        public static IMongoDBSession Session { get; set; }

        /// <summary>
        /// Initializes the test class.
        /// </summary>
        /// <param name="context"></param>
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            Session = new MongoDBSession();
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

        /// <summary>
        /// Test Constructor.
        /// </summary>
        [TestMethod]
        public void TestMongoDBSessionContructor()
        {
            Assert.IsNotNull(Session);
        }

        /// <summary>
        /// Test function Connect.
        /// </summary>
        [TestMethod]
        public void TestMongoDBSessionConnect()
        {
            Session.Connect();
        }
    }
}