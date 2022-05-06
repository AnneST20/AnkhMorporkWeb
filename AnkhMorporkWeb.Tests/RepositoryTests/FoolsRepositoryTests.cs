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
    public class FoolsRepositoryTests
    {
        private Mock<DbSet<Fool>> MockSet()
        {
            var data = new List<Fool>
            {
                new Fool { Id = 1, Type = "Type 1", Fee = 10m},
                new Fool { Id = 2, Type = "Type 2", Fee = 15m},
                new Fool { Id = 3, Type = "Type 3", Fee = 0m}
            };

            var queryable = data.AsQueryable();

            var mockSet = new Mock<DbSet<Fool>>();
            mockSet.As<IQueryable<Fool>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<Fool>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<Fool>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<Fool>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            mockSet.Setup(d => d.Add(It.IsAny<Fool>())).Callback<Fool>((s) => data.Add(s));

            return mockSet;
        }

        [TestMethod]
        public void GetAll_Returns_List()
        {
            var mockSet = MockSet();

            var mockContext = new Mock<GameContext>();
            mockContext.Object.Fool = mockSet.Object;

            var repository = new FoolsRepository(mockContext.Object);
            var fools = repository.GetAll();

            Assert.AreEqual(3, fools.Count());
            Assert.AreEqual(10m, fools.ElementAt(0).Fee);
            Assert.AreEqual(15m, fools.ElementAt(1).Fee);
            Assert.AreEqual(0m, fools.ElementAt(2).Fee);
            Assert.AreEqual("Type 1", fools.ElementAt(0).Type);
            Assert.AreEqual("Type 2", fools.ElementAt(1).Type);
            Assert.AreEqual("Type 3", fools.ElementAt(2).Type);

        }
    }
}
