using Microsoft.AspNetCore.Mvc;
using Aplicacao.Core.Models;
using Aplicacao.Business.Interfaces;
using AutoMapper;
using Aplicacao.Api.Models;
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="mapper"></param>
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
        /// <response code="403">Forbidden. Resource access is denied</response>
        /// <response code="404">Resource not found</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> FindById(long id)
        {
           User user = await _userService.FindByIdAsync(id).ConfigureAwait(false);
           return Ok(_mapper.Map<UserViewModel>(user));
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="403">Forbidden. Resource access is denied</response>
        /// <response code="404">Resource not found</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>
        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Post([FromBody]UserRequest request, string cep)
        {

            User userMap = _mapper.Map<User>(request);
            User userEntity = await _userService.CreateUserAsync(userMap, cep).ConfigureAwait(false);

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
        /// <response code="403">Forbidden. Resource access is denied</response>
        /// <response code="404">Resource not found</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] long id)
        {
            _userService.Delete(id);
            return NoContent();
        }

    }
}
