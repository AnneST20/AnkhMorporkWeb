using AnkhMorporkWeb.Models;
using AnkhMorporkWeb.Repository;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AnkhMorporkWeb.Controllers
{
    public class FoolsController : Controller
    {
        private UnitOfWork engine = new UnitOfWork();
        private FoolsRepository fools;
        private Player player;

        public FoolsController()
        {
            player = engine.Players.GetAll().FirstOrDefault();
            fools = engine.Fools;
        }

        public ActionResult Index()
        {
            Random random = new Random();
            var fool = fools.GetAll().ElementAt(random.Next(0, fools.GetAll().Count()));
            player.CurrentMeeting = GuildInfo.FoolInfo(fool.Type, fool.Fee);
            player.Fee = fool.Fee;
            ViewBag.Type = fool.Type;
            engine.Save();
            return View(player);
        }

        public ActionResult Accept(string type)
        {
            player.Money += player.Fee;
            player.LastMeeting = GuildInfo.FoolSucces(type, player.Fee);
            engine.Save();
            return RedirectToAction("Move", "Home");
        }

        public ActionResult Decline()
        {
            player.LastMeeting = GuildInfo.FoolFail();
            engine.Save();
            return RedirectToAction("Move", "Home");
        }
    }
}