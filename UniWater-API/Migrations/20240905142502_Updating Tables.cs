using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniWater_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Humidity",
                table: "SystemParameters");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "SystemParameters");

            migrationBuilder.CreateTable(
                name: "StreamData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Humidity = table.Column<float>(type: "REAL", nullable: false),
                    Temperature = table.Column<float>(type: "REAL", nullable: false),
                    InternalClock = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreamData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StreamData");

            migrationBuilder.AddColumn<float>(
                name: "Humidity",
                table: "SystemParameters",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Temperature",
                table: "SystemParameters",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
