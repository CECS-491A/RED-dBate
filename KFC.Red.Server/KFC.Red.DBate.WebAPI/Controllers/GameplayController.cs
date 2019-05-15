using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KFC.Red.ManagerLayer.ChatroomManager;
using KFC.Red.ManagerLayer.UserManagement;
using KFC.RED.DataAccessLayer.DTOs;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    public class GameplayController : ApiController
    {
        private GameplayManager _GameMan;

        public GameplayController()
        {
            _GameMan = new GameplayManager();

        }

        [HttpGet]
        [Route("api/gameplay/assignhost")]
        public IHttpActionResult AssignHost([FromBody]GameRoleDTO grDto)
        {
            var userManager = new UserManager();
            var u =  _GameMan.AssignHost(grDto.SsoId);
            var user = userManager.GetUser(grDto.SsoId);
            return Ok(user.Role);
        }

        [HttpGet]
        [Route("api/gameplay/assignplayer")]
        public IHttpActionResult AssignPlayer([FromBody]GameRoleDTO grDto)
        {
            var userManager = new UserManager();
            var u = _GameMan.AssignPlayer(grDto.SsoId);
            var user = userManager.GetUser(grDto.SsoId);
            return Ok(user.Role);
        }

        [HttpGet]
        [Route("api/gameplay/getorder")]
        public IHttpActionResult GetOrder([FromBody]GameRoleDTO grDto)
        {
            var userManager = new UserManager();
            var ugsManager = new UserGameStorageManager();
            var user = userManager.GetUser(grDto.SsoId);
            var order = ugsManager.GetUserGameStorage(user.ID).Order;
            return Ok(order);

        }

    }
}