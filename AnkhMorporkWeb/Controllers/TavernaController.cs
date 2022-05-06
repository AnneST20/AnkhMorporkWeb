using AnkhMorporkWeb.Models;
using AnkhMorporkWeb.Repository;
using System.Linq;
using System.Web.Mvc;

namespace AnkhMorporkWeb.Controllers
{
    public class TavernaController : Controller
    {
        private UnitOfWork engine = new UnitOfWork();
        private Player player;

        public TavernaController()
        {
            player = engine.Players.GetAll().FirstOrDefault();
        }

        public ActionResult Index()
        {
            player.CurrentMeeting = GuildInfo.TavernaInfo();
            engine.Save();
            return View(player);
        }

        public ActionResult Accept()
        {
            if (player.Money >= 2m && player.Beer < 2)
            {
                player.Money -= 2;
                player.Beer += 1;
                player.LastMeeting = GuildInfo.TavernaSuccess();
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
            player.LastMeeting = GuildInfo.TavernaFail();
            engine.Save();
            return RedirectToAction("Move", "Home");
        }
    }
}