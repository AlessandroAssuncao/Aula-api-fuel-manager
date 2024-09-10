using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula_api_fuel_manager.Models
{
    [Table("Servicos")]
    public class Servico : LinksHateos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NomeServico { get; set; }
        
        [Required]
        public int EstablecimentoId { get; set; }

        public Estabelecimento Estabelecimento { get; set; }
    }
}
