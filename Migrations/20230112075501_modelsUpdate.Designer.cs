﻿// <auto-generated />
using System;
using CyberTech_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CyberTechBackend.Migrations
{
    [DbContext(typeof(CyberTech_APIContext))]
    [Migration("20230112075501_modelsUpdate")]
    partial class modelsUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CyberTech_Backend.Models.CyberTech", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecialAttack")
                        .HasColumnType("int");

                    b.Property<int>("SpecialDefense")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("CyberTech");
                });

            modelBuilder.Entity("CyberTech_Backend.Models.Move", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Accuracy")
                        .HasColumnType("int");

                    b.Property<int?>("CyberTechId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PP")
                        .HasColumnType("int");

                    b.Property<bool>("Physical")
                        .HasColumnType("bit");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<bool>("Special")
                        .HasColumnType("bit");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CyberTechId");

                    b.HasIndex("TypeId");

                    b.ToTable("Move");
                });

            modelBuilder.Entity("CyberTech_Backend.Models.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TypeEnum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("CyberTech_Backend.Models.CyberTech", b =>
                {
                    b.HasOne("CyberTech_Backend.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("CyberTech_Backend.Models.Move", b =>
                {
                    b.HasOne("CyberTech_Backend.Models.CyberTech", null)
                        .WithMany("Moves")
                        .HasForeignKey("CyberTechId");

                    b.HasOne("CyberTech_Backend.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("CyberTech_Backend.Models.CyberTech", b =>
                {
                    b.Navigation("Moves");
                });
#pragma warning restore 612, 618
        }
    }
}
