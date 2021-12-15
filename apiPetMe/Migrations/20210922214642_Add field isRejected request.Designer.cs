﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apiPetMe.Context;

namespace apiPetMe.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210922214642_Add field isRejected request")]
    partial class AddfieldisRejectedrequest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("apiPetMe.Models.Pet", b =>
                {
                    b.Property<int>("PetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClinicHistory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Height")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LifeHistory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Old")
                        .HasColumnType("int");

                    b.Property<int>("ProfileHouseId")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAdoptable")
                        .HasColumnType("bit");

                    b.HasKey("PetId");

                    b.HasIndex("ProfileHouseId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("apiPetMe.Models.PetPhotos", b =>
                {
                    b.Property<int>("PetPhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PetId")
                        .HasColumnType("int");

                    b.HasKey("PetPhotoId");

                    b.HasIndex("PetId");

                    b.ToTable("PetPhotos");
                });

            modelBuilder.Entity("apiPetMe.Models.ProfileHouse", b =>
                {
                    b.Property<int>("ProfileHouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProfileHouseId");

                    b.HasIndex("UserId");

                    b.ToTable("ProfileHouses");
                });

            modelBuilder.Entity("apiPetMe.Models.RequestAdoption", b =>
                {
                    b.Property<int>("RequestAdoptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comentary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasPets")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PetId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfileHouseId")
                        .HasColumnType("int");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TimeAlone")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("WhatPet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Why")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("isRejected")
                        .HasColumnType("bit");

                    b.HasKey("RequestAdoptionId");

                    b.HasIndex("PetId");

                    b.HasIndex("ProfileHouseId");

                    b.HasIndex("UserId");

                    b.ToTable("RequestAdoptions", "dbo");
                });

            modelBuilder.Entity("apiPetMe.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.Property<string>("Sal")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("apiPetMe.Models.Pet", b =>
                {
                    b.HasOne("apiPetMe.Models.ProfileHouse", "ProfileHouse")
                        .WithMany("Pets")
                        .HasForeignKey("ProfileHouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfileHouse");
                });

            modelBuilder.Entity("apiPetMe.Models.PetPhotos", b =>
                {
                    b.HasOne("apiPetMe.Models.Pet", "Pet")
                        .WithMany("PetPhotos")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("apiPetMe.Models.ProfileHouse", b =>
                {
                    b.HasOne("apiPetMe.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("apiPetMe.Models.RequestAdoption", b =>
                {
                    b.HasOne("apiPetMe.Models.Pet", "Pet")
                        .WithMany("RequestAdoptions")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("apiPetMe.Models.ProfileHouse", "ProfileHouse")
                        .WithMany("RequestAdoptions")
                        .HasForeignKey("ProfileHouseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("apiPetMe.Models.User", "User")
                        .WithMany("RequestAdoptions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Pet");

                    b.Navigation("ProfileHouse");

                    b.Navigation("User");
                });

            modelBuilder.Entity("apiPetMe.Models.Pet", b =>
                {
                    b.Navigation("PetPhotos");

                    b.Navigation("RequestAdoptions");
                });

            modelBuilder.Entity("apiPetMe.Models.ProfileHouse", b =>
                {
                    b.Navigation("Pets");

                    b.Navigation("RequestAdoptions");
                });

            modelBuilder.Entity("apiPetMe.Models.User", b =>
                {
                    b.Navigation("RequestAdoptions");
                });
#pragma warning restore 612, 618
        }
    }
}
