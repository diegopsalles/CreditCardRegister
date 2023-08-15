﻿// <auto-generated />
using System;
using CreditCardRegister.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CreditCardRegister.API.Migrations.CreditCard
{
    [DbContext(typeof(CreditCardContext))]
    partial class CreditCardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CreditCardRegister.API.Entity.CreditCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreditCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CreditCard", (string)null);
                });

            modelBuilder.Entity("CreditCardRegister.API.Entity.RegisterBatchCreditCard", b =>
                {
                    b.Property<Guid>("BatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BatchAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BatchDate")
                        .HasColumnType("datetime");

                    b.Property<string>("BatchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BatchId");

                    b.ToTable("RegisterBatchCreditCard", (string)null);
                });

            modelBuilder.Entity("CreditCardRegister.API.Entity.RegisterCreditCard", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("CreditCardNumberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.HasIndex("CreditCardNumberId");

                    b.ToTable("RegisterCreditCard", (string)null);
                });

            modelBuilder.Entity("CreditCardRegister.API.Entity.CreditCard", b =>
                {
                    b.HasOne("CreditCardRegister.API.Entity.RegisterBatchCreditCard", null)
                        .WithMany("CreditCards")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CreditCardRegister.API.Entity.RegisterCreditCard", b =>
                {
                    b.HasOne("CreditCardRegister.API.Entity.CreditCard", "CreditCardNumber")
                        .WithMany()
                        .HasForeignKey("CreditCardNumberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreditCardNumber");
                });

            modelBuilder.Entity("CreditCardRegister.API.Entity.RegisterBatchCreditCard", b =>
                {
                    b.Navigation("CreditCards");
                });
#pragma warning restore 612, 618
        }
    }
}