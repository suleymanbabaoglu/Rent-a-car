﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentACar.Backend.Models.Context;

#nullable disable

namespace RentACar.Backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221130000648_m1")]
    partial class m1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RentACar.Backend.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DoorCount")
                        .HasColumnType("int");

                    b.Property<string>("Fuel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<int>("MinAgeRule")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("RentalStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Segment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("cars");
                });

            modelBuilder.Entity("RentACar.Backend.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("RentACar.Backend.Models.Rental", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("CarId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("RentACar.Backend.Models.Rental", b =>
                {
                    b.HasOne("RentACar.Backend.Models.Car", "Car")
                        .WithMany("RentalList")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentACar.Backend.Models.Customer", "Customer")
                        .WithMany("RentalList")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("RentACar.Backend.Models.Car", b =>
                {
                    b.Navigation("RentalList");
                });

            modelBuilder.Entity("RentACar.Backend.Models.Customer", b =>
                {
                    b.Navigation("RentalList");
                });
#pragma warning restore 612, 618
        }
    }
}