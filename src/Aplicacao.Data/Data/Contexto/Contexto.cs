using Microsoft.EntityFrameworkCore;
using Aplicacao.Core.Models;

namespace Aplicacao.Data.Repositories
{
    public class Contexto : DbContext
    {
        public DbSet<User> users { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}