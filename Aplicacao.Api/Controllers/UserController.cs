using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aplicacao.Core.Models;
using Aplicacao.Business.Interfaces;

namespace Aplicacao.Api.Controllers
{
    [ApiController]
    [Route("/api/user")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService service)
        {
           _userService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.FindAll());
        }

      
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            
            User userClient = _userService.CreateUser(user);
            if (userClient != null) return Ok(userClient);

            return BadRequest("Duplicate id or could not insert this user.");
        }

     
        [HttpPut]
        public IActionResult  Put([FromBody] User user)
        {
            _userService.EditUser(user);
            return Ok(user);
        }

    
       
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] long id)
        {
            bool userNotFound = _userService.FindById(id) == null;
            if(userNotFound)
            {
                return NotFound("User not found");
            }

            _userService.Delete(id);
            return NoContent();
        }

    }
}
