using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WeatherForecastBackend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "city",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Name = table.Column<string>(nullable: false),
                ApiCityCode = table.Column<int>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_City", x => x.Id);
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
