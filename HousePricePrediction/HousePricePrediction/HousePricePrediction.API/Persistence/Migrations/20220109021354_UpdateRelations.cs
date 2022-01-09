using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HousePricePrediction.API.Migrations
{
    public partial class UpdateRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_houses_users__user_temp_id",
                table: "houses");

            migrationBuilder.AddColumn<Guid>(
                name: "_user_id",
                table: "houses",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_houses__user_id",
                table: "houses",
                column: "_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_houses_users__user_temp_id",
                table: "houses",
                column: "_user_id",
                principalTable: "users",
                principalColumn: "_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_houses_users__user_temp_id",
                table: "houses");

            migrationBuilder.DropIndex(
                name: "ix_houses__user_id",
                table: "houses");

            migrationBuilder.DropColumn(
                name: "_user_id",
                table: "houses");

            migrationBuilder.AddForeignKey(
                name: "fk_houses_users__user_temp_id",
                table: "houses",
                column: "_id",
                principalTable: "users",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
