using Microsoft.EntityFrameworkCore;
using Aplicacao.Core.Models;

namespace Aplicacao.Data.Repositories
{
    public class Contexto : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Endereco> enderecos { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //S1: Chave Primária para a tabela User
            modelBuilder.Entity<User>().HasKey(c => c.Id);

            //S1: Chave Primária para a tabela Endereco
            modelBuilder.Entity<Endereco>().HasKey(endereco => endereco.Id);

         
        }

    }
}