using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;
using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;

namespace KFC.Red.DataAccessLayer.Repositories
{
    public class QuestionRepository
    {
        public Question CreateNewQuestion(ApplicationDbContext _db, Question question)
        {
            _db.Entry(question).State = EntityState.Added;
            return question;
        }

        public Question DeleteQuestion(ApplicationDbContext _db, int Id)
        {
            var question = _db.Questions
                .Where(c => c.QuestionID == Id)
                .FirstOrDefault<Question>();
            if (question == null)
                return null;
            _db.Entry(question).State = EntityState.Deleted;
            return question;
        }

        public Question GetQuestion(ApplicationDbContext _db, string questionString)
        {
            var question = _db.Questions
                .Where(c => c.QuestionString == questionString)
                .FirstOrDefault<Question>();
            return question;
        }

        public Question GetQuestion(ApplicationDbContext _db, int Id)
        {
            return _db.Questions.Find(Id);
        }

        public Question UpdateQuestion(ApplicationDbContext _db, Question question)
        {
            _db.Entry(question).State = EntityState.Modified;
            return question;
        }

        public bool ExistingQuestion(ApplicationDbContext _db, Question question)
        {
            var result = GetQuestion(_db, question.QuestionString);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public bool ExistingQuestion(ApplicationDbContext _db, string questionString)
        {
            var result = GetQuestion(_db, questionString);
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }
}
