﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using ProvaPub.Infra.Data.Context;

#nullable disable

namespace ProvaPub.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230406192747_testpt2")]
    partial class testpt2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProvaPub.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Elaine Fay"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Meredith Cummings"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Manuel Hickle"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Carla Armstrong"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Patty Runolfsdottir"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Joan Fahey"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Leslie Schiller"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Rene Legros"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Albert Jacobson"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Ruben Bernier"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Jordan Shields"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Ramiro Anderson"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Maggie Gislason"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Lois Lindgren"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Merle Medhurst"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Orlando Roob"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Duane Macejkovic"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Herman Bashirian"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Bernice Prohaska"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Alfredo Rempel"
                        });
                });

            modelBuilder.Entity("ProvaPub.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ProvaPub.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Gorgeous Frozen Towels"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Refined Metal Computer"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rustic Plastic Chair"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Tasty Concrete Shirt"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Handmade Rubber Gloves"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Intelligent Granite Bacon"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Tasty Concrete Cheese"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Incredible Cotton Bike"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Small Fresh Hat"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Handcrafted Concrete Hat"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Handmade Fresh Hat"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Awesome Soft Table"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Unbranded Steel Gloves"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Handmade Concrete Chicken"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Practical Granite Chair"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Incredible Fresh Chair"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Handmade Plastic Mouse"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Unbranded Concrete Computer"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Fantastic Cotton Gloves"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Fantastic Concrete Pants"
                        });
                });

            modelBuilder.Entity("ProvaPub.Models.Order", b =>
                {
                    b.HasOne("ProvaPub.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ProvaPub.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
