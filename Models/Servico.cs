using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula_api_fuel_manager.Models
{
    [Table("Servicos")]
    public class Servico
    {



        [Required]
        public int EstablecimentoId { get; set; }

        public Estabelecimento Estabelecimento { get; set; }
    }
}
