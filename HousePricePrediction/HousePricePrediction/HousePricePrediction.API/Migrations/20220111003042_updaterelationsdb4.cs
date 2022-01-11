using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HousePricePrediction.API.Migrations
{
    public partial class updaterelationsdb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "iv",
                table: "users",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "key",
                table: "users",
                type: "bytea",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "iv",
                table: "users");

            migrationBuilder.DropColumn(
                name: "key",
                table: "users");
        }
    }
}
