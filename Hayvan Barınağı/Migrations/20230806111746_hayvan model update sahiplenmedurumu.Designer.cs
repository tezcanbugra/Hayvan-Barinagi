﻿// <auto-generated />
using System;
using Hayvan_Barınağı.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hayvan_Barınağı.Migrations
{
    [DbContext(typeof(BarinakDbContext))]
    [Migration("20230806111746_hayvan model update sahiplenmedurumu")]
    partial class hayvanmodelupdatesahiplenmedurumu
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hayvan_Barınağı.Models.Hayvan.Cins", b =>
                {
                    b.Property<Guid>("CinsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CinsAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TurId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CinsId");

                    b.HasIndex("TurId");

                    b.ToTable("Cinsler");
                });

            modelBuilder.Entity("Hayvan_Barınağı.Models.Hayvan.Hayvan", b =>
                {
                    b.Property<Guid>("HayvanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CinsAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CinsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cinsiyet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("HayvanAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Onay")
                        .HasColumnType("bit");

                    b.Property<bool>("Sahiplenildi")
                        .HasColumnType("bit");

                    b.Property<int>("SahiplenmeDurumu")
                        .HasColumnType("int");

                    b.Property<string>("TurAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TurId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Yas")
                        .HasColumnType("int");

                    b.Property<string>("fotografURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HayvanId");

                    b.HasIndex("CinsId");

                    b.HasIndex("TurId");

                    b.ToTable("Hayvanlar");
                });

            modelBuilder.Entity("Hayvan_Barınağı.Models.Hayvan.Tur", b =>
                {
                    b.Property<Guid>("TurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TurAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TurId");

                    b.ToTable("Turler");
                });

            modelBuilder.Entity("Hayvan_Barınağı.Models.Hayvan.Cins", b =>
                {
                    b.HasOne("Hayvan_Barınağı.Models.Hayvan.Tur", "Tur")
                        .WithMany("Cinsler")
                        .HasForeignKey("TurId");

                    b.Navigation("Tur");
                });

            modelBuilder.Entity("Hayvan_Barınağı.Models.Hayvan.Hayvan", b =>
                {
                    b.HasOne("Hayvan_Barınağı.Models.Hayvan.Cins", "Cins")
                        .WithMany("Hayvanlar")
                        .HasForeignKey("CinsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hayvan_Barınağı.Models.Hayvan.Tur", "Tur")
                        .WithMany("Hayvanlar")
                        .HasForeignKey("TurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cins");

                    b.Navigation("Tur");
                });

            modelBuilder.Entity("Hayvan_Barınağı.Models.Hayvan.Cins", b =>
                {
                    b.Navigation("Hayvanlar");
                });

            modelBuilder.Entity("Hayvan_Barınağı.Models.Hayvan.Tur", b =>
                {
                    b.Navigation("Cinsler");

                    b.Navigation("Hayvanlar");
                });
#pragma warning restore 612, 618
        }
    }
}
