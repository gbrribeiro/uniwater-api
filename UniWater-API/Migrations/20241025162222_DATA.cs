using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniWater_API.Migrations
{
    /// <inheritdoc />
    public partial class DATA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "530bd0ca-951c-479c-95ad-382c3b79ee8f", "AQAAAAIAAYagAAAAEC6cO4jW+i3Nkc5zj987aDfja2vMWdqXRB71/jBBnS421cyJa4MRhrSimZUJrTvhrw==", "1cc81abb-93b8-463c-9203-929f381f5071" });

            migrationBuilder.InsertData(
                table: "StreamData",
                columns: new[] { "Id", "Humidity", "InternalClock", "Temperature" },
                values: new object[] { 1, 1f, new DateTime(2024, 10, 25, 16, 22, 22, 501, DateTimeKind.Utc).AddTicks(325), 1f });

            migrationBuilder.InsertData(
                table: "SystemParameters",
                columns: new[] { "Id", "DangerousTemperature", "HumidityOffPercentage", "HumidityOnPercentage" },
                values: new object[] { 1, 100f, 90, 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StreamData",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9d967db-0ecb-483b-9aac-b47bba32dbf5", "AQAAAAIAAYagAAAAEAJwNbNXlx15dGhuXr0SlEmI0jHeJDobx/HsXBipYmAAQrsyfYjShMVhwKqDUCnzlQ==", "cdf1c938-9024-42de-8a50-457b94f96dbb" });
        }
    }
}
