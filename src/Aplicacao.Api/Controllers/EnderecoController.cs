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

     /*   [HttpGet] // https://localhost:5001/api/endereco/?CEP=seuCEP
        public IActionResult GetEnderecoByCep(string CEP)
        {
            return Ok(_enderecoService.GetEnderecoByCep(CEP));

        }*/

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_enderecoService.FindAll());
        }
    }
}
