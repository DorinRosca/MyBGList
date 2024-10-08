﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBGList.Migrations
{
    /// <inheritdoc />
    public partial class AddPublisherTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Flags",
                table: "Mechanics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Mechanics",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Flags",
                table: "Domains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Domains",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AlternameNames",
                table: "BoardGames",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Designer",
                table: "BoardGames",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Flags",
                table: "BoardGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "BoardGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_PublisherId",
                table: "BoardGames",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_Publishers_PublisherId",
                table: "BoardGames",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_Publishers_PublisherId",
                table: "BoardGames");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropIndex(
                name: "IX_BoardGames_PublisherId",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "Flags",
                table: "Mechanics");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Mechanics");

            migrationBuilder.DropColumn(
                name: "Flags",
                table: "Domains");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Domains");

            migrationBuilder.DropColumn(
                name: "AlternameNames",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "Designer",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "Flags",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "BoardGames");
        }
    }
}
