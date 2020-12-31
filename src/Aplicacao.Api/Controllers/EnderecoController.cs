using Microsoft.AspNetCore.Mvc;
using Aplicacao.Core.Models;
using Aplicacao.Business.Interfaces;
using AutoMapper;
using Aplicacao.Core.Dto;
using System.Collections.Generic;
using System;

namespace Aplicacao.Api.Controllers
{
    [ApiController]
    [Route("/api/endereco")]
    public class EnderecoController : ControllerBase
    {
        private IEnderecoService _enderecoService;
        private IMapper _mapper;

        public EnderecoController (IEnderecoService enderecoService, IMapper mapper) {
           _enderecoService = enderecoService;
           _mapper = mapper;
        }

    /*    [HttpGet]
        public IActionResult Get()
        {
           return Ok(_enderecoService.FindAll());
        }
        */

    
        [HttpPost]
        public IActionResult Post(string cep)
        {
            return Ok(_enderecoService.Create(cep));
        }
    

        [HttpGet("{cep}")]
        public IActionResult Get([FromRoute] string cep)
        {
            Endereco endereco = _enderecoService.GetEnderecoByCep(cep);
            return Ok(_mapper.Map<EnderecoDto>(endereco));

        }

    }
}
