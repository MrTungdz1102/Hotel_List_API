using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hotel_List_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedIdentityRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d245e18d-0eef-4df1-9b3d-8bcde38467dd", null, "User", "USER" },
                    { "ee25b15f-2aeb-4758-a844-68cb6a07f32d", null, "Admin", "Administrator" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d245e18d-0eef-4df1-9b3d-8bcde38467dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee25b15f-2aeb-4758-a844-68cb6a07f32d");
        }
    }
}
