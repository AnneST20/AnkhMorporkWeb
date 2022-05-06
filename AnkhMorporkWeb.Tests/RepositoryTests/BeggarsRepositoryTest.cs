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
    public class BeggarsRepositoryTests
    {
        private Mock<DbSet<Beggar>> MockSet()
        {
            var data = new List<Beggar>
            {
                new Beggar { Id = 1, Type = "Type 1", Fee = 10m, Beer = false},
                new Beggar { Id = 2, Type = "Type 2", Fee = 15m, Beer = false},
                new Beggar { Id = 3, Type = "Type 3", Fee = 0m, Beer = true}
            };

            var queryable = data.AsQueryable();

            var mockSet = new Mock<DbSet<Beggar>>();
            mockSet.As<IQueryable<Beggar>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<Beggar>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<Beggar>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<Beggar>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            mockSet.Setup(d => d.Add(It.IsAny<Beggar>())).Callback<Beggar>((s) => data.Add(s));

            return mockSet;
        }

        [TestMethod]
        public void GetAll_Returns_List()
        {
            var mockSet = MockSet();

            var mockContext = new Mock<GameContext>();
            mockContext.Object.Beggars = mockSet.Object;

            var repository = new BeggarsRepository(mockContext.Object);
            var beggars = repository.GetAll();

            Assert.AreEqual(3, beggars.Count());
            Assert.AreEqual(10m, beggars.ElementAt(0).Fee);
            Assert.AreEqual(15m, beggars.ElementAt(1).Fee);
            Assert.AreEqual(0m, beggars.ElementAt(2).Fee);
            Assert.AreEqual("Type 1", beggars.ElementAt(0).Type);
            Assert.AreEqual("Type 2", beggars.ElementAt(1).Type);
            Assert.AreEqual("Type 3", beggars.ElementAt(2).Type);
            Assert.AreEqual(false, beggars.ElementAt(0).Beer);
            Assert.AreEqual(false, beggars.ElementAt(1).Beer);
            Assert.AreEqual(true, beggars.ElementAt(2).Beer);

        }
    }
}
