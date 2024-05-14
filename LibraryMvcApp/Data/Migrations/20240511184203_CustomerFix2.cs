﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryMvcApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CustomerFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
