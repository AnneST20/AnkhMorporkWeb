using System.Data.Entity;

namespace AnkhMorporkWeb.Models
{
    public class GameContext : DbContext
    {
        public DbSet<Assassin> Assassins { get; set; }
        public DbSet<Beggar> Beggars { get; set; }
        public DbSet<Fool> Fool { get; set; }
        public DbSet<Thief> Thief { get; set; }
        public DbSet<Player> Players { get; set; }
        public GameContext() : base("GameContext") { }
    }
}