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
    public class ThiefsRepositoryTests
    {
        private Mock<DbSet<Thief>> MockSet()
        {
            var data = new List<Thief>
            {
                new Thief { Id = 1, Fee = 10m},
                new Thief { Id = 2, Fee = 15m},
                new Thief { Id = 3, Fee = 0m}
            };

            var queryable = data.AsQueryable();

            var mockSet = new Mock<DbSet<Thief>>();
            mockSet.As<IQueryable<Thief>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<Thief>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<Thief>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<Thief>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            mockSet.Setup(d => d.Add(It.IsAny<Thief>())).Callback<Thief>((s) => data.Add(s));

            return mockSet;
        }

        [TestMethod]
        public void GetAll_Returns_List()
        {
            var mockSet = MockSet();

            var mockContext = new Mock<GameContext>();
            mockContext.Object.Thief = mockSet.Object;

            var repository = new ThiefsRepository(mockContext.Object);
            var thieves = repository.GetAll();

            Assert.AreEqual(3, thieves.Count());
            Assert.AreEqual(10m, thieves.ElementAt(0).Fee);
            Assert.AreEqual(15m, thieves.ElementAt(1).Fee);
            Assert.AreEqual(0m, thieves.ElementAt(2).Fee);

        }
    }
}
