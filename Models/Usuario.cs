using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Aula_api_fuel_manager.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [JsonIgnore]
        public string Password { get; set; }
        [Required]
        public Perfil Perfil { get; set; }
        public ICollection<EstabelecimentoUsuarios> Estabelecimentos { get; set; }
    }
        public enum Perfil
        {
            [Display(Name =  "Administrador")]
            Administrador,
            [Display(Name = "Consumidor")]
            Usuario,
            [Display(Name = "Proprietario")]
            Proprietario
        }
    }

