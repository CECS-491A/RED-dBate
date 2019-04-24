using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ManagerLayer.ChatroomManager;
using KFC.Red.ManagerLayer.QuestionManagement;
using KFC.Red.ServiceLayer.ChatRoom;
using KFC.Red.ServiceLayer.TokenService;
using KFC.RED.DataAccessLayer.DTOs;

namespace KFC.Red.DBate.WebAPI.Controllers
{
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

        /*
        [HttpGet]
        [Route("api/chat/getmessages")]
        public List<ChatMessage> GetMessages()
        {
            return _GameSessionManager.GetSessionMessages();
        }
        */

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
            _ChatHub.SendUserList(_UserGameStoreManager.GetGameUsers(gid));
            return _UserGameStoreManager.GetGameUsers(gid);
        }

        [HttpGet]
        [Route("api/chat/createchat")]
        public IHttpActionResult CreateChat()
        {
            using(var _db = new ApplicationDbContext())
            {
                GameSession gameSession = new GameSession();

                try
                {
                    //TokenService tokenService = new TokenService();
                    QuestionManager questionManager = new QuestionManager();

                    var question = questionManager.RandomizeQuestion();
                    var questionObj = questionManager.GetQuestion(question);

                    gameSession = _GameSessionManager.CreateGameSession(questionObj);                    
                }
                catch (ArgumentException)
                {
                    return Conflict();
                }
                catch (Exception e)
                {
                    return Content(HttpStatusCode.BadRequest, e.ToString());
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
        public IHttpActionResult JoinRandomChat()
        {
            using (var _db = new ApplicationDbContext())
            {
                GameSession gameSession = new GameSession();

                try
                {
                    gameSession = _GameSessionManager.GetRandomGameSession();
                }
                catch (Exception e)
                {
                    return Content(HttpStatusCode.BadRequest, e.ToString());
                }

                return Ok(gameSession.Token);
            }
        }
    }
}