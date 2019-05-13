using System;
using System.Collections.Generic;

namespace KFC.Red.DataAccessLayer.Models
{
    public class ChatStorage
    {
        public List<string> UserList { get; set; }
        public List<ChatMessage> MessageList { get; set; }

        public ChatStorage()
        {
            UserList = new List<String>();
            MessageList = new List<ChatMessage>();
        }
    }
}
