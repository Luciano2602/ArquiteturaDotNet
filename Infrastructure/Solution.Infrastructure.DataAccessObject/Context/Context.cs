using Microsoft.EntityFrameworkCore;

namespace Solution.Infrastructure.DataAccessObject
{
    public class Context : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
