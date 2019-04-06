using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.DataAccessLayer.Repositories;
using KFC.Red.ServiceLayer.ChatRoom.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.ChatRoom
{
    public class ChatRoomService : IChatroom
    {
        private ChatRoomRepository _ChatroomRepo;

        public ChatRoomService()
        {
            _ChatroomRepo = new ChatRoomRepository();
        }

        public Chatroom CreateChatroom(ApplicationDbContext _db, Chatroom chatroom)
        {
            if (_ChatroomRepo.ExistingChatroom(_db, chatroom.ChatroomID))
            {
                throw new ArgumentException("A chatroom with that ID already exists");
            }
            return _ChatroomRepo.CreateNewChatroom(_db, chatroom);
        }

        public Chatroom DeleteChatroom(ApplicationDbContext _db, int id)
        {
            return _ChatroomRepo.DeleteChatroom(_db, id);
        }

        public Chatroom DeleteChatroom(ApplicationDbContext _db, Chatroom chatroom)
        {
            return _ChatroomRepo.DeleteChatroom(_db, chatroom);
        }

        public Chatroom GetChatroom(ApplicationDbContext _db, Chatroom chatroom)
        {
            return _ChatroomRepo.GetChatroom(_db, chatroom);
        }

        public Chatroom GetChatroom(ApplicationDbContext _db, int id)
        {
            return _ChatroomRepo.GetChatroom(_db, id);
        }

        public bool ExistingChatroom(ApplicationDbContext _db, Chatroom chatroom)
        {
            return _ChatroomRepo.ExistingChatroom(_db, chatroom);
        }

        public bool ExistingChatroom(ApplicationDbContext _db, int id)
        {
            return _ChatroomRepo.ExistingChatroom(_db, id);
        }
    }
}
