﻿// <auto-generated />
using System;
using Lanre.Module.Library.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lanre.Module.Library.Infrastructure.Database.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20220427133927_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Lanre.Module.Library.Domain.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Books", "library");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8bddba00-f200-402d-b45b-6f1634a5f622"),
                            Name = "El imperio final"
                        },
                        new
                        {
                            Id = new Guid("332fb5ab-2eab-4393-a920-9b46faed3cb5"),
                            Name = "El juego de Ender"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
