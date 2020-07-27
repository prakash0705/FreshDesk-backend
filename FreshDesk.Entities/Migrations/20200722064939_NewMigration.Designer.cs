﻿// <auto-generated />
using System;
using FreshDesk.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FreshDesk.Entities.Migrations
{
    [DbContext(typeof(FreshDeskDbContext))]
    [Migration("20200722064939_NewMigration")]
    partial class NewMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FreshDesk.Entities.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mobile")
                        .HasColumnType("int");

                    b.Property<int?>("registerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("registerId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("FreshDesk.Entities.Models.Logs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("registerId")
                        .HasColumnType("int");

                    b.Property<int?>("ticketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("registerId");

                    b.HasIndex("ticketId");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("FreshDesk.Entities.Models.Register", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Registers");
                });

            modelBuilder.Entity("FreshDesk.Entities.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("ResponderId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("registerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("registerId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("FreshDesk.Entities.Models.Contact", b =>
                {
                    b.HasOne("FreshDesk.Entities.Models.Register", "register")
                        .WithMany()
                        .HasForeignKey("registerId");
                });

            modelBuilder.Entity("FreshDesk.Entities.Models.Logs", b =>
                {
                    b.HasOne("FreshDesk.Entities.Models.Register", "register")
                        .WithMany()
                        .HasForeignKey("registerId");

                    b.HasOne("FreshDesk.Entities.Models.Ticket", "ticket")
                        .WithMany()
                        .HasForeignKey("ticketId");
                });

            modelBuilder.Entity("FreshDesk.Entities.Models.Ticket", b =>
                {
                    b.HasOne("FreshDesk.Entities.Models.Register", "register")
                        .WithMany()
                        .HasForeignKey("registerId");
                });
#pragma warning restore 612, 618
        }
    }
}
