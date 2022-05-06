using AnkhMorporkWeb.Models;
using AnkhMorporkWeb.Repository;
using System.Linq;
using System.Web.Mvc;

namespace AnkhMorporkWeb.Controllers
{
    public class AssassinsController : Controller
    {
        private UnitOfWork engine = new UnitOfWork();
        private AssassinsRepository assassins;
        private Player _player;

        public AssassinsController()
        {
            _player = engine.Players.GetAll().FirstOrDefault();
            assassins = engine.Assassins;
        }

        public ActionResult Index()
        {
            _player.CurrentMeeting = GuildInfo.AssassinInfo();
            engine.Save();
            return View(_player);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,Money,Fee,Beer,MeetingsWithThief,CurrentGuild,LastMeeting,CurrentMeeting")] Player player)
        {
            if (ModelState.IsValid)
            {
                _player.Fee = player.Fee;
                engine.Save();

            }
            else
            {
                return RedirectToAction("Index");
            }
            assassins.UpdateMissions();
            engine.Save();
            var reward = _player.Fee;
            var assassin = assassins.GetAll().FirstOrDefault(
                a => a.IsActive == true 
                && a.MinReward <= reward 
                && a.MaxReward >= reward);
            assassins.DeleteMissions();
            engine.Save();
            if (assassin != null && _player.Money >= reward)
            {
                _player.LastMeeting = GuildInfo.AssassinSucces(reward);
                _player.Money -= reward;
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
            _player.LastMeeting = GuildInfo.AssassinFail();
            engine.Save();
            return RedirectToAction("Death", "Home");
        }
    }
}