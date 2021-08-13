using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CEPAPI5.Models
{
    public partial class Endereco
    {
        [NotMapped]
        public long Id { get; set; }
        [NotMapped]
        public long CdCidade { get; set; }
        [NotMapped]
        public long? CdBairro { get; set; }
        public string Endereco1 { get; set; }
        public string CdPostal { get; set; }
        public string Latitude { get; set; }
        [NotMapped]
        public string Longitude { get; set; }
        public int? Ddd { get; set; }

        public virtual Bairro Bairro { get; set; }
        public virtual Cidade Cidade { get; set; }

    }
}
