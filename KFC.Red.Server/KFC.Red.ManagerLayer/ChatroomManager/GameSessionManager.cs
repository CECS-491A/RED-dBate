using KFC.Red.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ManagerLayer.ChatroomManager
{
    public class GameSessionManager
    {
        private ChatStorage _ChatStore;

        public GameSessionManager(ChatStorage chatStore)
        {
            _ChatStore = chatStore;
        }

        public void AddMessage(ChatMessage chatMsg)
        {
            _ChatStore.MessageList.Add(chatMsg);
        }

        public void AddUser(string Username)
        {
            _ChatStore.UserList.Add(Username);
        }

        public List<ChatMessage> GetSessionMessages()
        {
            return _ChatStore.MessageList;
        }

        public List<string> GetSessionUsers()
        {
            return _ChatStore.UserList;
        }
    }
}
