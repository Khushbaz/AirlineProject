﻿// <auto-generated />
using System;
using AirlineProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirlineProject.Migrations
{
    [DbContext(typeof(AirlineProjectContext))]
    [Migration("20210127074902_Initialcreate1")]
    partial class Initialcreate1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirlineProject.Models.Airline", b =>
                {
                    b.Property<int>("AirlineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AirlineName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepatureDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AirlineID");

                    b.ToTable("Airline");
                });

            modelBuilder.Entity("AirlineProject.Models.StaffMember", b =>
                {
                    b.Property<int>("StaffMemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirlineID")
                        .HasColumnType("int");

                    b.Property<int>("ContactNumber")
                        .HasColumnType("int");

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffMemberName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StaffMemberID");

                    b.HasIndex("AirlineID");

                    b.ToTable("StaffMember");
                });

            modelBuilder.Entity("AirlineProject.Models.TicketPrice", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirlineID")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("TicketName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketID");

                    b.HasIndex("AirlineID");

                    b.ToTable("TicketPrice");
                });

            modelBuilder.Entity("AirlineProject.Models.Traveller", b =>
                {
                    b.Property<int>("TravellerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactNumber")
                        .HasColumnType("int");

                    b.Property<int>("StaffMemberID")
                        .HasColumnType("int");

                    b.Property<string>("TravellerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TravellerID");

                    b.HasIndex("StaffMemberID");

                    b.ToTable("Traveller");
                });

            modelBuilder.Entity("AirlineProject.Models.StaffMember", b =>
                {
                    b.HasOne("AirlineProject.Models.Airline", "Airline_ID")
                        .WithMany()
                        .HasForeignKey("AirlineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AirlineProject.Models.TicketPrice", b =>
                {
                    b.HasOne("AirlineProject.Models.Airline", "Airline_ID")
                        .WithMany()
                        .HasForeignKey("AirlineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AirlineProject.Models.Traveller", b =>
                {
                    b.HasOne("AirlineProject.Models.StaffMember", "StaffMember_ID")
                        .WithMany()
                        .HasForeignKey("StaffMemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
