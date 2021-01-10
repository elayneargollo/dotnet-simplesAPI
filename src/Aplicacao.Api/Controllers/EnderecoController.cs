using Microsoft.AspNetCore.Mvc;
using Aplicacao.Core.Models;
using Aplicacao.Business.Interfaces;
using AutoMapper;
using Aplicacao.Core.Dto;
using System.Collections.Generic;
using System;

namespace Aplicacao.Api.Controllers
{
    /// <summary>
    /// AddressController
    /// </summary>
    [ApiController]
    [Route("/api/endereco")]
    public class EnderecoController : ControllerBase
    {
        private IEnderecoService _enderecoService;
        private IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="enderecoService"></param>
        /// <param name="mapper"></param>
        public EnderecoController (IEnderecoService enderecoService, IMapper mapper) {
           _enderecoService = enderecoService;
           _mapper = mapper;
        }
    
        /// <summary>
        /// Create address
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="403">Forbidden. Resource access is denied</response>
        /// <response code="404">Resource not found</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpPost]
        public IActionResult Post(string cep)
        {
            return Ok(_enderecoService.Create(cep));
        }

        /// <summary>
        /// Get address by cep number
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Business logic error, see return message for more info</response>
        /// <response code="401">Unauthorized. Token not present, invalid or expired</response>
        /// <response code="403">Forbidden. Resource access is denied</response>
        /// <response code="404">Resource not found</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>
        
        [HttpGet("{cep}")]
        public IActionResult Get([FromRoute] string cep)
        {
            Endereco endereco = _enderecoService.GetEnderecoByCep(cep);

            if (endereco == null)
            {
                return NoContent();
            }
            
            return Ok(_mapper.Map<UserEnderecoDto>(endereco));

        }

    }
}
