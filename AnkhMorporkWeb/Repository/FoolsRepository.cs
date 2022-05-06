using AnkhMorporkWeb.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AnkhMorporkWeb.Repository
{
    public class FoolsRepository : IRepository <Fool>
    {
        private readonly GameContext _context;

        public FoolsRepository(GameContext context)
        {
            _context = context;
        }

        public IEnumerable<Fool> GetAll()
        {
            return _context.Fool.ToList();
        }


        public void Update(Fool guildMember)
        {
            if (guildMember == null)
            {
                _context.Entry(guildMember).State = EntityState.Modified;
            }
        }
    }
}