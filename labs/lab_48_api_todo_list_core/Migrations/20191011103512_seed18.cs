﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lab_48_api_todo_list_core.Migrations
{
    public partial class seed18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    TaskItemId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: false),
                    TaskDone = table.Column<bool>(nullable: true),
                    DateDue = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.TaskItemId);
                    table.ForeignKey(
                        name: "FK_TaskItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "Work" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Training" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserName" },
                values: new object[] { 1, "Spartan01" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserName" },
                values: new object[] { 2, "Fred" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserName" },
                values: new object[] { 3, "Paul" });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "TaskItemId", "CategoryId", "DateDue", "Description", "TaskDone", "UserId" },
                values: new object[] { 1, 1, new DateTime(2019, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some Item", null, 1 });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "TaskItemId", "CategoryId", "DateDue", "Description", "TaskDone", "UserId" },
                values: new object[] { 2, 2, new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Another Item", null, 2 });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "TaskItemId", "CategoryId", "DateDue", "Description", "TaskDone", "UserId" },
                values: new object[] { 3, 3, new DateTime(2019, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "And This Item", null, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_CategoryId",
                table: "TaskItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_UserId",
                table: "TaskItems",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItems");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
