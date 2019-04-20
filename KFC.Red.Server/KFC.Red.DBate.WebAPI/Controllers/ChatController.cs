using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ManagerLayer.ChatroomManager;
using KFC.Red.ManagerLayer.QuestionManagement;
using KFC.Red.ServiceLayer.ChatRoom;
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

        public class ConnectionDTO
        {
            public string Question { get; set; }
        }

        //NEEDS WORKS AND TO BE FINISHED!!!
        [HttpPost]
        [Route("api/chat/connection")]
        public IHttpActionResult Connection([FromBody] QuestionDTO req)
        {
            QuestionManager questionManager = new QuestionManager();
            var question = questionManager.GetQuestion(req.QuestionString);
            _GameSessionManager.CreateGameSession(question);

            return Ok();
        }

        //WORKS FINE
        [HttpPost]
        [Route("api/chat/postmessage")]
        public IHttpActionResult PostMessage([FromBody] ChatMessageDTO chatMsg)
        {
            //chatMsg.Id = _Increment.IncrementID();
            //chatMsg.DateTime = DateTime.Now;
            //_GameSessionManager.AddMessage(chatMsg);
            //_UserGameStoreManager.
            _ChatHub.SendMessage(chatMsg);
            return Ok(chatMsg);
        }


        [HttpGet]
        [Route("api/chat/getusers")]
        public List<string> GetUsers(int gid)
        {
            //_GameSessionManager.AddUser(username);
            _ChatHub.SendUserList(_UserGameStoreManager.GetGameUsers(gid));
            return _UserGameStoreManager.GetGameUsers(gid);
        }
    }
}