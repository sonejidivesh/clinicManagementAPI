﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrescriptionGeneration;

#nullable disable

namespace PrescriptionGeneration.Migrations
{
    [DbContext(typeof(ClinicDbContext))]
    [Migration("20230328112843_modifiedDoctor")]
    partial class modifiedDoctor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PrescriptionGeneration.Model.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<byte?>("Gender")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("PrescriptionGeneration.Model.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Specilaized")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("PrescriptionGeneration.Model.Specialization", b =>
                {
                    b.HasOne("PrescriptionGeneration.Model.Doctor", null)
                        .WithMany("Specilazation")
                        .HasForeignKey("DoctorId");
                });

            modelBuilder.Entity("PrescriptionGeneration.Model.Doctor", b =>
                {
                    b.Navigation("Specilazation");
                });
#pragma warning restore 612, 618
        }
    }
}
