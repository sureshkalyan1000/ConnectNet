using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectNet.Migrations
{
    /// <inheritdoc />
    public partial class ExtendUserDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "appUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "appUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "appUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "appUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "Genter",
                table: "appUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Intrests",
                table: "appUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "appUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KnownAs",
                table: "appUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                table: "appUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LookingFor",
                table: "appUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "photo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_photo_appUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "appUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_photo_AppUserId",
                table: "photo",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "photo");

            migrationBuilder.DropColumn(
                name: "City",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "Genter",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "Intrests",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "KnownAs",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "LookingFor",
                table: "appUsers");
        }
    }
}
