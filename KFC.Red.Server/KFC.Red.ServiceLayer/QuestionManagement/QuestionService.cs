using System;
using System.Security.Cryptography;
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
                throw new ArgumentException("The question to be created already exists");
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

        // random number generator

        private static RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public int GetNumberForRandomization(int minValue, int maxValue)
        {
            //byte array that holds the random number
            byte[] randomNum = new byte[1];

            //fills byte array with random values
            _generator.GetBytes(randomNum);

            //convert randomNum to double 
            double asciiValue = Convert.ToDouble(randomNum[0]);

            //keeps multiplier between 0.0 and .99999999999 for rounding purposes
            double multiplier = Math.Max(0, (asciiValue / 255d) - 0.00000000001d);

            //adding 1 to range for rounding purposes
            int range = maxValue - minValue + 1;

            double randomNumInRange = Math.Floor(multiplier * range);

            return (int)(minValue + randomNumInRange);
        }
    }
}
