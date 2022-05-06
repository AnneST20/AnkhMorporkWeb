using AnkhMorporkWeb.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AnkhMorporkWeb.Repository
{
    public class ThiefsRepository : IRepository <Thief>
    {
        private readonly GameContext _context;

        public ThiefsRepository(GameContext context)
        {
            _context = context;
        }

        public IEnumerable<Thief> GetAll()
        {
            return _context.Thief.ToList();
        }


        public void Update(Thief guildMember)
        {
            if (guildMember == null)
            {
                _context.Entry(guildMember).State = EntityState.Modified;
            }
        }
    }
}