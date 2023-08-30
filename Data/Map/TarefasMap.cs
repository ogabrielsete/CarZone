using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarZone.Models
{
    public class TarefasMap : IEntityTypeConfiguration<Tarefas>
    {
        public void Configure(EntityTypeBuilder<Tarefas> builder)
        {
            // Tabela
            builder.ToTable("Tarefas");

            // Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnName("Descricao")
                .HasColumnType("varchar(100)"); 

            builder.Property(x => x.Concluido)
                .IsRequired()
                .HasDefaultValue(false);

            // Relacionamentos
            //builder.HasOne(x => x.Usuario)
            //    .WithMany()
            //    .HasForeignKey(x => x.UserId)
            //    .OnDelete(DeleteBehavior.Restrict); 

            // Índice para o campo UsuarioId
            builder.HasIndex(x => x.UserId);

        }
    }
}
