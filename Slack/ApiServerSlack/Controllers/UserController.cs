using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiServerSlack.DAO;
using ApiServerSlack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiServerSlack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        IDataAccess<User, int> _dao=new UserDAO();
        
        [Route("create")]
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {

            if (_dao.Create(user))
            {
                Response.StatusCode = 201;//HTTP status code created
                return CreatedAtAction(nameof(Post), new { id = user.Id }, user);
            }
            // Created(Request.Host.ToString() + Request.Path + "user" + user.Id, user);
            else
                return BadRequest();


        }

        [HttpGet]
        public bool Get() {
            return true;
        }
    }
}