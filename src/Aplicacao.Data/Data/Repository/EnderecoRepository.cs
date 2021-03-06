using System.Collections.Generic;
using System.Linq;
using Aplicacao.Core.Models;
using Aplicacao.Business.Interfaces;

namespace Aplicacao.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly Contexto _context;

        public EnderecoRepository(Contexto contexto) 
        {
            _context = contexto;
        }

        public Endereco FindByCEP(string CEP)
        {
           Endereco endereco = _context.enderecos.Where(endereco => endereco.CEP == CEP).FirstOrDefault();

           if(_context.users.Where(u => u.UserId == endereco.UserForeignKey).Any())
           {
                User user = _context.users.First(u => u.UserId == endereco.UserForeignKey); 
                endereco.User = user;
           }
           
           return endereco;
        }

        public List<Endereco> FindAll()
        {
            List<Endereco> enderecos = new List<Endereco>();
            enderecos = _context.enderecos.ToList();
            return enderecos;
        }

        
        public Endereco Create(string cep) 
        {
            if(isExist(cep))
            {
                return _context.enderecos.Where(endereco => endereco.CEP == cep).FirstOrDefault();
            }

            Endereco endereco = ConsultaSoap.GetEnderecoByCep(cep);

            if (endereco.UserForeignKey >= 0)
            {
                endereco.User = _context.users
                                .Where(u => u.UserId == endereco.UserForeignKey)
                                .FirstOrDefault();
            }
            
            _context.enderecos.Add(endereco);
            _context.SaveChanges();

            return endereco;
        }

        public bool isExist(string cep)
        {
            return _context.enderecos.Where(endereco => endereco.CEP == cep).Any();
        }

    }
}