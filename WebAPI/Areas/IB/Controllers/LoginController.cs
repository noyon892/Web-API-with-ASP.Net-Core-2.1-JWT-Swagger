using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Areas.IB.IRepository;
using WebAPI.Areas.IB.Models;
using WebAPI.Helper;

namespace WebAPI.Areas.IB.Controllers
{
    [Route("Area/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _repository;

        public LoginController(ILogin login)
        {
            _repository = login;
        }

        [HttpPost]
        public IActionResult Login(Userlist us)
        {
            TokenModel user = _repository.Authenticate(us.Username,us.Password);

            if (user == null)
            {
                return BadRequest(new {message="Username or Password Incorrect"});
            }
            return Ok(user);
        }
    }
}