using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace CECS491_DBate_WebAPI
{

    public class ChatHub : Hub
    {

        public ChatHub()
        {

        }

        public ChatHub(string username)
        {

        }

        public void Hello()
        {
            Clients.All.hello();
        }

        public void Send(string message)
        {
            // Call the addNewMessageToPage method to update clients.
            //Clients.All.addNewMessageToPage(name, message);
            Clients.All.sendMessageToClients($"[{DateTime.Now}] <b>Person 1 says:</b> {message}");
        }
    }
}