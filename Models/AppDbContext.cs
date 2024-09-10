using Microsoft.EntityFrameworkCore;

namespace Aula_api_fuel_manager.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EstabelecimentoUsuarios>()
                .HasKey(c => new { c.EstabelecimentoId, c.UsuarioId });

            builder.Entity<EstabelecimentoUsuarios>()
                .HasOne(c => c.Usuario).WithMany(c => c.Estabelecimentos) // Para cada proprietario pode ter vários Estabelecimentos 
                .HasForeignKey(c => c.UsuarioId);// implementação da FK

            builder.Entity<Usuario>()
               .HasMany(c => c.Estabelecimentos).WithOne(c => c.Usuario) // Para cada Estabelecimento pode ter somente umn proprietario.
               .HasForeignKey(c => c.EstabelecimentoId);
        }
        public DbSet<Estabelecimento> Estabelecimento { get; set; }
        public DbSet<Servico> Servicos { get; set; }    
        public DbSet<Usuario> Usuarios { get; set; }    
        public DbSet<EstabelecimentoUsuarios> EstabelecimentoUsuarios { get; set; }

    }
}
