﻿// <auto-generated />
using System;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessObject.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessObject.Customer", b =>
                {
                    b.Property<string>("username")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("birthday")
                        .HasColumnType("date");

                    b.Property<string>("fullname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("username");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            username = "datnce",
                            address = "123",
                            birthday = new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            fullname = "Nguyen Dat",
                            gender = "nam",
                            password = "1"
                        },
                        new
                        {
                            username = "phong",
                            address = "123",
                            birthday = new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            fullname = "Thanh Phong",
                            gender = "nam",
                            password = "1"
                        },
                        new
                        {
                            username = "hieu",
                            address = "123",
                            birthday = new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            fullname = "Thanh Hieu",
                            gender = "nam",
                            password = "1"
                        },
                        new
                        {
                            username = "minh",
                            address = "123",
                            birthday = new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            fullname = "Duy Minh",
                            gender = "nam",
                            password = "1"
                        },
                        new
                        {
                            username = "khoiminh",
                            address = "123",
                            birthday = new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            fullname = "Khoi Minh",
                            gender = "nam",
                            password = "1"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
