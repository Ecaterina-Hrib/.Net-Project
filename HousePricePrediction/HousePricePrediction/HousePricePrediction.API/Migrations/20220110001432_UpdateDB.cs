using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HousePricePrediction.API.Migrations
{
    public partial class UpdateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_area",
                table: "houses");

            migrationBuilder.DropColumn(
                name: "_recommended_price",
                table: "houses");

            migrationBuilder.AlterColumn<float>(
                name: "_current_price",
                table: "houses",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "recommended_price",
                columns: table => new
                {
                    sell_price = table.Column<float>(type: "real", nullable: false),
                    rent_price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recommended_price");

            migrationBuilder.AlterColumn<double>(
                name: "_current_price",
                table: "houses",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_area",
                table: "houses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "_recommended_price",
                table: "houses",
                type: "double precision",
                nullable: true);
        }
    }
}
