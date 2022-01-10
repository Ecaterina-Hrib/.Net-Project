using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HousePricePrediction.API.Migrations
{
    public partial class updaterelationsdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_houses_users__user_temp_id",
                table: "houses");

            migrationBuilder.AlterColumn<Guid>(
                name: "_user_id",
                table: "houses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_houses_users__user_temp_id",
                table: "houses",
                column: "_user_id",
                principalTable: "users",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_houses_users__user_temp_id",
                table: "houses");

            migrationBuilder.AlterColumn<Guid>(
                name: "_user_id",
                table: "houses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "fk_houses_users__user_temp_id",
                table: "houses",
                column: "_user_id",
                principalTable: "users",
                principalColumn: "_id");
        }
    }
}
