using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Net;
using System.Web.Http;
using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ManagerLayer.ChatroomManager;
using KFC.Red.ManagerLayer.QuestionManagement;
using KFC.Red.ServiceLayer.ChatRoom;
using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.ManagerLayer.UserManagement;
using KFC.Red.ManagerLayer.SessionManagement;
using System.Web.Http.Cors;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ChatController : ApiController
    {
        private GameSessionManager _GameSessionManager;
        private UserGameStorageManager _UserGameStoreManager;
        private HubService _ChatHub;
        private MessageIDIncrement _Increment;

        public ChatController()
        {
            _UserGameStoreManager = new UserGameStorageManager();
            _GameSessionManager = new GameSessionManager();
            _ChatHub = new HubService();
            _Increment = new MessageIDIncrement();
        }

        [HttpPost]
        [Route("api/chat/postmessage")]
        public IHttpActionResult PostMessage([FromBody] ChatMessageDTO chatMsg)
        {
            _ChatHub.SendMessage(chatMsg);
            return Ok(chatMsg);
        }


        [HttpGet]
        [Route("api/chat/getusers")]
        public List<string> GetUsers(int gid)
        {
            _ChatHub.SendUserList(_UserGameStoreManager.GetGameUsernames(gid));
            return _UserGameStoreManager.GetGameUsernames(gid);
        }

        [HttpGet]
        [Route("api/chat/createchat")]
        public IHttpActionResult CreateChat(string token)
        {
            using (var _db = new ApplicationDbContext())
            {
                UserGameStorage userGameStorage = new UserGameStorage();
                UserManager userManager = new UserManager();
                GameSession gameSession = new GameSession();
                SessionManager sessionManager = new SessionManager();

                QuestionManager questionManager = new QuestionManager();
                

                try
                {
                    var question = questionManager.RandomizeQuestion();
                    var questionObj = questionManager.GetQuestion(question);

                    gameSession = _GameSessionManager.CreateGameSession(questionObj);
                    var session = sessionManager.GetSession(token);
                    var user = userManager.GetUser(session.UId);

                    userGameStorage.UId = user.ID;
                    userGameStorage.User = user;
                    userGameStorage.GId = gameSession.Id;
                    userGameStorage.GameSession = gameSession;
                    userGameStorage.Order = 0;

                    var storage = _UserGameStoreManager.CreateUGS(userGameStorage);

                }
                catch (ArgumentException)
                {
                    return Conflict();
                }
                catch (Exception e)
                {
                    return Content(HttpStatusCode.BadRequest, e.ToString() + userGameStorage.UId);
                }


                try
                {
                    _db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    _db.Entry(gameSession).State = System.Data.Entity.EntityState.Detached;
                    return InternalServerError(e);
                }

                return Ok(gameSession.Token);
            }
        }

        [HttpGet]
        [Route("api/chat/joinrandomchat")]
        public IHttpActionResult JoinRandomChat(string token)
        {
            using (var _db = new ApplicationDbContext())
            {
                UserGameStorage userGameStorage = new UserGameStorage();
                UserManager userManager = new UserManager();
                GameSession gameSession = new GameSession();
                SessionManager sessionManager = new SessionManager();

                try
                {
                    gameSession = _GameSessionManager.GetRandomGameSession();
                    var session = sessionManager.GetSession(token);
                    var user = userManager.GetUser(session.UId);

                    userGameStorage.UId = user.ID;
                    userGameStorage.User = user;
                    userGameStorage.GId = gameSession.Id;
                    userGameStorage.GameSession = gameSession;
                    userGameStorage.Order = 0;

                    var storage = _UserGameStoreManager.CreateUGS(userGameStorage);
                }
                catch (Exception e)
                {
                    return Content(HttpStatusCode.BadRequest, e.ToString());
                }

                return Ok(gameSession.Token);
            }
        }

        [HttpDelete]
        [Route("api/chat/deletegame")]
        public IHttpActionResult DeleteGameSession(string gameSessionToken)
        {
            var gameSession = _GameSessionManager.GetGameSession(gameSessionToken);
            _GameSessionManager.DeleteGameSession(gameSession);
            return Ok();
        }
    }
}