﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission08_Group1_2.Models;

namespace Mission08_Group1_2.Migrations
{
    [DbContext(typeof(TaskAdditionsContext))]
    [Migration("20230223231719_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("Mission08_Group1_2.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Home"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "School"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Work"
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Church"
                        });
                });

            modelBuilder.Entity("Mission08_Group1_2.Models.TaskAddition", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quadrant")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Task")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryID");

                    b.ToTable("Additions");

                    b.HasData(
                        new
                        {
                            TaskId = 1,
                            CategoryID = 1,
                            Completed = false,
                            DueDate = "10/10/2023",
                            Quadrant = 1,
                            Task = "Get up"
                        },
                        new
                        {
                            TaskId = 2,
                            CategoryID = 2,
                            Completed = false,
                            DueDate = "10/10/2023",
                            Quadrant = 1,
                            Task = "Show up"
                        });
                });

            modelBuilder.Entity("Mission08_Group1_2.Models.TaskAddition", b =>
                {
                    b.HasOne("Mission08_Group1_2.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
