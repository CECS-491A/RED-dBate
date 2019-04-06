using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.DataAccessLayer.Repositories
{
    public class ChatRoomRepository
    {
        public Chatroom CreateNewChatroom(ApplicationDbContext _db, Chatroom chatroom)
        {
            _db.Entry(chatroom).State = EntityState.Added;
            return chatroom;
        }

        public Chatroom DeleteChatroom(ApplicationDbContext _db, int Id)
        {
            var chatroom = _db.ChatRooms
                .Where(c => c.ChatroomID == Id)
                .FirstOrDefault<Chatroom>();
            if (chatroom == null)
                return null;
            _db.Entry(chatroom).State = EntityState.Deleted;
            return chatroom;
        }

        public Chatroom DeleteChatroom(ApplicationDbContext _db, Chatroom chatroom)
        {
            if (chatroom == null)
                return null;
            _db.Entry(chatroom).State = EntityState.Deleted;
            return chatroom;
        }

        public Chatroom GetChatroom(ApplicationDbContext _db, int Id)
        {
            return _db.ChatRooms.Find(Id);
        }

        public Chatroom GetChatroom(ApplicationDbContext _db, Chatroom c)
        {
            int Id = c.ChatroomID;
            return _db.ChatRooms.Find(Id);
        }

        public bool ExistingChatroom(ApplicationDbContext _db, Chatroom chatroom)
        {
            var result = GetChatroom(_db, chatroom.ChatroomID);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public bool ExistingChatroom(ApplicationDbContext _db, int id)
        {
            var result = GetChatroom(_db, id);
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }
}
