using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ManagerLayer.QuestionManagement;
using KFC.RED.DataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class QuestionController : ApiController
    {

        [HttpGet]
        [Route("api/question/randomquestion")]
        public IHttpActionResult GetRandomQuestion()
        {
            QuestionManager questionM = new QuestionManager();
            return Ok(questionM.RandomizeQuestion());
        }

        [HttpGet]
        [Route("api/question/getquestions")]
        public List<Question> GetAllQuestions()
        {

            List<Question> questionData = new List<Question>();
            QuestionManager questionM = new QuestionManager();
            var serializer = new JavaScriptSerializer();
            var _db = questionM.CreateDbContext();

            var query = from models in _db.Questions select models;

            foreach (var item in query.ToList())
            {
                questionData.Add(
                    new Question
                    {
                        QuestionID = item.QuestionID,
                        QuestionString = item.QuestionString
                    });
            }

            var serializedResult = serializer.Serialize(questionData);

            return questionData;
        }


        [HttpPost]
        [Route("api/question/add")]
        public IHttpActionResult AddQuestion([FromBody] QuestionDTO Request)
        {
            QuestionManager questionM = new QuestionManager();
            bool isExist = questionM.ExistingQuestion(Request.QuestionString);
            if (isExist == false)
            {
                questionM.CreateQuestion(Request.QuestionString);
                return Ok("Succesfully Added");
            }
            else
            {
                return Content(HttpStatusCode.Conflict, "Question already exists");
            }
        }

        [HttpPost]
        [Route("api/question/delete")]
        public IHttpActionResult DeleteQuestion([FromBody] QuestionDTO RequestQuestion)
        {
            QuestionManager questionM = new QuestionManager();
            if (questionM.ExistingQuestion(RequestQuestion.QuestionString) == true)
            {
                Question q = questionM.GetQuestion(RequestQuestion.QuestionString);
                questionM.DeleteQuestion(q);
                return Ok("Successful");
            }
            else
            {
                return Content(HttpStatusCode.Conflict, "Question not in database.");
            }
        }
    }
}
