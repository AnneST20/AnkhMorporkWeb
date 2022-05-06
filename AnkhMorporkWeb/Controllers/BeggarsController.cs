using AnkhMorporkWeb.Models;
using AnkhMorporkWeb.Repository;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AnkhMorporkWeb.Controllers
{
    public class BeggarsController : Controller
    {
        private UnitOfWork engine = new UnitOfWork();
        private BeggarsRepository beggars;
        private Player player;

        public BeggarsController()
        {
            player = engine.Players.GetAll().FirstOrDefault();
            beggars = engine.Beggars;
        }

        public ActionResult Index()
        {
            Random random = new Random();
            var beggar = beggars.GetAll().ElementAt(random.Next(0, beggars.GetAll().Count()));
            player.CurrentMeeting = GuildInfo.BeggarsInfo(beggar.Type, beggar.Fee, beggar.Beer);
            player.Fee = beggar.Fee;
            ViewBag.Beer = beggar.Beer;
            ViewBag.Type = beggar.Type;
            engine.Save();
            return View(player);
        }

        public ActionResult Accept(string type, bool beer)
        {
            
            if (player.Money >= player.Fee)
            {
                if (beer)
                {
                    if (player.Beer > 0)
                        player.Beer--;
                    else
                        return RedirectToAction("Decline");
                }
                    
                player.Money -= player.Fee;
                player.LastMeeting = GuildInfo.BeggarSuccess(type, player.Fee, beer);
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
            player.LastMeeting = GuildInfo.BeggarFail();
            engine.Save();
            return RedirectToAction("Death", "Home");
        }
    }
}