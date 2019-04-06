using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.QuestionManagement.Interfaces
{
    public interface IQuestionService
    {
        Question CreateQuestion(ApplicationDbContext _db, Question question);
        Question GetQuestion(ApplicationDbContext _db, string question);
        Question GetQuestion(ApplicationDbContext _db, int Id);
        Question DeleteQuestion(ApplicationDbContext _db, int Id);
        Question UpdateQuestion(ApplicationDbContext _db, Question question);
        bool ExistingQuestion(ApplicationDbContext _db, string question);
        int GetNumberForRandomization(int minValue, int maxValue);
    }
}
