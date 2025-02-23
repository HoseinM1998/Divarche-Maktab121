using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Divarcheh.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class addfullnameclaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 2, "FullName", "مسعود ملکی", 1 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "889cc20c-3cd7-4322-a06a-a8ae51ea1503", "AQAAAAIAAYagAAAAELFvUBgeSg1M8B9ag0TmuFQKgwKIFnI7ReP46sntDF5l9ZKgIDofTzEdroH+lPsAQQ==", "d8020bb2-732f-4bfc-893c-3366a152fd83" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ee7ce22-9911-4ba0-bcf8-2d3968d43cc2", "AQAAAAIAAYagAAAAEAvEFzzoE4hmFTU1MOpMCbO6Dxx2XyQLeugt+ZUTDmu2wGQbJlqfvPEqUr53UiCnyw==", "e0e485a2-e854-4a45-8a39-59006ec22883" });
        }
    }
}
