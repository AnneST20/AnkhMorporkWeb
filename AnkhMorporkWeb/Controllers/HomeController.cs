using AnkhMorporkWeb.Repository;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AnkhMorporkWeb.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork engine = new UnitOfWork();
        PlayersRepository players;

        public HomeController()
        {
            players = engine.Players;
        }

        private enum Meeting { Taverna, Assassins, Beggars, Fools, Thiefs};
        public ActionResult Index()
        {
            players.SetDefaultPlayer();
            engine.Save();
            return View();
        }

        public ActionResult Death()
        {
            var player = players.GetAll().FirstOrDefault();
            return View(player);
        }

        public ActionResult Move()
        {
            Random random = new Random();
            var player = players.GetAll().FirstOrDefault();

            var curGuild = player.MeetingsWithThief == 6? random.Next(0, 4) : random.Next(0, 5);
            if (curGuild == 2) player.MeetingsWithThief++;

            var curGuildName = Enum.GetName(typeof(Meeting), curGuild);
            if (curGuildName.Equals("Taverna"))
            {
                player.CurrentGuild = "Time toy relax! You visited taverna";
            }
            else
            {
                player.CurrentGuild = $"You met {curGuildName} Guild";
            }
            
            try
            {
                if (ModelState.IsValid)
                {
                    players.Update(player);
                    engine.Save();
                }
            }
            catch (Exception) { }
            return RedirectToAction("Index", curGuildName);
        }
    }
}