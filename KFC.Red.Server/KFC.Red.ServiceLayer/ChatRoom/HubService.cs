using KFC.Red.DataAccessLayer.Data;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Collections.Generic;
using System.Threading.Tasks;
using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.ServiceLayer.UserManagement;

namespace KFC.Red.ServiceLayer.ChatRoom
{
    public class HubService : Hub
    {
        UserService us;

        public HubService()
        {
            us = new UserService();
        }

        //Send Messages in main chatroom
        public void Send(string username, string message)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext("HubService");
            context.Clients.All.messageReceived(username, message);
        }
    }
}
