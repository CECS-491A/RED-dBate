using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.DataAccessLayer.Repositories;
using KFC.Red.ServiceLayer.ChatRoom.Interface;

namespace KFC.Red.ServiceLayer.ChatRoom
{
    public class GameSessionService : IGameSession
    {
        private GameSessionRepository _GameSessionRepo;

        public GameSessionService()
        {
            _GameSessionRepo = new GameSessionRepository();
        }

        public GameSession CreateGameSession(ApplicationDbContext _db, GameSession gamesession)
        {
            return _GameSessionRepo.CreateNewGameSession(_db, gamesession);
        }

        public GameSession DeleteGameSession(ApplicationDbContext _db, int id)
        {
            return _GameSessionRepo.DeleteGameSession(_db, id);
        }

        public GameSession DeleteGameSession(ApplicationDbContext _db, GameSession gamesession)
        {
            return _GameSessionRepo.DeleteGameSession(_db, gamesession);
        }

        public GameSession GetGameSession(ApplicationDbContext _db, string token)
        {
            return _GameSessionRepo.GetGameSession(_db, token);
        }

        public GameSession GetGameSession(ApplicationDbContext _db, int id)
        {
            return _GameSessionRepo.GetGameSession(_db, id);
        }

        public bool ExistingGameSession(ApplicationDbContext _db, GameSession gamesession)
        {
            return _GameSessionRepo.ExistingGameSession(_db, gamesession);
        }

        public bool ExistingGameSession(ApplicationDbContext _db, int id)
        {
            return _GameSessionRepo.ExistingGameSession(_db, id);
        }

        public GameSession UpdateGameSession(ApplicationDbContext _db, GameSession gameSession)
        {
            return _GameSessionRepo.UpdateGameSession(_db, gameSession);
        }

    }
}
