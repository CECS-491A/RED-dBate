using KFC.Red.DataAccessLayer;
using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ManagerLayer.UserManagement;
using KFC.RED.DataAccessLayer.Models;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KFC.Red.DBate.WebAPI
{

    public class ChatHub : Hub
    {

        //private IRepository<User> _User;
        //Sprivate IUnitOfWork _uow;
        private ApplicationDbContext ctx;
        private UserManagement um;
        private Repository<User> rep;
        List<User> users;

        static List<UserConnection> ConnectedUsers = new List<UserConnection>();
        static List<MessageDetail> CurrentMessage = new List<MessageDetail>();

        public ChatHub()
        {
            um = new UserManagement();
            ctx = new ApplicationDbContext();
            //users = um.GetAllUsers();
        }

        public void Connect(string username)
        {
            var id = Context.ConnectionId;

                if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
                {
                    ConnectedUsers.Add(new UserConnection { ConnectionId = id, Username = username });

                    // send to caller
                    Clients.Caller.onConnected(id, username, ConnectedUsers, CurrentMessage);

                    // send to all except caller client
                    Clients.AllExcept(id).onNewUserConnected(id, username);

                }
        }

        public void Send(string username, string message)
        {
            //username = "bob";
            Clients.All.broadcastMessage(username, message);
        }

        /// <summary>
        /// User to send private message among your respective group
        /// </summary>
        /// <param name="toUserId"></param>
        /// <param name="message"></param>
        public void SendPrivateMessage(string toUserId, string message)
        {

            string fromUserId = Context.ConnectionId;

            var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
            var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

            if (toUser != null && fromUser != null)
            {
                // send to 
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.Username, message);

                // send to caller user
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.Username, message);
            }

        }

        public Task OnDisconnected()
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.Username);

            }

            return OnDisconnected();
        }

        private void AddMessageinCache(int id, string message)
        {
            CurrentMessage.Add(new MessageDetail { UserId = id, Message = message });

            if (CurrentMessage.Count > 100)
                CurrentMessage.RemoveAt(0);
        }
    }
}