﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApiParser.Infrastructure;

#nullable disable

namespace WebApiParser.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApiParser.Domain.Entities.ContractEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("ContractId")
                        .HasColumnType("bigint");

                    b.Property<long>("ContractNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("ContractNumberSys")
                        .HasColumnType("text");

                    b.Property<double?>("ContractSum")
                        .HasColumnType("double precision");

                    b.Property<double?>("ContractSumWnds")
                        .HasColumnType("double precision");

                    b.Property<DateTimeOffset?>("CrDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CustomerBin")
                        .HasColumnType("text");

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("IndexDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("RefContractStatusId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long?>("RefContractTypeId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("SupplierBin")
                        .HasColumnType("text");

                    b.Property<long?>("SupplierId")
                        .HasColumnType("bigint");

                    b.Property<long>("SystemId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TrdBuyId")
                        .HasColumnType("bigint");

                    b.Property<string>("TrdBuyNumberAnno")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RefContractStatusId");

                    b.HasIndex("RefContractTypeId");

                    b.ToTable("Contracts", "public");
                });

            modelBuilder.Entity("WebApiParser.Domain.Entities.References.RefContractStatusEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("SystemId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("RefContractStatus", "public");
                });

            modelBuilder.Entity("WebApiParser.Domain.Entities.References.RefContractTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("SystemId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("RefContractType", "public");
                });

            modelBuilder.Entity("WebApiParser.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("LastAuthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Mail")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<long>("SystemId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Users", "public");
                });

            modelBuilder.Entity("WebApiParser.Domain.Entities.ContractEntity", b =>
                {
                    b.HasOne("WebApiParser.Domain.Entities.References.RefContractStatusEntity", "RefContractStatus")
                        .WithMany()
                        .HasForeignKey("RefContractStatusId")
                        .HasPrincipalKey("SystemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApiParser.Domain.Entities.References.RefContractTypeEntity", "RefContractType")
                        .WithMany()
                        .HasForeignKey("RefContractTypeId")
                        .HasPrincipalKey("SystemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RefContractStatus");

                    b.Navigation("RefContractType");
                });

            modelBuilder.Entity("WebApiParser.Domain.Entities.References.RefContractStatusEntity", b =>
                {
                    b.OwnsOne("WebApiParser.Domain.SeedWork.Localizable", "Name", b1 =>
                        {
                            b1.Property<Guid>("RefContractStatusEntityId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Kk")
                                .HasColumnType("text");

                            b1.Property<string>("Ru")
                                .HasColumnType("text");

                            b1.HasKey("RefContractStatusEntityId");

                            b1.ToTable("RefContractStatus", "public");

                            b1.WithOwner()
                                .HasForeignKey("RefContractStatusEntityId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApiParser.Domain.Entities.References.RefContractTypeEntity", b =>
                {
                    b.OwnsOne("WebApiParser.Domain.SeedWork.Localizable", "Name", b1 =>
                        {
                            b1.Property<Guid>("RefContractTypeEntityId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Kk")
                                .HasColumnType("text");

                            b1.Property<string>("Ru")
                                .HasColumnType("text");

                            b1.HasKey("RefContractTypeEntityId");

                            b1.ToTable("RefContractType", "public");

                            b1.WithOwner()
                                .HasForeignKey("RefContractTypeEntityId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}