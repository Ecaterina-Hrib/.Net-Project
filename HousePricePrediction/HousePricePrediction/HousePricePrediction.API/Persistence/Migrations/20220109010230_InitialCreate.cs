using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HousePricePrediction.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    _id = table.Column<Guid>(type: "uuid", nullable: false),
                    _name = table.Column<string>(type: "text", nullable: true),
                    _phone_number = table.Column<string>(type: "text", nullable: true),
                    _username = table.Column<string>(type: "text", nullable: true),
                    _email = table.Column<string>(type: "text", nullable: true),
                    _password = table.Column<string>(type: "text", nullable: true),
                    _creation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "houses",
                columns: table => new
                {
                    _id = table.Column<Guid>(type: "uuid", nullable: false),
                    _description = table.Column<string>(type: "text", nullable: true),
                    _title = table.Column<string>(type: "text", nullable: true),
                    _city = table.Column<string>(type: "text", nullable: true),
                    _country = table.Column<string>(type: "text", nullable: true),
                    _address = table.Column<string>(type: "text", nullable: true),
                    _area = table.Column<string>(type: "text", nullable: true),
                    _latitude = table.Column<double>(type: "double precision", nullable: true),
                    _longitude = table.Column<double>(type: "double precision", nullable: true),
                    _construction_year = table.Column<float>(type: "real", nullable: true),
                    _no_of_rooms = table.Column<float>(type: "real", nullable: true),
                    _floor = table.Column<float>(type: "real", nullable: true),
                    _surface = table.Column<float>(type: "real", nullable: true),
                    _land_surface = table.Column<float>(type: "real", nullable: true),
                    _no_of_bathrooms = table.Column<float>(type: "real", nullable: true),
                    _view = table.Column<float>(type: "real", nullable: true),
                    _condition = table.Column<float>(type: "real", nullable: true),
                    _grade = table.Column<float>(type: "real", nullable: true),
                    _sqft_basement = table.Column<float>(type: "real", nullable: true),
                    _yr_renovated = table.Column<float>(type: "real", nullable: true),
                    _zipcode = table.Column<float>(type: "real", nullable: true),
                    _recommended_price = table.Column<double>(type: "double precision", nullable: true),
                    _current_price = table.Column<double>(type: "double precision", nullable: true),
                    _creation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    _views = table.Column<int>(type: "integer", nullable: false),
                    _pictures = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_houses", x => x._id);
                    table.ForeignKey(
                        name: "fk_houses_users__user_temp_id",
                        column: x => x._id,
                        principalTable: "users",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "houses");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
