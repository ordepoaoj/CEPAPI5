using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace CEPAPI5.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            Bairros = new HashSet<Bairro>();
            Enderecos = new HashSet<Endereco>();
        }

        [JsonIgnore]
        public long Id { get; set; }
        [JsonIgnore]
        public long CdEstado { get; set; }
        public string Nome { get; set; }
        public string Slug { get; set; }

        
        public virtual Estado Estado { get; set; }
        [JsonIgnore]
        public virtual ICollection<Bairro> Bairros { get; set; }
        [JsonIgnore]
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
