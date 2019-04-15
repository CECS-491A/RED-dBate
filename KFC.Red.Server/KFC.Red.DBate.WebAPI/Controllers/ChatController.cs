using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ManagerLayer.ChatroomManager;
using KFC.Red.ServiceLayer.ChatRoom;
using KFC.RED.DataAccessLayer.DTOs;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    public class ChatController : ApiController
    {
        private GameSessionManager _GameSessionManager;
        private UserGameStorageManager _UGSManager;
        private HubService _ChatHub;
        private MessageIDIncrement _Increment;

        public ChatController(GameSessionManager gamesessionManager)
        {
            _UGSManager = new UserGameStorageManager();
            _GameSessionManager = gamesessionManager;
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
            //chatMsg.Id = _Increment.IncrementID();
            //chatMsg.DateTime = DateTime.Now;
            //_GameSessionManager.AddMessage(chatMsg);
            _ChatHub.SendMessage(chatMsg);
            return Ok(chatMsg);
        }


        [HttpGet]
        [Route("api/chat/getusers")]
        public List<string> GetUsers(int gid)
        {
            //_GameSessionManager.AddUser(username);
            _ChatHub.SendUserList(_UGSManager.GetGameUsers(gid));
            return _UGSManager.GetGameUsers(gid);
        }
    }
}