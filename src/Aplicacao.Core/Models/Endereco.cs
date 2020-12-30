namespace Aplicacao.Core.Models
{
    public class Endereco
    {
        public long Id { set; get; }
        public string CEP { set; get; }
        public string Bairro { set; get; }
        public string Cidade { set; get; }
        public string End { set; get; }
        public string UF { set; get; }
        public long? UserId {set; get; }
        public virtual User User {set; get; }
    }
}