using AnkhMorporkWeb.Models;
using System;

namespace AnkhMorporkWeb.Repository
{
    public class UnitOfWork : IDisposable
    {
        private GameContext _context = new GameContext();
        private AssassinsRepository assassinsRepository;
        private BeggarsRepository beggarsRepository;
        private FoolsRepository foolsRepository;
        private ThiefsRepository thiefsRepository;
        private PlayersRepository playersRepository;

        public AssassinsRepository Assassins
        {
            get
            {
                if (assassinsRepository == null)
                    assassinsRepository = new AssassinsRepository(_context);
                return assassinsRepository;
            }
        }

        public BeggarsRepository Beggars
        {
            get
            {
                if (beggarsRepository == null)
                    beggarsRepository = new BeggarsRepository(_context);
                return beggarsRepository;
            }
        }

        public FoolsRepository Fools
        {
            get
            {
                if (foolsRepository == null)
                    foolsRepository = new FoolsRepository(_context);
                return foolsRepository;
            }
        }

        public ThiefsRepository Thiefs
        {
            get
            {
                if (thiefsRepository == null)
                    thiefsRepository = new ThiefsRepository(_context);
                return thiefsRepository;
            }
        }

        public PlayersRepository Players
        {
            get
            {
                if (playersRepository == null)
                    playersRepository = new PlayersRepository(_context);
                 return playersRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}