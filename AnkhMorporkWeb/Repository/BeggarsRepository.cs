using AnkhMorporkWeb.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AnkhMorporkWeb.Repository
{
    public class BeggarsRepository : IRepository <Beggar>
    {
        private readonly GameContext _context;

        public BeggarsRepository(GameContext context)
        {
            _context = context;
        }

        public IEnumerable<Beggar> GetAll()
        {
            return _context.Beggars.ToList();
        }


        public void Update(Beggar guildMember)
        {
            if (guildMember == null)
            {
                _context.Entry(guildMember).State = EntityState.Modified;
            }
        }
    }
}