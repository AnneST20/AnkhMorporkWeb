using AnkhMorporkWeb.Models;
using AnkhMorporkWeb.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AnkhMorporkWeb.Tests.RepositoryTests
{
    [TestClass]
    public class AssassinsRepositoryTests
    {
        private Mock<DbSet<Assassin>> MockSet()
        {
            var data = new List<Assassin>
            {
                new Assassin { Id = 1, MinReward = 1, MaxReward = 5, IsActive = true},
                new Assassin { Id = 2, MinReward = 1, MaxReward = 10, IsActive = true },
                new Assassin { Id = 3, MinReward = 5, MaxReward = 10, IsActive = false },
            };
            
            var queryable = data.AsQueryable();

            var mockSet = new Mock<DbSet<Assassin>>();
            mockSet.As<IQueryable<Assassin>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<Assassin>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<Assassin>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<Assassin>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            mockSet.Setup(d => d.Add(It.IsAny<Assassin>())).Callback<Assassin>((s) => data.Add(s));

            return mockSet;
        }

        [TestMethod]
        public void GetAll_Returns_List()
        {
            var mockSet = MockSet();

            var mockContext = new Mock<GameContext>();
            mockContext.Object.Assassins = mockSet.Object;

            var repository = new AssassinsRepository(mockContext.Object);
            var assassins = repository.GetAll();

            Assert.AreEqual(3, assassins.Count());
            Assert.AreEqual(1, assassins.ElementAt(0).MinReward);
            Assert.AreEqual(1, assassins.ElementAt(1).MinReward);
            Assert.AreEqual(5, assassins.ElementAt(2).MinReward);
            Assert.AreEqual(5, assassins.ElementAt(0).MaxReward);
            Assert.AreEqual(10, assassins.ElementAt(1).MaxReward);
            Assert.AreEqual(10, assassins.ElementAt(2).MaxReward);
            Assert.AreEqual(true, assassins.ElementAt(0).IsActive);
            Assert.AreEqual(true, assassins.ElementAt(1).IsActive);
            Assert.AreEqual(false, assassins.ElementAt(2).IsActive);
        }
    }
}
