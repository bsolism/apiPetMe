using apiPetMe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiPetMe.Context
{
    public class PetMapping : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("Pet", "dbo");
            builder.Property(e => e.DateCreated).HasDefaultValueSql("getdate()");


        }
    }
}
