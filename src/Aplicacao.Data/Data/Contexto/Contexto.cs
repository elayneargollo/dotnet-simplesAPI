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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>().ToTable("enderecos");
            builder.Entity<Endereco>().HasKey(p => p.EnderecoId);

            builder.Entity<Endereco>().Property<long>("UserForeignKey");
            builder.Entity<Endereco>().HasOne(p => p.User).WithMany(b => b.Enderecos).HasForeignKey(p => p.UserForeignKey);
          //  builder.Entity<Endereco>().HasOne(d => d.User).WithMany().OnDelete(DeleteBehavior.Restrict);
        }

    }

}