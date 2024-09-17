using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniWater_API.Migrations
{
    /// <inheritdoc />
    public partial class IdentityAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6", "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02174cf0–9412–4cfe - afbf - 59f706d72cf6", 0, "b9d967db-0ecb-483b-9aac-b47bba32dbf5", "superadmin@admin.com", true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEAJwNbNXlx15dGhuXr0SlEmI0jHeJDobx/HsXBipYmAAQrsyfYjShMVhwKqDUCnzlQ==", null, false, "cdf1c938-9024-42de-8a50-457b94f96dbb", false, "superadmin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6", "02174cf0–9412–4cfe - afbf - 59f706d72cf6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6", "02174cf0–9412–4cfe - afbf - 59f706d72cf6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6");
        }
    }
}
