using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aplicacao.Core.Models;
using Aplicacao.Business.Interfaces;
using Aplicacao.Core.Dto;
using AutoMapper;
using System.Collections.Generic;
using System;

namespace Aplicacao.Api.Controllers
{
    [ApiController]
    [Route("/api/user")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
           _userService = service;
           _mapper = mapper;
        }

         
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.FindAll());

        }
        

        /*   
        [HttpPost]
        public IActionResult Post([FromBody] UserDto user)
        {
            
            User userClient = _userService.CreateUser(_mapper.Map<User>(user));
            if (userClient != null) return Ok((_mapper.Map<UserDto>(userClient)));

            return BadRequest("Duplicate id or could not insert this user.");
        }
        */

        /*
        [HttpPut]
        public IActionResult  Put([FromBody] User user)
        {
            _userService.EditUser(user);
            return Ok(user);
        }
        */

        [HttpGet("{id}")]
        public ActionResult FindById(long id)
        {
           User user = _userService.FindById(id);
           return Ok(_mapper.Map<UserDto>(user));
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
