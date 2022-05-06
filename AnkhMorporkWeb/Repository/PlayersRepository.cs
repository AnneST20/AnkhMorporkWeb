using AnkhMorporkWeb.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AnkhMorporkWeb.Repository
{
    public class PlayersRepository : IRepository<Player>
    {
        private readonly GameContext _context;

        public PlayersRepository(GameContext context)
        {
            _context = context;
        }
        public IEnumerable<Player> GetAll()
        {
            return _context.Players.ToList();
        }


        public void Update(Player model)
        {
            if (model != null)
            {
                _context.Entry(model).State = EntityState.Modified;
            }
        }

        public void SetDefaultPlayer()
        {
            var player = _context.Players.FirstOrDefault();
            player.Money = 100m;
            player.CurrentMeeting = "Default";
            player.LastMeeting = " ";
            player.CurrentGuild = "Default";
            player.Beer = 0;
            player.Fee = 0;
            player.MeetingsWithThief = 0;
            Update(player);
        }

    }
}