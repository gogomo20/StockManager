using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockManager.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAdminSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "Name", "Password", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { 1L, null, null, "admin@admin", "admin", "$2a$10$xSn0QzvGyqa/PiEC5HCVGO9YUScfqESASF1OWL8dIxTUYBczMRaAq", null, null, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
