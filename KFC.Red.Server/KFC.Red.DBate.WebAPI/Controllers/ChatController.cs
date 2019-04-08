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
        
        public List<ChatMessage> GetMessages()
        {
            return _ChatManager.GetSessionMessages();
        }

        public void PostMessage(ChatMessage chatMsg)
        {
            chatMsg.Id = _Increment.IncrementID();
            chatMsg.DateTime = DateTime.Now;
            _ChatManager.AddMessage(chatMsg);
            
            _ChatHub.SendMessage(chatMsg);
        }


        public List<String> GetUsers(string username)
        {
            _ChatManager.AddUser(username);
            _ChatHub.SendUserList(_ChatManager.GetSessionUsers());
            return _ChatManager.GetSessionUsers();
            
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }


    }
}