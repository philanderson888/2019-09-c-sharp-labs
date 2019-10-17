﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab_48_api_todo_list_core;

namespace lab_48_api_todo_list_core.Migrations
{
    [DbContext(typeof(TaskItemContext))]
    [Migration("20191011103512_seed18")]
    partial class seed18
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("lab_48_api_todo_list_core.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new { CategoryId = 1, CategoryName = "Admin" },
                        new { CategoryId = 2, CategoryName = "Work" },
                        new { CategoryId = 3, CategoryName = "Training" }
                    );
                });

            modelBuilder.Entity("lab_48_api_todo_list_core.TaskItem", b =>
                {
                    b.Property<int>("TaskItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<DateTime?>("DateDue");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<bool?>("TaskDone");

                    b.Property<int?>("UserId");

                    b.HasKey("TaskItemId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("TaskItems");

                    b.HasData(
                        new { TaskItemId = 1, CategoryId = 1, DateDue = new DateTime(2019, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Some Item", UserId = 1 },
                        new { TaskItemId = 2, CategoryId = 2, DateDue = new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Another Item", UserId = 2 },
                        new { TaskItemId = 3, CategoryId = 3, DateDue = new DateTime(2019, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "And This Item", UserId = 3 }
                    );
                });

            modelBuilder.Entity("lab_48_api_todo_list_core.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new { UserId = 1, UserName = "Spartan01" },
                        new { UserId = 2, UserName = "Fred" },
                        new { UserId = 3, UserName = "Paul" }
                    );
                });

            modelBuilder.Entity("lab_48_api_todo_list_core.TaskItem", b =>
                {
                    b.HasOne("lab_48_api_todo_list_core.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("lab_48_api_todo_list_core.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
