using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace CEPAPI5.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Cidades = new HashSet<Cidade>();
        }

        [JsonIgnore]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        [JsonIgnore]
        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
