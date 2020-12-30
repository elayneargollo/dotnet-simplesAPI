using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aplicacao.Core.Models;
using Aplicacao.Business.Interfaces;

namespace Aplicacao.Api.Controllers
{
    [ApiController]
    [Route("/api/endereco")]
    public class EnderecoController : ControllerBase
    {
        private IEnderecoService _enderecoService;

        public EnderecoController (IEnderecoService enderecoService) => _enderecoService = enderecoService;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_enderecoService.FindAll());
        }

        [HttpPost]
        public IActionResult Post(string cep)
        {
            return Ok(_enderecoService.Create(cep));
        }

        [HttpGet("{cep}")]
        public IActionResult Get([FromRoute] string cep)
        {
            return Ok(_enderecoService.GetEnderecoByCep(cep));
        }

    }
}
