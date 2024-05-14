﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryMvcApp.Migrations
{
    /// <inheritdoc />
    public partial class NullCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookLoans_AspNetUsers_CustomerId",
                table: "BookLoans");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "BookLoans",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_BookLoans_AspNetUsers_CustomerId",
                table: "BookLoans",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookLoans_AspNetUsers_CustomerId",
                table: "BookLoans");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "BookLoans",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookLoans_AspNetUsers_CustomerId",
                table: "BookLoans",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
