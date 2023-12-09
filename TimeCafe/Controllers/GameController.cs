using Microsoft.AspNetCore.Mvc;
using TimeCafe.Services.Interfaces;

namespace TimeCafe.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameProvider gameProvider;

        public GameController(IGameProvider gameProvider)
        {
            this.gameProvider = gameProvider;
        }

        public IActionResult Index()
        {
            return View(gameProvider.GetAllGames());
        }

        public IActionResult Details(string id)
        {
            return View(gameProvider.GetGameById(id));
        }

        public IActionResult RemoveGame(string id)
        {
            var result = gameProvider.RemoveGame(id);

            return result ? View("Index") : Content("Error");
        }

        public IActionResult CreateGame(string id, string name, string image, string description)
        {
            var game = gameProvider.AddNewGame(id, name, description, image);

            return View(game);
        }
    }
}
