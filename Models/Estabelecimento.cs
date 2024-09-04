using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula_api_fuel_manager.Models
{
    [Table("Estabelecimentos")]
    public class Estabelecimento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Telefone { get; set; }    
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime Data { get; set; }
        public ICollection<Servico> Servicos { get; set; }
    }
}
