using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiServerSlack.DAO;
using ApiServerSlack.Models;
using ApiServerSlack.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiServerSlack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private UserDAO _dao;
        ILogger _logger;

        internal UserDAO Dao { get => _dao; set => _dao = value; }

        public UserController()
        {
            Dao = new UserDAO();
            _logger = new Logger();

        }

        [Route("create")]
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (Dao.Create(user))
            {
               Response.StatusCode = (int)HttpStatusCode.Created;
                return CreatedAtAction(nameof(Post), new { id = user.Id }, user);
            }
            else
                return BadRequest();


        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (Dao.Create(user))
            {
                Response.StatusCode = 201;//HTTP status code created
                return CreatedAtAction(nameof(Post), new { id = user.Id }, user);
            }
            // Created(Request.Host.ToString() + Request.Path + "user" + user.Id, user);
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult PostLogin([FromBody] User user)
        {
            return new JsonResult(new { token = _logger.LoginGetToken(user) });
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IDomainObject user = Dao.Retrieve(id) ;
            if (user!=null)
            {
                Response.StatusCode = 200;//HTTP status code created
                return  Ok(user);
            }
            // Created(Request.Host.ToString() + Request.Path + "user" + user.Id, user);
            else
                return NotFound();
        }





    }
}