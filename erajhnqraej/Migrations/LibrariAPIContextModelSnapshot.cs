﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using erajhnqraej.Models;

#nullable disable

namespace erajhnqraej.Migrations
{
    [DbContext(typeof(LibrariAPIContext))]
    partial class LibrariAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("erajhnqraej.Models.Car", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int?>("CarBrandID")
                        .HasColumnType("int");

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarPoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CarRun")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CarYear")
                        .HasColumnType("int");

                    b.Property<decimal>("FuelConsumption")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("CarBrandID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("erajhnqraej.Models.CarBrand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CarBrands");
                });

            modelBuilder.Entity("erajhnqraej.Models.Meeting", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Meetings")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CarId");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("erajhnqraej.Models.Car", b =>
                {
                    b.HasOne("erajhnqraej.Models.CarBrand", "CarBrand")
                        .WithMany("Cars")
                        .HasForeignKey("CarBrandID");

                    b.Navigation("CarBrand");
                });

            modelBuilder.Entity("erajhnqraej.Models.Meeting", b =>
                {
                    b.HasOne("erajhnqraej.Models.Car", "Car")
                        .WithMany("Meetings")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("erajhnqraej.Models.Car", b =>
                {
                    b.Navigation("Meetings");
                });

            modelBuilder.Entity("erajhnqraej.Models.CarBrand", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}