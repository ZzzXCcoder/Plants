using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plants.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Plants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Accounts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Accounts");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Plants",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Accounts",
                type: "bytea",
                nullable: true);
        }
    }
}
