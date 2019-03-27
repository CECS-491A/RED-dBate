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
            public Question question { get; set; }
            public int QuestionID { get; set; }
            public string QuestionString { get; set; }
        }

        // http GET/POST/PUT/DELETE methods based on add/update/delete questions
        [HttpPost]
        [Route("api/question/add")]
        public IHttpActionResult AddQuestion([FromBody] QuestionManagementRequest Request)
        {
            QuestionManager questionM = new QuestionManager();
            if (questionM.ExistingQuestion(Request.QuestionString) == true)
            {
                return Content(HttpStatusCode.Conflict, "Question already exists");
            }
            questionM.CreateQuestion(Request.question);
        }

        [HttpPut]
        [Route("api/question/update")]
        public IHttpActionResult UpdateQuestion([FromBody] QuestionManagementRequest Request)
        {
            QuestionManager questionM = new QuestionManager();
            if (questionM.ExistingQuestion(Request.QuestionString) == true)
            {
                questionM.UpdateQuestion(Request.question);
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
                questionM.DeleteQuestion(Request.QuestionID);
            }
            else
            {
                return Content(HttpStatusCode.Conflict, "Question not in database.");
            }
        }
    }
}
