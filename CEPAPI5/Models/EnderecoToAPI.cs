using System.ComponentModel.DataAnnotations.Schema;

namespace CEPAPI5.Models
{
    public class EnderecoToAPI
    {
        public Endereco EnderecoAPI { get; set; }
        [ForeignKey("Id")]
        public Bairro Bairro { get; set; }
        [ForeignKey("Id")]
        public Cidade Cidade { get; set; }
        [ForeignKey("Id")]
        public Estado Estado { get; set; }
    }
}
