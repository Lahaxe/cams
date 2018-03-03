using cams.model.QueryParameters.Filters;
using cams.model.QueryParameters.Pages;
using cams.model.QueryParameters.Sorts;
using cams.model.Users;
using cams.MongoDBConnector.Sessions;
using cams.MongoDBConnector.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

        /// <summary>
        /// Test Constructor.
        /// </summary>
        [TestMethod]
        public void TestUserRepositoryContructor()
        {
            Assert.IsNotNull(Repository);
        }

        /// <summary>
        /// Test function GetUsers without parameters.
        /// </summary>
        [TestMethod]
        public void TestUserRepositoryGetUsers()
        {
            Assert.IsNotNull(Repository);

            var result = Repository.GetUsers("FR_fr", new PagingParameters(), null, null, null);
            Assert.IsNotNull(result);

            Assert.IsNotNull(result.Items);
            Assert.IsNotNull(result.PageIndex);
            Assert.IsNotNull(result.PageSize);
            Assert.IsNotNull(result.TotalNumberOfItems);
            Assert.IsNotNull(result.TotalNumberOfPages);
        }

        /// <summary>
        /// Test function GetUsers with paging parameters.
        /// </summary>
        [TestMethod]
        public void TestUserRepositoryGetUsersPagingParameters()
        {
            Assert.IsNotNull(Repository);

            var result = Repository.GetUsers("FR_fr", new PagingParameters { Index = 1, Size = 2 }, null, null, null);
            Assert.IsNotNull(result);

            Assert.IsNotNull(result.Items);
            Assert.IsNotNull(result.PageIndex);
            Assert.IsNotNull(result.PageSize);
            Assert.IsNotNull(result.TotalNumberOfItems);
            Assert.IsNotNull(result.TotalNumberOfPages);

            Assert.AreEqual(2, (result.Items as List<User>).Count);
            Assert.AreEqual(1, result.PageIndex);
            Assert.AreEqual(2, result.PageSize);

            result = Repository.GetUsers("FR_fr", new PagingParameters { Index = 2, Size = 2 }, null, null, null);
            Assert.IsNotNull(result);

            Assert.IsNotNull(result.Items);
            Assert.IsNotNull(result.PageIndex);
            Assert.IsNotNull(result.PageSize);
            Assert.IsNotNull(result.TotalNumberOfItems);
            Assert.IsNotNull(result.TotalNumberOfPages);

            Assert.AreEqual(2, (result.Items as List<User>).Count);
            Assert.AreEqual(2, result.PageIndex);
            Assert.AreEqual(2, result.PageSize);
        }

        /// <summary>
        /// Test function GetUsers with sorting parameters.
        /// </summary>
        [TestMethod]
        public void TestUserRepositoryGetUsersSortingParameters()
        {
            Assert.IsNotNull(Repository);

            var sorts = new Collection<Sort>();
            sorts.Insert(0, new Sort { Attribute = "name", Direction = SortingDirection.Ascending });

            var result = Repository.GetUsers(
                "FR_fr",
                new PagingParameters(),
                new SortingParameters { Sorts = sorts },
                null,
                null);
            Assert.IsNotNull(result);

            Assert.IsNotNull(result.Items);
            var usersList = result.Items as List<User>;
            Assert.AreEqual("user01", usersList[0].Name);
            Assert.AreEqual("user02", usersList[1].Name);
            Assert.AreEqual("user03", usersList[2].Name);
            Assert.AreEqual("user04", usersList[3].Name);
            Assert.AreEqual("user05", usersList[4].Name);

            sorts = new Collection<Sort>();
            sorts.Insert(0, new Sort { Attribute = "name", Direction = SortingDirection.Descending });

            result = Repository.GetUsers(
                "FR_fr",
                new PagingParameters(),
                new SortingParameters { Sorts = sorts },
                null,
                null);
            Assert.IsNotNull(result);

            Assert.IsNotNull(result.Items);
            usersList = result.Items as List<User>;
            Assert.AreEqual("user01", usersList[4].Name);
            Assert.AreEqual("user02", usersList[3].Name);
            Assert.AreEqual("user03", usersList[2].Name);
            Assert.AreEqual("user04", usersList[1].Name);
            Assert.AreEqual("user05", usersList[0].Name);
        }

        /// <summary>
        /// Test function GetUsers with filtering parameters.
        /// </summary>
        [TestMethod]
        public void TestUserRepositoryGetUsersFilteringParameters()
        {
            Assert.IsNotNull(Repository);

            var filters = new Filter
            {
                Operator = FilterOperator.Equal,
                Value = "user03",
                Attribute = "name"
            };

            var result = Repository.GetUsers(
                "FR_fr",
                new PagingParameters(),
                null,
                new FilteringParameters { Filter = filters },
                null);
            Assert.IsNotNull(result);

            Assert.AreEqual(1, (result.Items as List<User>).Count);
            Assert.AreEqual("user03", (result.Items as List<User>)[0].Name);
        }

        /// <summary>
        /// Test function GetUser.
        /// </summary>
        [TestMethod]
        public void TestUserRepositoryGetUser()
        {
            Assert.IsNotNull(Repository);

            var result = Repository.GetUser("5a9a7e3fbb0d0f8e7382a6e9");
            Assert.IsNotNull(result);
            Assert.AreEqual("user01", result.Name);
        }
    }
}