using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ServiceLayer.QuestionManagement;
using KFC.Red.ServiceLayer.QuestionManagement.Interfaces;

using System.Data.Entity.Validation;

namespace KFC.Red.ManagerLayer.QuestionManagement
{
    class QuestionManager
    {
        private IQuestionService _questionService;

        public QuestionManager()
        {
            _questionService = new QuestionService();
        }

        private ApplicationDbContext CreateDbContext()
        {
            return new ApplicationDbContext();
        }
        
        public int CreateQuestion(Question question)
        {
            using (var _db = CreateDbContext())
            {
                var response = _questionService.CreateQuestion(_db,question);               
                // will return null if question does not exist
                return _db.SaveChanges();
            }
        }
        
        public int DeleteQuestion(Question question)
        {
            using (var _db = CreateDbContext())
            {
                var response = _questionService.DeleteQuestion(_db, question.QuestionID);
                // will return null if question does not exist
                return _db.SaveChanges();
            }
        }

        public int DeleteQuestion(int id)
        {
            using (var _db = CreateDbContext())
            {
                var response = _questionService.DeleteQuestion(_db, id);
                return _db.SaveChanges();
            }
        }

        public Question GetQuestion(int id)
        {
            using (var _db = CreateDbContext())
            {
                return _questionService.GetQuestion(_db, id);
            }
        }

        public Question GetQuestion(string question)
        {
            using (var _db = CreateDbContext())
            {
                return _questionService.GetQuestion(_db, question);
            }
        }

        public int UpdateQuestion(Question question)
        {
            using (var _db = CreateDbContext())
            {
                var response = _questionService.UpdateQuestion(_db, question);
                try
                {
                    return _db.SaveChanges();
                }
                catch (DbEntityValidationException)
                {
                    // catch error
                    // rollback changes
                    _db.Entry(response).CurrentValues.SetValues(_db.Entry(response).OriginalValues);
                    _db.Entry(response).State = System.Data.Entity.EntityState.Unchanged;
                    return 0;
                }
            }
        }

        public bool ExistingQuestion(string question)
        {
            using (var _db = CreateDbContext())
            {
                return _questionService.ExistingQuestion(_db, question);
            }
        }
    }
}
