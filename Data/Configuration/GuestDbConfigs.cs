using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudiesAPI.Domain.Entities;

namespace StudiesAPI.Data.Configuration
{
    public class GuestDbConfigs : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.ToTable("Guests");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("id")
                   .HasColumnType("uuid")
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                   .HasColumnName("name")
                   .HasColumnType("text")
                   .IsRequired();

            builder.Property(x => x.CPF)
                   .HasColumnName("cpf")
                   .HasColumnType("text")
                   .IsRequired();

            builder.HasIndex(x => x.CPF)
                    .IsUnique();
        }
    }
}
