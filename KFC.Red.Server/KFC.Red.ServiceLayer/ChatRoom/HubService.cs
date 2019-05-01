using KFC.Red.DataAccessLayer.Data;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Collections.Generic;
using System.Threading.Tasks;
using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.ServiceLayer.UserManagement;

namespace KFC.Red.ServiceLayer.ChatRoom
{
    [HubName("DbateChatHub")]
    public class HubService : Hub
    {
        UserService us;

        public HubService()
        {
            us = new UserService();
        }

        public void SendMessage(ChatMessageDTO chatItem)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext("DbateChatHub");
            context.Clients.All.pushNewMessage(chatItem.Username, chatItem.Message);
        }

        public void SendPrivateMessage(PrivateMessageDTO privateMessageDTO)
        {

            IHubContext context = GlobalHost.ConnectionManager.GetHubContext("DbateChatHub");
            using (var _db = new ApplicationDbContext())
            {
                string fromUserId = Context.ConnectionId;

                var fromUser = us.GetUser(_db, int.Parse(fromUserId));

                if (fromUser != null)
                {
                    // send to 
                    Clients.Clients(privateMessageDTO.userIDs).sendPrivateMessage(fromUserId, fromUser.Email, "MESSAGE PLACEHOLDER");
                    
                    // send to caller user
                    Clients.Caller.sendPrivateMessage(privateMessageDTO.userIDs, fromUser.Email, "Message PLACEHOLDER");
                }

            }

        }

        /// <summary>
        /// Broadcasts the user list to the clients
        /// </summary>
        public void SendUserList(List<string> userList)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext("DbateChatHub");
            context.Clients.All.pushUserList(userList);
        }

        public void Connect(string email)
        {
            using(var _db = new ApplicationDbContext())
            {
                var user = us.GetUser(_db, email);

                if (!user.IsUserPlaying)
                {
                    user.IsUserPlaying = true;
                    us.UpdateUser(_db,user);

                    // send to caller
                    Clients.Caller.onConnected(user.ID.ToString(),user.Email,"Connected USERS PLACEHOLDER","Current Message");

                    // send to all except caller client
                    Clients.AllExcept(user.ID.ToString()).onNewUserConnected(user.ID.ToString(), user.Email);

                }
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
