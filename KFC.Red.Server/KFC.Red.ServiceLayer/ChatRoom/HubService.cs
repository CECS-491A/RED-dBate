using KFC.Red.DataAccessLayer.Data;
using KFC.RED.DataAccessLayer.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.ChatRoom
{
    [HubName("DbateChatHub")]
    public class HubService : Hub
    {
        public void SendMessage(ChatMessage chatItem)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext("DbateChatHub");
            context.Clients.All.pushNewMessage(chatItem.Id, chatItem.UserId, chatItem.Username, chatItem.Message, chatItem.DateTime);
        }


        /// <summary>
        /// Broadcasts the user list to the clients
        /// </summary>
        public void SendUserList(List<string> userList)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext("DbateChatHub");
            context.Clients.All.pushUserList(userList);
        }
    }
}
