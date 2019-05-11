using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ServiceLayer.ChatRoom.Interface;
using KFC.RED.DataAccessLayer.Repositories;

namespace KFC.Red.ServiceLayer.ChatRoom
{
    public class UserGameStorageService : IUserGameStorage
    {
        private UserGameStorageRepository _UGSRepo;

        public UserGameStorageService()
        {
            _UGSRepo = new UserGameStorageRepository();
        }

        public UserGameStorage CreateUGS(ApplicationDbContext _db, UserGameStorage userGameStorage)
        {
            return _UGSRepo.CreateNewUGS(_db, userGameStorage);
        }

        public UserGameStorage DeleteUGS(ApplicationDbContext _db, int id)
        {
            return _UGSRepo.DeleteUGS(_db, id);
        }

        public UserGameStorage UpdateUGS(ApplicationDbContext _db, UserGameStorage userGameStorage)
        {
            return _UGSRepo.UpdateUGS(_db, userGameStorage);
        }
    }
}
