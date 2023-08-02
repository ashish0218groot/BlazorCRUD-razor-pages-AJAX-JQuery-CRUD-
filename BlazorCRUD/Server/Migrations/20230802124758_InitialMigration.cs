﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorCRUD.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperHeroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeroName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperHeroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuperHeroes_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Comics",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Marvel" },
                    { 2, "DC" }
                });

            migrationBuilder.InsertData(
                table: "SuperHeroes",
                columns: new[] { "Id", "ComicId", "FirstName", "HeroName", "LastName" },
                values: new object[,]
                {
                    { 1, 1, "Peter", "Spiderman", "Parker" },
                    { 2, 2, "Bruce", "Batman", "Wayne" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroes_ComicId",
                table: "SuperHeroes",
                column: "ComicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuperHeroes");

            migrationBuilder.DropTable(
                name: "Comics");
        }
    }
}
