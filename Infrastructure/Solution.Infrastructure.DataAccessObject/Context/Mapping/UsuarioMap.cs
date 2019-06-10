using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Solution.Infrastructure.DataAccessObject
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(typeof(Usuario).Name);

            builder.Property(x => x.Codigo).ValueGeneratedOnAdd();
            builder.Property(x => x.DataNascimento);
            builder.Property(x => x.Nome).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Sobrenome).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasKey(x => x.Codigo);
        }
    }
}
