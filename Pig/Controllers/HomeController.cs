using Microsoft.AspNetCore.Mvc;
using Pig.Models;
using System.Diagnostics;

namespace Pig.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var sess = new GameSession(HttpContext.Session);
            var game = sess.GetGame();

            if(game.IsGameOver)
            {
                TempData["message"] = $"{game.CurrentPlayerName} wins!";
            }

            return View(game);
        }

        [HttpPost]
        public IActionResult NewGame()
        {
            var sess = new GameSession(HttpContext.Session);
            var game = sess.GetGame();

            game.NewGame();

            sess.SetGame(game);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public RedirectToActionResult Roll()
        {
            var sess = new GameSession(HttpContext.Session);
            var game = sess.GetGame();

            game.Roll();

            sess.SetGame(game);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public RedirectToActionResult Hold()
        {
            var sess = new GameSession(HttpContext.Session);
            var game = sess.GetGame();

            game.Hold();

            sess.SetGame(game);
            return RedirectToAction("Index");
        }

    }
}