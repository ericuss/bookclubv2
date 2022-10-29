﻿// <auto-generated />
using System;
using Lanre.Module.Library.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lanre.Module.Library.Infrastructure.Database.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Lanre.Context.Library.Domain.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Authors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Pages")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Series")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sinopsis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Books", "library");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8bddba00-f200-402d-b45b-6f1634a5f622"),
                            Authors = "Brandon Sanderson",
                            ImageUrl = "http://google.es",
                            Name = "El imperio final",
                            Pages = "XXX",
                            Rating = "5",
                            Series = "Nacidos de la bruma",
                            Sinopsis = "",
                            Url = "http://google.es",
                            UserId = "0000000000"
                        },
                        new
                        {
                            Id = new Guid("332fb5ab-2eab-4393-a920-9b46faed3cb5"),
                            Authors = "Orson Scott Card",
                            ImageUrl = "http://google.es",
                            Name = "El juego de Ender",
                            Pages = "XXX",
                            Rating = "5",
                            Series = "Ender",
                            Sinopsis = "",
                            Url = "http://google.es",
                            UserId = "0000000000"
                        });
                });

            modelBuilder.Entity("Lanre.Context.Library.Domain.MarkBook", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Marked")
                        .HasColumnType("int");

                    b.HasKey("BookId", "UserId", "Marked");

                    b.ToTable("MarkBooks", "library");

                    b.HasData(
                        new
                        {
                            BookId = new Guid("8bddba00-f200-402d-b45b-6f1634a5f622"),
                            UserId = "251963be-2c3e-435f-9da7-a62bec3d508a",
                            Marked = 10
                        });
                });

            modelBuilder.Entity("Lanre.Context.Library.Domain.MarkBook", b =>
                {
                    b.HasOne("Lanre.Context.Library.Domain.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}
