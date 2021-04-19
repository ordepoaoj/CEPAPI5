using Newtonsoft.Json;
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

        [JsonIgnore]
        public long Id { get; set; }
        [JsonIgnore]
        public long CdCidade { get; set; }
        public string Nome { get; set; }
        public string Slug { get; set; }

        [JsonIgnore]
        public virtual Cidade Cidade { get; set; }
        [JsonIgnore]
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
