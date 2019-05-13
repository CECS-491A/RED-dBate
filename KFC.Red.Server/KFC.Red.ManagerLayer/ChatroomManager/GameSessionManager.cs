using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ManagerLayer.QuestionManagement;
using KFC.Red.ManagerLayer.SessionManagement;
using KFC.Red.ManagerLayer.UserManagement;
using KFC.Red.ServiceLayer;
using KFC.Red.ServiceLayer.ChatRoom;
using KFC.Red.ServiceLayer.QuestionManagement;
using KFC.Red.ServiceLayer.QuestionManagement.Interfaces;
using KFC.Red.ServiceLayer.Token;
using KFC.Red.ServiceLayer.Token.Interface;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace KFC.Red.ManagerLayer.ChatroomManager
{
    public class GameSessionManager
    {
        private ChatStorage _ChatStore;
        public HubService _HubService;
        private GameSessionService _GSessionService;

        public GameSessionManager()
        {
            _ChatStore = new ChatStorage();
            _HubService = new HubService();
            _GSessionService = new GameSessionService();
        }

        public GameSession CreateGameSession(Question question)
        {
            IToken _tokenService = new TokenService();
            IQuestionService _questionService = new QuestionService();
            var questionManager = new QuestionManager();
            using (var _db = new ApplicationDbContext())
            {

                GameSession session = new GameSession
                {
                    Token = _tokenService.GenerateToken(),
                    QuestionID = question.QuestionID
                };
                ++session.PlayerCount;

                _GSessionService.CreateGameSession(_db, session);
                _db.SaveChanges();
                return session;
            }
        }

        public int DeleteGameSession(GameSession gamesession)
        {
            using (var _db = new ApplicationDbContext())
            {
                var response = _GSessionService.DeleteGameSession(_db, gamesession.Id);
                // will return null if gamesession does not exist
                return _db.SaveChanges();
            }
        }

        public int DeleteGameSession(int id)
        {
            using (var _db = new ApplicationDbContext())
            {
                var response = _GSessionService.DeleteGameSession(_db, id);
                return _db.SaveChanges();
            }
        }

        public GameSession GetGameSession(int id)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _GSessionService.GetGameSession(_db, id);
            }
        }

        public GameSession GetGameSession(string token)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _GSessionService.GetGameSession(_db,token);
            }
        }

        public GameSession GetRandomGameSession()
        {
            using (var _db = new ApplicationDbContext())
            {
                ReusableServices reusableServices = new ReusableServices();
                var gameSessionsList = _db.GameSessions.Where(c => c.isSessionUsed == false).ToList();
                var maxSize = gameSessionsList.Count();
                var index = reusableServices.GetNumberForRandomization(0,maxSize-1);
                var gameSession = gameSessionsList[index];
                return gameSession;
            }
        }

        public GameSession JoinRandomGameSession(string token)
        {
            using (var _db = new ApplicationDbContext())
            {
                var userGameStorage = new UserGameStorage();
                var userManager = new UserManager();
                var sessionManager = new SessionManager();

                var questionManager = new QuestionManager();
                var reusableServices = new ReusableServices();

                var question = questionManager.RandomizeQuestion();
                var gameSessionsList = _db.GameSessions.Where(c => c.isSessionUsed == false).ToList();
                var maxSize = gameSessionsList.Count();
                var index = reusableServices.GetNumberForRandomization(0, maxSize - 1);

                var gameSession = gameSessionsList[index];

                gameSession = CreateGameSession(question);
                var session = sessionManager.GetSession(token);
                var user = userManager.GetUser(session.UId);

                userGameStorage.UId = user.ID;
                userGameStorage.GId = gameSession.Id;

                //var storage = _UserGameStoreManager.CreateUGS(userGameStorage);
                return gameSession;
            }
        }

        public bool ExistingGameSession(int id)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _GSessionService.ExistingGameSession(_db, id);
            }
        }

        public bool ExistingGameSession(GameSession gs)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _GSessionService.ExistingGameSession(_db, gs);
            }
        }

        public int UpdateGameSession(GameSession gameSession)
        {
            if (gameSession == null)
            {
                return 0;
            }

            using (var _db = new ApplicationDbContext())
            {

                var response = _GSessionService.UpdateGameSession(_db, gameSession);
                try
                {
                    return _db.SaveChanges();
                }
                catch (DbEntityValidationException)
                {
                    _db.Entry(response).CurrentValues.SetValues(_db.Entry(response).OriginalValues);
                    _db.Entry(response).State = System.Data.Entity.EntityState.Unchanged;
                    return 0;
                }
                catch (DbUpdateConcurrencyException)
                {
                    return 0;
                }
            }
        }
    }
}
