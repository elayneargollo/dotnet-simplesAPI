using System;
using System.Collections.Generic;
using Aplicacao.Core.Models;
using Aplicacao.Business.Interfaces;

namespace Aplicacao.Data.Repositories
{
    public class ConsultaSoap 
    {
        public static Endereco GetEnderecoByCep(string cep)
        {
            Endereco endereco = new Endereco();
            
           var service = new CorreioService.AtendeClienteClient();

            var retorno = service.consultaCEPAsync(cep);
            var info = retorno.Result.@return;

            endereco.CEP = info.cep;
            endereco.Cidade = info.cidade;
            endereco.Bairro = info.bairro;
            endereco.End = info.end;
            endereco.UF = info.uf; 

            return endereco;
        }   
           
    }
}
