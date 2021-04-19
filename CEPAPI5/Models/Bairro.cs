using System;
using System.Collections.Generic;

#nullable disable

namespace CEPAPI5.Models
{
    public partial class Bairro
    {
        public Bairro()
        {
            Enderecos = new HashSet<Endereco>();
        }

        public long Id { get; set; }
        public long CdCidade { get; set; }
        public string Nome { get; set; }
        public string Slug { get; set; }

        public virtual Cidade Cidade { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
