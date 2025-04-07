using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockManager.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionToAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PermissionGroupId",
                table: "Permissions",
                type: "bigint",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "PermissionGroupId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, null, null, "Create user", "CREATE_USER", null, null, null },
                    { 2L, null, null, "Update user", "UPDATE_USER", null, null, null },
                    { 3L, null, null, "View user", "GET_USER", null, null, null },
                    { 4L, null, null, "List user", "LIST_USER", null, null, null },
                    { 5L, null, null, "Delete user", "DELETE_USER", null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$10$2lpGDc.Y9BrKqxgY2LYXO.rao8vjH7TRNpjxN/u8SHrKdDiMZuLx6");

            migrationBuilder.InsertData(
                table: "UserPermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "PermissionId", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[,]
                {
                    { 1L, null, null, 1L, null, null, 1L },
                    { 2L, null, null, 2L, null, null, 1L },
                    { 3L, null, null, 3L, null, null, 1L },
                    { 4L, null, null, 4L, null, null, 1L },
                    { 5L, null, null, 5L, null, null, 1L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DropColumn(
                name: "PermissionGroupId",
                table: "Permissions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$10$xSn0QzvGyqa/PiEC5HCVGO9YUScfqESASF1OWL8dIxTUYBczMRaAq");
        }
    }
}
