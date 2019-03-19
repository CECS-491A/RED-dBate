using KFC.Red.DataAccessLayer;
using Microsoft.AspNet.SignalR;

namespace KFC.Red.DBate.WebAPI
{

    public class ChatHub : Hub
    {

        //private IRepository<User> _User;
        //Sprivate IUnitOfWork _uow;
        private ApplicationDbContext ctx;

        public ChatHub()
        {
            ctx = new ApplicationDbContext();
        }

        /*
        public ChatHub(IUnitOfWork uow)
        {
            _uow = uow;
            _User = _uow.GetRepository<User>();
        }
        */

        public ChatHub(string username)
        {

        }

        public void Send(string username, string message)
        {
            username = "bob";
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
        public override Task OnDisconnected(bool stopCalled)
        {
            using (ctx)
            {
                var connection = ctx.Connections.Find(Context.ConnectionId);
                connection.Connected = false;
                ctx.SaveChanges();
            }
            return base.OnDisconnected(stopCalled);
        } 
        */
    }
}