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
    public class PlayersRepositoryTests
    {
        private Mock<DbSet<Player>> MockSet()
        {
            var data = new List<Player>
            {
                new Player 
                {
                    Id = 1, 
                    Beer = 2, 
                    CurrentGuild = "Assassins", 
                    CurrentMeeting = "They want to kill you", 
                    Fee = 10m, 
                    LastMeeting = "Fool gave you 5 AM$", 
                    MeetingsWithThief = 1, 
                    Money = 50
                }
            };

            var queryable = data.AsQueryable();

            var mockSet = new Mock<DbSet<Player>>();
            mockSet.As<IQueryable<Player>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<Player>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<Player>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<Player>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            mockSet.Setup(d => d.Add(It.IsAny<Player>())).Callback<Player>((s) => data.Add(s));

            return mockSet;
        }

        [TestMethod]
        public void GetAll_Returns_List()
        {
            var mockSet = MockSet();

            var mockContext = new Mock<GameContext>();
            mockContext.Object.Players = mockSet.Object;

            var repository = new PlayersRepository(mockContext.Object);
            var players = repository.GetAll();

            Assert.AreEqual(1, players.Count());
            Assert.AreEqual(players.ElementAt(0).Fee, 10m);
            Assert.AreEqual(players.ElementAt(0).Beer, 2);
            Assert.AreEqual(players.ElementAt(0).CurrentGuild, "Assassins");
            Assert.AreEqual(players.ElementAt(0).CurrentMeeting, "They want to kill you");
            Assert.AreEqual(players.ElementAt(0).LastMeeting, "Fool gave you 5 AM$");
            Assert.AreEqual(players.ElementAt(0).MeetingsWithThief, 1);
            Assert.AreEqual(players.ElementAt(0).Money, 50m);

        }
    }
}
