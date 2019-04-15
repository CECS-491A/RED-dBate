using KFC.Red.DataAccessLayer.Data;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFC.Red.DataAccessLayer.Models;
using KFC.RED.DataAccessLayer.DTOs;

namespace KFC.Red.ServiceLayer.ChatRoom
{
    [HubName("DbateChatHub")]
    public class HubService : Hub
    {
        public void SendMessage(ChatMessageDTO chatItem)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext("DbateChatHub");
            context.Clients.All.pushNewMessage(chatItem.Username, chatItem.Message);
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
