using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aplicacao.Core.Models;
using Aplicacao.Business.Interfaces;
using Aplicacao.Core.Dto;
using AutoMapper;
using System.Collections.Generic;
using System;
using Aplicacao.Api.Models;

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
        

        [HttpGet("{id}")]
        public ActionResult FindById(long id)
        {
           User user = _userService.FindById(id);
           return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserRequest request)
        {

            User userMap = _mapper.Map<User>(request);
            User userEntity = _userService.CreateUser(userMap);

            if(userEntity == null) return NoContent();

            UserViewModel model = _mapper.Map<UserViewModel>(userEntity);

            return Ok(model);
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
