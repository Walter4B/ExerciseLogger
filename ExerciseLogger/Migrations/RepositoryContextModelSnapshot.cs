﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace ExerciseLogger.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ExerciseId");

                    b.Property<string>("Comments")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GymId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("GymId");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            Comments = "Jhon's has a nice view, lacking in equipment but got a good exercise feeling the burn.",
                            Duration = new TimeSpan(0, 0, 45, 0, 0),
                            EndTime = new DateTime(2022, 5, 1, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            GymId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            StartTime = new DateTime(2022, 5, 1, 9, 15, 0, 0, DateTimeKind.Unspecified),
                            Type = "Cardio"
                        },
                        new
                        {
                            Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            Comments = "Steve's is briliant, they have all the equipmnet I need, before I go I will bench 200kg gonna go slow.",
                            Duration = new TimeSpan(0, 1, 30, 0, 0),
                            EndTime = new DateTime(2022, 5, 2, 10, 45, 0, 0, DateTimeKind.Unspecified),
                            GymId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            StartTime = new DateTime(2022, 5, 2, 9, 15, 0, 0, DateTimeKind.Unspecified),
                            Type = "Strength"
                        },
                        new
                        {
                            Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            Comments = "Steve's is excelent for physical.",
                            Duration = new TimeSpan(0, 0, 30, 0, 0),
                            EndTime = new DateTime(2022, 6, 17, 9, 45, 0, 0, DateTimeKind.Unspecified),
                            GymId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            StartTime = new DateTime(2022, 6, 17, 9, 15, 0, 0, DateTimeKind.Unspecified),
                            Type = "Physical"
                        });
                });

            modelBuilder.Entity("Entities.Models.Gym", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("GymId");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Gyms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Address = "Jhon's street 123",
                            Name = "Jhon's Pumphouse"
                        },
                        new
                        {
                            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Address = "Jhon's street 124",
                            Name = "Steve's Stoneworks"
                        });
                });

            modelBuilder.Entity("Entities.Models.Exercise", b =>
                {
                    b.HasOne("Entities.Models.Gym", "Gym")
                        .WithMany("Exercises")
                        .HasForeignKey("GymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gym");
                });

            modelBuilder.Entity("Entities.Models.Gym", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
