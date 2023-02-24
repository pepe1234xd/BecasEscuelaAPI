﻿// <auto-generated />
using BecasEscuela.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BecasEscuela.Migrations
{
    [DbContext(typeof(dbConnection))]
    partial class dbConnectionModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BecasEscuela.Models.Domain.AlumnosBecados", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("idAlumno")
                        .HasColumnType("int");

                    b.Property<int>("idBecas")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idAlumno");

                    b.HasIndex("idBecas");

                    b.ToTable("AlumnosBecados");
                });

            modelBuilder.Entity("BecasEscuela.Models.Domain.Becas", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Becas");
                });

            modelBuilder.Entity("BecasEscuela.Models.Domain.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<bool>("gender")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("BecasEscuela.Models.Domain.AlumnosBecados", b =>
                {
                    b.HasOne("BecasEscuela.Models.Domain.Student", "Alumno")
                        .WithMany()
                        .HasForeignKey("idAlumno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BecasEscuela.Models.Domain.Becas", "Beca")
                        .WithMany()
                        .HasForeignKey("idBecas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Beca");
                });
#pragma warning restore 612, 618
        }
    }
}