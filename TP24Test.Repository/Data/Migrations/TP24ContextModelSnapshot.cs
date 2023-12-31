﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP24Test.Repository.Data;

#nullable disable

namespace TP24Test.Repository.Data.Migrations
{
    [DbContext(typeof(TP24Context))]
    partial class TP24ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("TP24Test.Shared.Models.Invoice", b =>
                {
                    b.Property<Guid>("Reference")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Cancelled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ClosedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DebtorAddress1")
                        .HasColumnType("TEXT");

                    b.Property<string>("DebtorAddress2")
                        .HasColumnType("TEXT");

                    b.Property<string>("DebtorCountryCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DebtorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DebtorReference")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DebtorRegistrationNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("DebtorState")
                        .HasColumnType("TEXT");

                    b.Property<string>("DebtorTown")
                        .HasColumnType("TEXT");

                    b.Property<string>("DebtorZip")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("IssueDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("OpeningValue")
                        .HasColumnType("REAL");

                    b.Property<double>("PaidValue")
                        .HasColumnType("REAL");

                    b.HasKey("Reference");

                    b.ToTable("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
