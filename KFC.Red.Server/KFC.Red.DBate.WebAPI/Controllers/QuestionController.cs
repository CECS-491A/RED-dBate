using KFC.Red.ManagerLayer.QuestionManagement;
using KFC.Red.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    public class QuestionManagementRequest
    {
        [HttpBindRequired]
        public Question Question { get; set; }

        [HttpBindRequired]
        public int QuestionID { get; set; }

        [HttpBindRequired]
        public string QuestionString { get; set; }
    }

    public class QuestionController : ApiController
    {
        // http GET/POST/PUT/DELETE methods based on add/update/delete questions
        // see user controller in SSO
        [HttpPost]
        [Route("api/question/add")]
        public IHttpActionResult AddQuestion([FromBody] QuestionManagementRequest Request)
        {
            QuestionManager questionM = new QuestionManager();
            //Question question = new Question();
            if (questionM.ExistingQuestion(Request.QuestionString) == true)
            {
                return Content(HttpStatusCode.Conflict, "Question already exists");
            }
            
            // add question to database
        }

        [HttpPut]
        [Route("api/question/update")]
        public IHttpActionResult UpdateQuestion([FromBody] QuestionManagementRequest Request)
        {
            QuestionManager questionM = new QuestionManager();

            if (questionM.ExistingQuestion(Request.QuestionString) == true)
            {
                // update question
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
            //Question question = new Question();
            if (questionM.ExistingQuestion(Request.QuestionString) == true)
            {
                // remove question from database
            }
            else
            {
                return Content(HttpStatusCode.Conflict, "Question not in database.");
            }
        }
    }
}
