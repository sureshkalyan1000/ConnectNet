using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectNet.Migrations
{
    /// <inheritdoc />
    public partial class exten : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_photo_appUsers_AppUserId",
                table: "photo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appUsers",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "Genter",
                table: "appUsers");

            migrationBuilder.RenameTable(
                name: "appUsers",
                newName: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "ISMain",
                table: "photo",
                newName: "IsMain");

            migrationBuilder.RenameColumn(
                name: "Intrests",
                table: "AppUsers",
                newName: "Interests");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_photo_AppUsers_AppUserId",
                table: "photo",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_photo_AppUsers_AppUserId",
                table: "photo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AppUsers");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                newName: "appUsers");

            migrationBuilder.RenameColumn(
                name: "IsMain",
                table: "photo",
                newName: "ISMain");

            migrationBuilder.RenameColumn(
                name: "Interests",
                table: "appUsers",
                newName: "Intrests");

            migrationBuilder.AddColumn<int>(
                name: "Genter",
                table: "appUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_appUsers",
                table: "appUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_photo_appUsers_AppUserId",
                table: "photo",
                column: "AppUserId",
                principalTable: "appUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
