using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.DataAccessLayer.Models
{
    public class ChatStorage
    {
        public List<String> UserList { get; set; }
        public List<ChatMessage> MessageList { get; set; }

        public ChatStorage()
        {
            UserList = new List<String>();
            MessageList = new List<ChatMessage>();
        }
    }
}
