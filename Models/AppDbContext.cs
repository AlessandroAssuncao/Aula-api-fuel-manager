using Microsoft.EntityFrameworkCore;

namespace Aula_api_fuel_manager.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Estabelecimento> Estabelecimento { get; set; }
        public DbSet<Servico> Servicos { get; set; }    
    }
}
