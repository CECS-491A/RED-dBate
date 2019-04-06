using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.ChatRoom.Interface
{
    public interface IChatroom
    {
        Chatroom CreateChatroom(ApplicationDbContext _db, Chatroom chatroom);
        Chatroom GetChatroom(ApplicationDbContext _db, Chatroom chatRoom);
        Chatroom GetChatroom(ApplicationDbContext _db, int Id);
        Chatroom DeleteChatroom(ApplicationDbContext _db, int Id);
        Chatroom DeleteChatroom(ApplicationDbContext _db, Chatroom chatroom);
        bool ExistingChatroom(ApplicationDbContext _db, Chatroom chatroom);
        bool ExistingChatroom(ApplicationDbContext _db, int id);
    }
}
