using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ManagerLayer.QuestionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    public class QuestionController : ApiController
    {
        public class QuestionManagementRequest
        {
            public int QuestionID { get; set; }
            public string QuestionString { get; set; }
        }

        [HttpGet]
        [Route("api/question/randomquestion")]
        public IHttpActionResult GetRandomQuestion()
        {
            QuestionManager questionM = new QuestionManager();
            return Ok(questionM.RandomizeQuestion());
        }

        [HttpPost]
        [Route("api/question/add")]
        public IHttpActionResult AddQuestion([FromBody] QuestionManagementRequest Request)
        {
            QuestionManager questionM = new QuestionManager();
            if (questionM.ExistingQuestion(Request.QuestionString) == false)
            {
                return Ok(questionM.CreateQuestion(Request.QuestionID, Request.QuestionString));
            }
            else
            {
                return Content(HttpStatusCode.Conflict, "Question already exists");
            }
        }

        [HttpPut]
        [Route("api/question/update")]
        public IHttpActionResult UpdateQuestion([FromBody] QuestionManagementRequest Request)
        {
            QuestionManager questionM = new QuestionManager();
            if (questionM.ExistingQuestion(Request.QuestionString) == true)
            {
                return Ok(questionM.UpdateQuestion(Request.QuestionID, Request.QuestionString));
            }
            else
            {
                return Content(HttpStatusCode.Conflict, "Question not in database.");
            }
        }

        [HttpDelete]
        [Route("api/question/delete")]
        public IHttpActionResult DeleteQuestion([FromBody] QuestionManagementRequest Request)
        {
            QuestionManager questionM = new QuestionManager();
            if (questionM.ExistingQuestion(Request.QuestionString) == true)
            {
                return Ok(questionM.DeleteQuestion(Request.QuestionID));
            }
            else
            {
                return Content(HttpStatusCode.Conflict, "Question not in database.");
            }
        }
    }
}
