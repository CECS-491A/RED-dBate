using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.DataAccessLayer.Repositories;
using KFC.Red.ServiceLayer.QuestionManagement.Interfaces;

namespace KFC.Red.ServiceLayer.QuestionManagement
{
    public class QuestionService : IQuestionService
    {
        private QuestionRepository _QuestionRepo;

        public QuestionService()
        {
            _QuestionRepo = new QuestionRepository();
        }

        public Question CreateQuestion(ApplicationDbContext _db, Question question)
        {
            if (_QuestionRepo.ExistingQuestion(_db, question.QuestionString))
            {
                throw new ArgumentException("A user with that email address already exists");
            }
            return _QuestionRepo.CreateNewQuestion(_db, question);
        }

        public Question DeleteQuestion(ApplicationDbContext _db, int Id)
        {
            return _QuestionRepo.DeleteQuestion(_db, Id);
        }

        public Question GetQuestion(ApplicationDbContext _db, string question)
        {
            return _QuestionRepo.GetQuestion(_db, question);
        }

        public Question GetQuestion(ApplicationDbContext _db, int Id)
        {
            return _QuestionRepo.GetQuestion(_db, Id);
        }

        public Question UpdateQuestion(ApplicationDbContext _db, Question question)
        {
            return _QuestionRepo.UpdateQuestion(_db, question);
        }

        public bool ExistingQuestion(ApplicationDbContext _db, string question)
        {
            return _QuestionRepo.ExistingQuestion(_db, question);
        }
    }
}
