﻿// <auto-generated />
using System;
using Bio_Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bio_Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230405134023_contact1")]
    partial class contact1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Bio_Data.Models.Account.User1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users1");
                });

            modelBuilder.Entity("Bio_Data.Models.Contactdetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int>("ContactNo")
                        .HasColumnType("integer");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("contactdetails");
                });

            modelBuilder.Entity("Bio_Data.Models.Familydetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ElderBrotherName")
                        .HasColumnType("text");

                    b.Property<string>("ElderBrotherOccupation")
                        .HasColumnType("text");

                    b.Property<string>("ElderSisterName")
                        .HasColumnType("text");

                    b.Property<string>("ElderSisterOccupation")
                        .HasColumnType("text");

                    b.Property<string>("FatherName")
                        .HasColumnType("text");

                    b.Property<string>("FatherOccupation")
                        .HasColumnType("text");

                    b.Property<string>("MotherName")
                        .HasColumnType("text");

                    b.Property<string>("MotherOccupation")
                        .HasColumnType("text");

                    b.Property<string>("YoungerBrotherName")
                        .HasColumnType("text");

                    b.Property<string>("YoungerBrotherOccupation")
                        .HasColumnType("text");

                    b.Property<string>("YoungerSisterName")
                        .HasColumnType("text");

                    b.Property<string>("YoungerSisterOccupation")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("familydetails");
                });

            modelBuilder.Entity("Bio_Data.Models.Personaldetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Cast")
                        .HasColumnType("text");

                    b.Property<string>("Complexion")
                        .HasColumnType("text");

                    b.Property<DateTime>("Dateoftime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Education")
                        .HasColumnType("text");

                    b.Property<decimal>("Height")
                        .HasColumnType("numeric");

                    b.Property<string>("Job")
                        .HasColumnType("text");

                    b.Property<string>("Nakshtra")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PlaceOfBirth")
                        .HasColumnType("text");

                    b.Property<string>("Rasi")
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("personaldetails");
                });
#pragma warning restore 612, 618
        }
    }
}
