﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBookApp.Migrations
{
    /// <inheritdoc />
    public partial class Imageurlnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Contact",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Contact");
        }
    }
}
