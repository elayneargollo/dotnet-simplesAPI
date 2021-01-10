using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacao.Core.Models
{
    [Table("users")]
    public class User
    {
        [Column("user_id")]
        public long UserId {get; set; }

        [Column("user_name")]
        [Display (Name = "Username")]
        public string Username { get; set; }

        [Column("password")]
        [Display (Name = "Password")]
        public string Password { get; set; }

        [Column("idade")]
        [Display (Name = "Idade")]
        public int Idade { get; set; }

        [Column("nome")]
        [Display (Name = "Nome")]
        public string Nome { get; set; }

        [Column("sobrenome")]
        [Display (Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        public List<Endereco> Enderecos { get; set; }

      /*  public User()
        {
            Enderecos = new HashSet<Endereco>();
        }*/

    }
}