using Microsoft.EntityFrameworkCore;

namespace Solution.Infrastructure.DataAccessObject
{
    public class Context : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CadastroUsuario;Trusted_Connection=true;");
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-EPIOHMM;Initial Catalog=CadastroUsuario;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
