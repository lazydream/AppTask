using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ApplyingTask.Models;

namespace ApplyingTask.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Player> players;
            List<Player> playersCLE = new List<Player>();
            List<Player> playersLAL = new List<Player>();
            PlayerModel pm = new PlayerModel();
            players = pm.getPlayers();

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Team == "CLE")
                {
                    playersCLE.Add(players[i]);
                }
                if (players[i].Team == "LAL")
                {
                    playersLAL.Add(players[i]);
                }
            }

            pm.sortPlayers(playersCLE);
            pm.sortPlayers(playersLAL);
            ViewBag.CLE = playersCLE;
            ViewBag.LAL = playersLAL;
            ViewBag.players = players;

            return View();
        }
    }
}