using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.ChatRoom
{
    public class MessageIDIncrement
    {
        private int MessageID = 0;

        public MessageIDIncrement()
        {

        }

        public int IncrementID()
        {
            return MessageID++;
        }
    }
}
