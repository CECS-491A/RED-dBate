using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KFC.Red.ManagerLayer.ChatroomManager;
using KFC.Red.ServiceLayer.ChatRoom;
using KFC.RED.DataAccessLayer.Models;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    public class ChatController : ApiController
    {
        private ChatroomManager _ChatManager;
        private HubService _ChatHub;
        private MessageIDIncrement _Increment;

        public ChatController(ChatroomManager chatroomManager)
        {
            _ChatManager = chatroomManager;
            _ChatHub = new HubService();
            _Increment = new MessageIDIncrement();
        }
        
        [HttpGet]
        [Route("api/chat/getmessages")]
        public List<ChatMessage> GetMessages()
        {
            return _ChatManager.GetSessionMessages();
        }

        [HttpPost]
        [Route("api/chat/postmessage")]
        public IHttpActionResult PostMessage(ChatMessage chatMsg)
        {
            chatMsg.Id = _Increment.IncrementID();
            //chatMsg.DateTime = DateTime.Now;
            _ChatManager.AddMessage(chatMsg);
            
            _ChatHub.SendMessage(chatMsg);
            return Ok(chatMsg);
        }


        [HttpGet]
        [Route("api/chat/getusers")]
        public List<string> GetUsers(string username)
        {
            _ChatManager.AddUser(username);
            _ChatHub.SendUserList(_ChatManager.GetSessionUsers());
            return _ChatManager.GetSessionUsers();
            
        }
    }
}