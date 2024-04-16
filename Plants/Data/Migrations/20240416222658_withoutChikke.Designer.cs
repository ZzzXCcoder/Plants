﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication1.Context;

#nullable disable

namespace Plants.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240416222658_withoutChikke")]
    partial class withoutChikke
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Plant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Plant_description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Plant_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Plant_type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("Plants.Models.Account_and_plant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlantId")
                        .HasColumnType("uuid");

                    b.Property<double>("wateringIntervalInHours")
                        .HasColumnType("double precision");

                    b.Property<double>("watering_rate")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("watering_time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("PlantId");

                    b.ToTable("Accounts_and_plants");
                });

            modelBuilder.Entity("WebApplication1.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Plants.Models.Account_and_plant", b =>
                {
                    b.HasOne("WebApplication1.Models.Account", "Account")
                        .WithMany("accounts_in_table")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Plant", "Plant")
                        .WithMany("plant_in_table")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("Plant", b =>
                {
                    b.Navigation("plant_in_table");
                });

            modelBuilder.Entity("WebApplication1.Models.Account", b =>
                {
                    b.Navigation("accounts_in_table");
                });
#pragma warning restore 612, 618
        }
    }
}
