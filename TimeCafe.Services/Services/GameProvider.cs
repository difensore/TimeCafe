using TimeCafe.DAL;
using TimeCafe.DAL.Models;
using TimeCafe.Services.Interfaces;

namespace TimeCafe.Services.Services
{
    public class GameProvider : IGameProvider
    {
        TimeCafeContext context;
        public GameProvider(TimeCafeContext context)
        {
            this.context = context;
        }

        public IEnumerable<Game> GetAllGames()
        {
            return context.Games;
        }

        public Game GetGameById(string id)
        {
            return context.Games?.First(game => game.Id == id);
        }

        public Game AddNewGame(string id, string name, string description, string image)
        {
            var game = new Game()
            {
                Id = id,
                Name = name,
                Description = description,
                Image = image
            };

            context.Games.Add(game);
            context.SaveChanges();

            return game;
        }

        public bool RemoveGame(string id)
        {
            var game = GetGameById(id);
            context.Games.Remove(game);
            context.SaveChanges();

            return true;
        }
        public bool ChangeStatus(string id)
        {
            var game = GetGameById(id);

            if (game.Status == "use")
            {
                game.Status = "notUse";
            }
            else
            {
                game.Status = "use";
            }

            context.SaveChanges();

            return true;
        }
    }
}
