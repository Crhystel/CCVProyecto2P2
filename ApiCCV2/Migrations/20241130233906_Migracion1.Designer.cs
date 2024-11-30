﻿// <auto-generated />
using System;
using ApiCCV2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiCCV2.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241130233906_Migracion1")]
    partial class Migracion1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiCCV2.Models.Actividad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Actividades");
                });

            modelBuilder.Entity("ApiCCV2.Models.ActividadEstudiante", b =>
                {
                    b.Property<int>("ActividadId")
                        .HasColumnType("int");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("int");

                    b.HasKey("ActividadId", "EstudianteId");

                    b.HasIndex("EstudianteId");

                    b.ToTable("ActividadEstudiantes");
                });

            modelBuilder.Entity("ApiCCV2.Models.ActividadProfesor", b =>
                {
                    b.Property<int>("ActividadId")
                        .HasColumnType("int");

                    b.Property<int>("ProfesorId")
                        .HasColumnType("int");

                    b.HasKey("ActividadId", "ProfesorId");

                    b.HasIndex("ProfesorId");

                    b.ToTable("ActividadProfesores");
                });

            modelBuilder.Entity("ApiCCV2.Models.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Administrador");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cedula = "1234567890",
                            Contrasenia = "admin",
                            Edad = 30,
                            Nombre = "Roberto",
                            NombreUsuario = "admin",
                            Rol = 0
                        });
                });

            modelBuilder.Entity("ApiCCV2.Models.Clase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GradoId")
                        .HasColumnType("int");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GradoId");

                    b.HasIndex("MateriaId");

                    b.ToTable("Clases");
                });

            modelBuilder.Entity("ApiCCV2.Models.ClaseActividad", b =>
                {
                    b.Property<int>("ActividadId")
                        .HasColumnType("int");

                    b.Property<int>("ClaseId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("ActividadId", "ClaseId");

                    b.HasIndex("ClaseId");

                    b.ToTable("ClaseActividades");
                });

            modelBuilder.Entity("ApiCCV2.Models.ClaseEstudiante", b =>
                {
                    b.Property<int>("EstudianteId")
                        .HasColumnType("int");

                    b.Property<int>("ClaseId")
                        .HasColumnType("int");

                    b.Property<int>("Grado")
                        .HasColumnType("int");

                    b.HasKey("EstudianteId", "ClaseId");

                    b.HasIndex("ClaseId");

                    b.ToTable("ClaseEstudiantes");
                });

            modelBuilder.Entity("ApiCCV2.Models.ClaseProfesor", b =>
                {
                    b.Property<int>("ProfesorId")
                        .HasColumnType("int");

                    b.Property<int>("ClasePId")
                        .HasColumnType("int");

                    b.Property<int>("Materia")
                        .HasColumnType("int");

                    b.HasKey("ProfesorId", "ClasePId");

                    b.HasIndex("ClasePId");

                    b.ToTable("ClaseProfesores");
                });

            modelBuilder.Entity("ApiCCV2.Models.Estudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<int>("Grado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("ApiCCV2.Models.Grado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Grados");
                });

            modelBuilder.Entity("ApiCCV2.Models.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("ApiCCV2.Models.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<int>("MateriasId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MateriasId");

                    b.ToTable("Profesores");
                });

            modelBuilder.Entity("ApiCCV2.Models.ActividadEstudiante", b =>
                {
                    b.HasOne("ApiCCV2.Models.Actividad", "Actividad")
                        .WithMany("ActividadEstudiantes")
                        .HasForeignKey("ActividadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiCCV2.Models.Estudiante", "Estudiante")
                        .WithMany("ActividadEstudiantes")
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Actividad");

                    b.Navigation("Estudiante");
                });

            modelBuilder.Entity("ApiCCV2.Models.ActividadProfesor", b =>
                {
                    b.HasOne("ApiCCV2.Models.Actividad", "Actividad")
                        .WithMany("ActividadProfesores")
                        .HasForeignKey("ActividadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiCCV2.Models.Profesor", "Profesor")
                        .WithMany("ActividadProfesores")
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actividad");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("ApiCCV2.Models.Clase", b =>
                {
                    b.HasOne("ApiCCV2.Models.Grado", "Grado")
                        .WithMany()
                        .HasForeignKey("GradoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiCCV2.Models.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grado");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("ApiCCV2.Models.ClaseActividad", b =>
                {
                    b.HasOne("ApiCCV2.Models.Actividad", "Actividad")
                        .WithMany("ClaseActividades")
                        .HasForeignKey("ActividadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApiCCV2.Models.Clase", "Clase")
                        .WithMany("ClaseActividades")
                        .HasForeignKey("ClaseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Actividad");

                    b.Navigation("Clase");
                });

            modelBuilder.Entity("ApiCCV2.Models.ClaseEstudiante", b =>
                {
                    b.HasOne("ApiCCV2.Models.Clase", "Clase")
                        .WithMany("ClaseEstudiantes")
                        .HasForeignKey("ClaseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApiCCV2.Models.Estudiante", "Estudiante")
                        .WithMany("ClaseEstudiantes")
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Clase");

                    b.Navigation("Estudiante");
                });

            modelBuilder.Entity("ApiCCV2.Models.ClaseProfesor", b =>
                {
                    b.HasOne("ApiCCV2.Models.Clase", "ClaseP")
                        .WithMany("ClaseProfesores")
                        .HasForeignKey("ClasePId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApiCCV2.Models.Profesor", "Profesor")
                        .WithMany("ClaseProfesores")
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ClaseP");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("ApiCCV2.Models.Profesor", b =>
                {
                    b.HasOne("ApiCCV2.Models.Materia", "Materias")
                        .WithMany()
                        .HasForeignKey("MateriasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materias");
                });

            modelBuilder.Entity("ApiCCV2.Models.Actividad", b =>
                {
                    b.Navigation("ActividadEstudiantes");

                    b.Navigation("ActividadProfesores");

                    b.Navigation("ClaseActividades");
                });

            modelBuilder.Entity("ApiCCV2.Models.Clase", b =>
                {
                    b.Navigation("ClaseActividades");

                    b.Navigation("ClaseEstudiantes");

                    b.Navigation("ClaseProfesores");
                });

            modelBuilder.Entity("ApiCCV2.Models.Estudiante", b =>
                {
                    b.Navigation("ActividadEstudiantes");

                    b.Navigation("ClaseEstudiantes");
                });

            modelBuilder.Entity("ApiCCV2.Models.Profesor", b =>
                {
                    b.Navigation("ActividadProfesores");

                    b.Navigation("ClaseProfesores");
                });
#pragma warning restore 612, 618
        }
    }
}
