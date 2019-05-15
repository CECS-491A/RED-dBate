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

        //Send messages to group chatroom
        public void SendPrivateMessage(List<string> connectionIds, string username, string message)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext("HubService");
            context.Clients.Clients(connectionIds).messageReceived(username, message);
        }

        /// <summary>
        /// Broadcasts the user list to the clients
        /// </summary>
        public void SendUserList(List<string> userList)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext("DbateChatHub");
            context.Clients.All.pushUserList(userList);
        }

        public void Connect(string userName)
        {
            var id = Context.ConnectionId;
            var users = new UserService();
            var gameusers = new UserGameStorageService();

            using (var _db = new ApplicationDbContext())
            {
                var serv = new UserGameStorageService();
                    var user = users.GetUser(_db, userName);
                    var gameuser = gameusers.GetGameUser(_db, user.ID);
                    gameuser.ConnectionId = id;

                    var resp = gameusers.UpdateUGS(_db, gameuser);
                    _db.SaveChanges();

                    //var ConnectedUsers = _db.UserGameStorage
                    // send to caller
                    Clients.Caller.onConnected(id, userName);
                    Clients.Caller.onConnected(id, userName);
                    // send to all except caller client
                    //Clients.AllExcept(id).onNewUserConnected(id, userName);
            }
        }

        public Task OnDisconnected()
        {
            using (var _db = new ApplicationDbContext())
            {
                var item = us.GetUser(_db, int.Parse(Context.ConnectionId));
                if (item != null)
                {
                    item.IsUserPlaying = false;
                    us.UpdateUser(_db, item);
                    var id = Context.ConnectionId;
                    Clients.All.onUserDisconnected(id, item.Email);
                }
            }

            return OnDisconnected();
        }
    }
}
