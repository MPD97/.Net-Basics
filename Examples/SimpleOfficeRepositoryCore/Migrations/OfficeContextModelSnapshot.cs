﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleOfficeRepositoryCore.Data.Entities;

namespace SimpleOfficeRepositoryCore.Migrations
{
    [DbContext(typeof(OfficeContext))]
    partial class OfficeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleOfficeRepositoryCore.Data.Entities.Desk", b =>
                {
                    b.Property<int>("DeskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<int?>("OwnerPersonId")
                        .HasColumnType("int");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("DeskId");

                    b.HasIndex("OwnerPersonId");

                    b.HasIndex("RoomId");

                    b.ToTable("Desks");

                    b.HasData(
                        new
                        {
                            DeskId = 1,
                            Height = 1.05,
                            Length = 2.3300000000000001,
                            RoomId = 2,
                            Width = 1.1499999999999999
                        },
                        new
                        {
                            DeskId = 2,
                            Height = 1.1499999999999999,
                            Length = 2.1099999999999999,
                            RoomId = 1,
                            Width = 1.3500000000000001
                        },
                        new
                        {
                            DeskId = 3,
                            Height = 0.94999999999999996,
                            Length = 1.8300000000000001,
                            RoomId = 2,
                            Width = 1.0700000000000001
                        },
                        new
                        {
                            DeskId = 4,
                            Height = 1.3500000000000001,
                            Length = 1.7,
                            RoomId = 4,
                            Width = 1.7
                        });
                });

            modelBuilder.Entity("SimpleOfficeRepositoryCore.Data.Entities.Office", b =>
                {
                    b.Property<int>("OfficeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfficeId");

                    b.ToTable("Offices");

                    b.HasData(
                        new
                        {
                            OfficeId = 1,
                            CompanyName = "Flying Cars Company",
                            Location = "Kornela Ujejskiego 75, 85-168 Bydgoszcz"
                        },
                        new
                        {
                            OfficeId = 2,
                            CompanyName = "Hire Apprentice Only Company",
                            Location = "plac Politechniki 1, 00-661 Warszawa"
                        });
                });

            modelBuilder.Entity("SimpleOfficeRepositoryCore.Data.Entities.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OfficeId")
                        .HasColumnType("int");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("Surename")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.HasIndex("OfficeId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            Age = 22,
                            FirstName = "Matthew",
                            HireDate = new DateTime(2017, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Sex = 2,
                            Surename = "Coolman"
                        },
                        new
                        {
                            PersonId = 2,
                            Age = 32,
                            FirstName = "Chris",
                            HireDate = new DateTime(2017, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Sex = 2,
                            Surename = "Baldman"
                        },
                        new
                        {
                            PersonId = 3,
                            Age = 38,
                            FirstName = "Kate",
                            HireDate = new DateTime(2008, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Sex = 1,
                            Surename = "Talklady"
                        });
                });

            modelBuilder.Entity("SimpleOfficeRepositoryCore.Data.Entities.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumberOfWindows")
                        .HasColumnType("int");

                    b.Property<int?>("OfficeId")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.HasIndex("OfficeId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            NumberOfWindows = 3,
                            RoomNumber = 233
                        },
                        new
                        {
                            RoomId = 2,
                            NumberOfWindows = 2,
                            RoomNumber = 41
                        },
                        new
                        {
                            RoomId = 3,
                            NumberOfWindows = 6,
                            RoomNumber = 74
                        },
                        new
                        {
                            RoomId = 4,
                            NumberOfWindows = 0,
                            RoomNumber = 331
                        },
                        new
                        {
                            RoomId = 5,
                            NumberOfWindows = 5,
                            RoomNumber = 15
                        });
                });

            modelBuilder.Entity("SimpleOfficeRepositoryCore.Data.Entities.Desk", b =>
                {
                    b.HasOne("SimpleOfficeRepositoryCore.Data.Entities.Person", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerPersonId");

                    b.HasOne("SimpleOfficeRepositoryCore.Data.Entities.Room", "Room")
                        .WithMany("Desks")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("SimpleOfficeRepositoryCore.Data.Entities.Person", b =>
                {
                    b.HasOne("SimpleOfficeRepositoryCore.Data.Entities.Office", "Office")
                        .WithMany("Employees")
                        .HasForeignKey("OfficeId");
                });

            modelBuilder.Entity("SimpleOfficeRepositoryCore.Data.Entities.Room", b =>
                {
                    b.HasOne("SimpleOfficeRepositoryCore.Data.Entities.Office", null)
                        .WithMany("Rooms")
                        .HasForeignKey("OfficeId");
                });
#pragma warning restore 612, 618
        }
    }
}
