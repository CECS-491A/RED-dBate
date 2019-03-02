using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace KFC.Red.DBate.WebAPI
{

    public class ChatHub : Hub
    {

        public ChatHub()
        {

        }

        public ChatHub(string username)
        {

        }

        public void Send(string username, string message)
        {
            username = "bob";
            //message = ""
            // Call the addNewMessageToPage method to update clients.
            //Clients.All.addNewMessageToPage(name, message);
            //Clients.All.sendMessageToClients($"{username}: {message}");
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

            var toUser = "9";//ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
            var fromUser = "ko"; //ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

            if (toUser != null && fromUser != null)
            {
                // send to 
                //Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message);

                // send to caller user
                //Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message);
            }

        }

        /*
        public override System.Threading.Tasks.Task OnDisconnected()
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName);

            }

            return base.OnDisconnected();
        }
        */
    }
}