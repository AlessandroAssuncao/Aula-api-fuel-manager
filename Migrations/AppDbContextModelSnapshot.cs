﻿// <auto-generated />
using System;
using Aula_api_fuel_manager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aula_api_fuel_manager.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aula_api_fuel_manager.Models.Estabelecimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estabelecimentos");
                });

            modelBuilder.Entity("Aula_api_fuel_manager.Models.Servico", b =>
                {
                    b.Property<string>("NomeServico")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("EstabelecimentoId")
                        .HasColumnType("int");

                    b.Property<int>("EstablecimentoId")
                        .HasColumnType("int");

                    b.HasKey("NomeServico");

                    b.HasIndex("EstabelecimentoId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("Aula_api_fuel_manager.Models.Servico", b =>
                {
                    b.HasOne("Aula_api_fuel_manager.Models.Estabelecimento", "Estabelecimento")
                        .WithMany("Servicos")
                        .HasForeignKey("EstabelecimentoId");

                    b.Navigation("Estabelecimento");
                });

            modelBuilder.Entity("Aula_api_fuel_manager.Models.Estabelecimento", b =>
                {
                    b.Navigation("Servicos");
                });
#pragma warning restore 612, 618
        }
    }
}
