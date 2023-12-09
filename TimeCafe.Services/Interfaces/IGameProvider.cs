using TimeCafe.DAL.Models;

namespace TimeCafe.Services.Interfaces
{
    public interface IGameProvider
    {
        public IEnumerable<Game> GetAllGames();

        public Game GetGameById(string id);

        public Game AddNewGame(string id, string name, string description, string image);

        public bool RemoveGame(string id);

        public bool ChangeStatus(string id);
    }
}
