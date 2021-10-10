

using apiPetMe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiPetMe.Context
{
    public class RequestAdoptionMapping :  IEntityTypeConfiguration<RequestAdoption>
    {
        public void Configure(EntityTypeBuilder<RequestAdoption> builder)
        {
            builder.ToTable("RequestAdoptions", "dbo");
            builder.HasKey(q => q.RequestAdoptionId);
            builder.Property(e => e.RequestAdoptionId).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(e => e.Address).HasColumnType("nvarchar(max)");
            builder.Property(e => e.City).HasColumnType("nvarchar(max)");
            builder.Property(e => e.Comentary).HasColumnType("nvarchar(max)");
            builder.Property(e => e.Country).HasColumnType("nvarchar(max)");
            builder.Property(e => e.Dni).HasColumnType("nvarchar(max)");
            builder.Property(e => e.Email).HasColumnType("nvarchar(max)");
            builder.Property(e => e.HasPets).HasColumnType("bit").IsRequired();
            builder.Property(e => e.Name).HasColumnType("nvarchar(max)");
            builder.Property(e => e.Phone).HasColumnType("nvarchar(max)");
            builder.Property(e => e.ProfileHouseId).HasColumnType("int").IsRequired();
            builder.Property(e => e.UserId).HasColumnType("int").IsRequired();
            builder.Property(e => e.PetId).HasColumnType("int").IsRequired();
            builder.Property(e => e.Province).HasColumnType("nvarchar(max)");
            builder.Property(e => e.TimeAlone).HasColumnType("int").IsRequired();
            builder.Property(e => e.WhatPet).HasColumnType("nvarchar(max)");
            builder.Property(e => e.Why).HasColumnType("nvarchar(max)");

            builder.HasOne(x => x.Pet)
                .WithMany(x => x.RequestAdoptions)
                .HasForeignKey(x => x.PetId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.ProfileHouse)
                .WithMany(x => x.RequestAdoptions)
                .HasForeignKey(x => x.ProfileHouseId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.User)
               .WithMany(x => x.RequestAdoptions)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
