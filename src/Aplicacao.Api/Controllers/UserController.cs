using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aplicacao.Core.Models;
using Aplicacao.Business.Interfaces;
using Aplicacao.Core.Dto;
using AutoMapper;
using System.Collections.Generic;
using System;
using Aplicacao.Api.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Api.Controllers
{
    /// <summary>
    /// UserController
    /// </summary>
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
        
        /// <summary>
        /// Get user by id number
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> FindById(long id)
        {
           //User user = _userService.FindById(id);
           //return Ok(_mapper.Map<UserDto>(user));
           User user = await _userService.FindByIdAsync(id);
           return Ok(_mapper.Map<UserDto>(user));
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpPost]
        public ActionResult<UserViewModel> Post([FromBody]UserRequest request)
        {

            User userMap = _mapper.Map<User>(request);
            User userEntity = _userService.CreateUser(userMap);

            if(userEntity == null) return NoContent();

            UserViewModel model = _mapper.Map<UserViewModel>(userEntity);

            return Ok(model);
        }

        /// <summary>
        /// User delete.
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

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
