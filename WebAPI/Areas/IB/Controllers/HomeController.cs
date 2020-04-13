using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Areas.IB.IRepository;
using WebAPI.Areas.IB.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebAPI.Areas.IB.Controllers
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("Area/Home")]
    [ApiController]
    public class HomeController : Controller
    {

        private readonly IUser _repository;

        public HomeController(IUser user)
        {
            _repository = user;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Userlist> users = _repository.GetAll();
            if (users != null)
                return Ok(users);
            return BadRequest("Something went wrong!");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Userlist user = _repository.Get(id);

            if (user != null)
                return Ok(user);

            return BadRequest("Something went wrong!");
        }
    }
}