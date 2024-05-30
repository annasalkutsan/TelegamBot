using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldInPersonCustomFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_Persons_PersonCreationDate",
                table: "CustomFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_PersonCreationDate",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "PersonCreationDate",
                table: "CustomFields");

            migrationBuilder.AddColumn<int>(
                name: "CustomFields_Capacity",
                table: "Persons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CustomFields_Name",
                table: "Persons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomFields_Value",
                table: "Persons",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomFields_Capacity",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CustomFields_Name",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CustomFields_Value",
                table: "Persons");

            migrationBuilder.AddColumn<DateTime>(
                name: "PersonCreationDate",
                table: "CustomFields",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_PersonCreationDate",
                table: "CustomFields",
                column: "PersonCreationDate");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_Persons_PersonCreationDate",
                table: "CustomFields",
                column: "PersonCreationDate",
                principalTable: "Persons",
                principalColumn: "CreationDate");
        }
    }
}
