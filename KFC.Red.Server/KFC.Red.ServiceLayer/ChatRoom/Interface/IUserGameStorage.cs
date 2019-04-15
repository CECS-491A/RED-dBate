using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.ChatRoom.Interface
{
    public interface IUserGameStorage
    {
        UserGameStorage CreateUGS(ApplicationDbContext _db, UserGameStorage gamesession);
        UserGameStorage DeleteUGS(ApplicationDbContext _db, int Id);
    }
}
