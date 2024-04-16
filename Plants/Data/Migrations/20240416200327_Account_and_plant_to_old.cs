using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plants.Data.Migrations
{
    /// <inheritdoc />
    public partial class Account_and_plant_to_old : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "watering_rate",
                table: "Accounts_and_plants",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double[]),
                oldType: "double precision[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double[]>(
                name: "watering_rate",
                table: "Accounts_and_plants",
                type: "double precision[]",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
