using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HousePricePrediction.API.Migrations
{
    public partial class updaterelationsdb5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "_total_views",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_total_views",
                table: "users");
        }
    }
}
