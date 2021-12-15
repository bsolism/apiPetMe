using apiPetMe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiPetMe.Context
{
    public class DonationMapping : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
    {
        builder.ToTable("Donation", "dbo");
            builder.HasKey(q => q.DonationId);
            builder.Property(e => e.DonationId).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(e => e.Prefix).HasColumnType("nvarchar(max)");
            builder.Property(e => e.Monto).HasColumnType("decimal(18,2)");
            builder.Property(e => e.Suscription).HasColumnType("bit");
            builder.Property(e => e.ProfileHouseId).HasColumnType("int").IsRequired();
            builder.Property(e => e.PetId).HasColumnType("int").IsRequired();
            builder.Property(e => e.DateCreated).HasDefaultValueSql("getdate()");

            builder.HasOne(x => x.ProfileHouse)
               .WithMany(x => x.Donations)
               .HasForeignKey(x => x.ProfileHouseId)
               .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Pet)
               .WithMany(x => x.Donations)
               .HasForeignKey(x => x.PetId)
               .OnDelete(DeleteBehavior.NoAction);


        }
}
}
