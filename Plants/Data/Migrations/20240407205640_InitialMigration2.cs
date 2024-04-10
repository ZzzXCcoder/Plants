using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plants.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Plant_description",
                table: "Plants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Plant_name",
                table: "Plants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Plant_type",
                table: "Plants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "watering_rate",
                table: "Accounts_and_plants",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "watering_time",
                table: "Accounts_and_plants",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plant_description",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Plant_name",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Plant_type",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "watering_rate",
                table: "Accounts_and_plants");

            migrationBuilder.DropColumn(
                name: "watering_time",
                table: "Accounts_and_plants");
        }
    }
}
