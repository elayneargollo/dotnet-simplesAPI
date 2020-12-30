using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacao.Core.Models
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public long Id {get; set; }
         [Column("user_name")]
        public string Username { get; set; }
         [Column("password")]
        public string Password { get; set; }
         [Column("idade")]
        public int Idade { get; set; }
         [Column("nome")]
        public string Nome { get; set; }
         [Column("sobrenome")]
        public string Sobrenome { get; set; }
       // public Endereco Endereco {get; set; }

    }
}