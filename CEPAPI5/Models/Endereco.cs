using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace CEPAPI5.Models
{
    public partial class Endereco
    {
        [JsonIgnore]
        public long Id { get; set; }
        [JsonIgnore]
        public long CdCidade { get; set; }
        [JsonIgnore]
        public long? CdBairro { get; set; }
        public string Logradouro { get; set; }
        [Required(ErrorMessage ="O CEP deve ser informado")]
        public string CdPostal { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? Ddd { get; set; }

        public virtual Bairro Bairro { get; set; }
        public virtual Cidade Cidade { get; set; }

    }
}
