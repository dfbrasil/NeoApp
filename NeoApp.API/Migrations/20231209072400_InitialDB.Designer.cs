﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NeoApp.API.Models;

#nullable disable

namespace NeoApp.API.Migrations
{
    [DbContext(typeof(ControleConsultaContext))]
    [Migration("20231209072400_InitialDB")]
    partial class InitialDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NeoApp.API.Models.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataConsulta")
                        .HasColumnType("datetime")
                        .HasColumnName("dataConsulta");

                    b.Property<int?>("IdMedico")
                        .HasColumnType("int")
                        .HasColumnName("idMedico");

                    b.Property<int?>("IdPaciente")
                        .HasColumnType("int")
                        .HasColumnName("idPaciente");

                    b.HasKey("Id");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdPaciente");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("NeoApp.API.Models.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeMedico")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nome_medico");

                    b.HasKey("Id");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("NeoApp.API.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomePaciente")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nome_paciente");

                    b.HasKey("Id");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("NeoApp.API.Models.Consulta", b =>
                {
                    b.HasOne("NeoApp.API.Models.Medico", "IdMedicoNavigation")
                        .WithMany("Consulta")
                        .HasForeignKey("IdMedico")
                        .HasConstraintName("FK_Consulta_Medico");

                    b.HasOne("NeoApp.API.Models.Paciente", "IdPacienteNavigation")
                        .WithMany("Consulta")
                        .HasForeignKey("IdPaciente")
                        .HasConstraintName("FK_Consulta_Paciente");

                    b.Navigation("IdMedicoNavigation");

                    b.Navigation("IdPacienteNavigation");
                });

            modelBuilder.Entity("NeoApp.API.Models.Medico", b =>
                {
                    b.Navigation("Consulta");
                });

            modelBuilder.Entity("NeoApp.API.Models.Paciente", b =>
                {
                    b.Navigation("Consulta");
                });
#pragma warning restore 612, 618
        }
    }
}