using System.ComponentModel.DataAnnotations.Schema;

namespace Aula_api_fuel_manager.Models
{
    [Table("EstabelecimentoUsuario")]
    public class EstabelecimentoUsuarios
    {
        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
