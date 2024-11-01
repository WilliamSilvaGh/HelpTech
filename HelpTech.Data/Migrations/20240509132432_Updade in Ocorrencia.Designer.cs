﻿// <auto-generated />
using System;
using HelpTech.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HelpTech.Data.Migrations
{
    [DbContext(typeof(HelpTechContext))]
    [Migration("20240509132432_Updade in Ocorrencia")]
    partial class UpdadeinOcorrencia
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("HelpTech.Domain.Entities.Ocorrencia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("DescricaoResolucao")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<TimeOnly>("Hora")
                        .HasColumnType("time(6)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("TipoOcorrencia")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UsuarioResolucaoId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("UsuarioResolucaoId");

                    b.ToTable("TB_Ocorrencia", (string)null);
                });

            modelBuilder.Entity("HelpTech.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("EhAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("EmailLogin")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

                    b.HasKey("Id");

                    b.ToTable("TB_Usuario", (string)null);
                });

            modelBuilder.Entity("HelpTech.Domain.Entities.Ocorrencia", b =>
                {
                    b.HasOne("HelpTech.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HelpTech.Domain.Entities.Usuario", "UsuarioResolucao")
                        .WithMany()
                        .HasForeignKey("UsuarioResolucaoId");

                    b.Navigation("Usuario");

                    b.Navigation("UsuarioResolucao");
                });
#pragma warning restore 612, 618
        }
    }
}
