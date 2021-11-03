using DeckofCardsLab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DeckofCardsLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private DeckDAL deckDAL = new DeckDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateDeck()
        {
            DeckModel result = deckDAL.GetDeck();
            deckDAL.ShuffleDeck(result.deck_id);
            HttpContext.Response.Cookies.Append("DeckID", result.deck_id);
            return RedirectToAction("Hand");
        }

        public IActionResult Hand()
        {
            string deckid = HttpContext.Request.Cookies["DeckID"];
            HandModel result = deckDAL.GetHand(deckid);
            if(result.remaining < 5)
            {
                deckDAL.ShuffleDeck(deckid);
            }
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
