using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
