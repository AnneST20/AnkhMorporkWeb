using AnkhMorporkWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AnkhMorporkWeb.Repository
{
    public class AssassinsRepository : IRepository<Assassin>
    {
        private readonly GameContext _context;

        public AssassinsRepository(GameContext context)
        {
            _context = context;   
        }

        public IEnumerable<Assassin> GetAll()
        {
            return _context.Assassins.ToList();
        }

        public void Update(Assassin guildMember)
        {
            if (guildMember == null)
            {
                _context.Entry(guildMember).State = EntityState.Modified;
            }
        }

        public void UpdateMissions()
        {
            Random random = new Random();
            foreach(var assassin in _context.Assassins)
            {
                var num = random.Next(0, 2);
                assassin.IsActive = num == 1;
;           }
        }

        public void DeleteMissions()
        {
            foreach(var assassin in _context.Assassins)
            {
                assassin.IsActive = true;
            }
        }
    }
}