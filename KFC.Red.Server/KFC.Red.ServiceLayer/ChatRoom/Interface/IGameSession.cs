using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.ChatRoom.Interface
{
    public interface IGameSession
    {
        GameSession CreateGameSession(ApplicationDbContext _db, GameSession gamesession);
        GameSession GetGameSession(ApplicationDbContext _db, GameSession gamesession);
        GameSession GetGameSession(ApplicationDbContext _db, int Id);
        GameSession DeleteGameSession(ApplicationDbContext _db, int Id);
        GameSession DeleteGameSession(ApplicationDbContext _db, GameSession gamesession);
        bool ExistingGameSession(ApplicationDbContext _db, GameSession gamesession);
        bool ExistingGameSession(ApplicationDbContext _db, int id);
    }
}
