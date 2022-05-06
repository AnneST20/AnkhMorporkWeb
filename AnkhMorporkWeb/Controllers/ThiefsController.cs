using AnkhMorporkWeb.Models;
using AnkhMorporkWeb.Repository;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AnkhMorporkWeb.Controllers
{
    public class ThiefsController : Controller
    {
        private UnitOfWork engine = new UnitOfWork();
        private ThiefsRepository thiefs;
        private Player player;

        public ThiefsController()
        {
            player = engine.Players.GetAll().FirstOrDefault();
            thiefs = engine.Thiefs;
        }

        public ActionResult Index()
        {
            var thief = thiefs.GetAll().FirstOrDefault();
            player.CurrentMeeting = GuildInfo.ThiefInfo();
            player.Fee = thief.Fee;
            engine.Save();
            return View(player);
        }

        public ActionResult Accept()
        {
            if (player.Money > player.Fee)
            {
                player.Money -= player.Fee;
                player.LastMeeting = GuildInfo.ThiefSucces(player.Fee);
                engine.Save();
                return RedirectToAction("Move", "Home");
            }
            else
            {
                return RedirectToAction("Decline");
            }
        }

        public ActionResult Decline()
        {
            player.LastMeeting = GuildInfo.ThiefFail();
            engine.Save();
            return RedirectToAction("Death", "Home");
        }
    }
}