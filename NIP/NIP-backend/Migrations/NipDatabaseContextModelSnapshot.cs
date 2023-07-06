﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NIP_backend.DbContext;

#nullable disable

namespace NIP_backend.Migrations
{
    [DbContext(typeof(NipDatabaseContext))]
    partial class NipDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NIP_backend.Model.Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNumbers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasVirtualAccounts")
                        .HasColumnType("bit");

                    b.Property<string>("Krs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nip")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Pesel")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("RegistrationDenialBasis")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("RegistrationDenialDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RegistrationLegalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Regon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RemovalBasis")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("RemovalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResidenceAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RestorationBasis")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("RestorationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StatusVat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkingAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("NIP_backend.Model.EntityPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EntityAsClerkId")
                        .HasColumnType("int");

                    b.Property<int?>("EntityAsPartnerId")
                        .HasColumnType("int");

                    b.Property<int?>("EntityAsRepresentativeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nip")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Pesel")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("EntityAsClerkId");

                    b.HasIndex("EntityAsPartnerId");

                    b.HasIndex("EntityAsRepresentativeId");

                    b.ToTable("EntityPeople");
                });

            modelBuilder.Entity("NIP_backend.Model.EntityPerson", b =>
                {
                    b.HasOne("NIP_backend.Model.Entity", "EntityAsClerk")
                        .WithMany("AuthorizedClerks")
                        .HasForeignKey("EntityAsClerkId");

                    b.HasOne("NIP_backend.Model.Entity", "EntityAsPartner")
                        .WithMany("Partners")
                        .HasForeignKey("EntityAsPartnerId");

                    b.HasOne("NIP_backend.Model.Entity", "EntityAsRepresentative")
                        .WithMany("Representatives")
                        .HasForeignKey("EntityAsRepresentativeId");

                    b.Navigation("EntityAsClerk");

                    b.Navigation("EntityAsPartner");

                    b.Navigation("EntityAsRepresentative");
                });

            modelBuilder.Entity("NIP_backend.Model.Entity", b =>
                {
                    b.Navigation("AuthorizedClerks");

                    b.Navigation("Partners");

                    b.Navigation("Representatives");
                });
#pragma warning restore 612, 618
        }
    }
}