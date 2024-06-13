using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FatecSisMed.MedicoAPI.DTO.Entities
{
    public class RemedioDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        public string Preco { get; set; }

        [JsonIgnore]
        public MarcaDTO? MarcaDTO { get; set; }
        public int MarcaId { get; set; }
    }
}
