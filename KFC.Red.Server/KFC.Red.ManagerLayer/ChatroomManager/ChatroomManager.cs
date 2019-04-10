using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ServiceLayer.ChatRoom;
using KFC.Red.ServiceLayer.ChatRoom.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ManagerLayer.ChatroomManager
{
    public class ChatroomManager
    {
        private ChatStorage _ChatStore;
        
        public ChatroomManager(ChatStorage chatStore)
        {
            _ChatStore = chatStore;
        }
        
        public void AddMessage(ChatMessage chatMsg)
        {
            _ChatStore.MessageList.Add(chatMsg);
        } 

        public void AddUser(String Username)
        {
            _ChatStore.UserList.Add(Username);
        }

        public List<ChatMessage> GetSessionMessages()
        {
            return _ChatStore.MessageList;
        }
        
        public List<String> GetSessionUsers()
        {
            return _ChatStore.UserList;
        }
    }
}
