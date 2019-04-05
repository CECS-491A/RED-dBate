using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ServiceLayer.ChatRoom;
using KFC.Red.ServiceLayer.ChatRoom.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ManagerLayer.ChatroomManager
{
    public class ChatroomManager
    {
        private IChatroom _chatroomService;

        public ChatroomManager()
        {
            _chatroomService = new ChatRoomService();
        }

        private ApplicationDbContext CreateDbContext()
        {
            return new ApplicationDbContext();
        }

        public int CreateChatroom(Chatroom chatroom)
        {
            using (var _db = CreateDbContext())
            {
                var response = _chatroomService.CreateChatroom(_db, chatroom);
                // will return null if question does not exist
                return _db.SaveChanges();
            }
        }

        public int DeleteChatroom(Chatroom chatroom)
        {
            using (var _db = CreateDbContext())
            {
                var response = _chatroomService.DeleteChatroom(_db, chatroom.ChatroomID);
                // will return null if chatroom does not exist
                return _db.SaveChanges();
            }
        }

        public int DeleteChatroom(int id)
        {
            using (var _db = CreateDbContext())
            {
                var response = _chatroomService.DeleteChatroom(_db, id);
                return _db.SaveChanges();
            }
        }

        public Chatroom GetChatroom(int id)
        {
            using (var _db = CreateDbContext())
            {
                return _chatroomService.GetChatroom(_db, id);
            }
        }

        public Chatroom GetChatroom(Chatroom chatroom)
        {
            using (var _db = CreateDbContext())
            {
                return _chatroomService.GetChatroom(_db, chatroom);
            }
        }

        public bool ExistingChatroom(int id)
        {
            using (var _db = CreateDbContext())
            {
                return _chatroomService.ExistingChatroom(_db, id);
            }
        }

        public bool ExistingChatroom(Chatroom chatroom)
        {
            using (var _db = CreateDbContext())
            {
                return _chatroomService.ExistingChatroom(_db, chatroom);
            }
        }
    }
}
