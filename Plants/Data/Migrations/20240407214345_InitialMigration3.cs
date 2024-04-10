using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plants.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_and_plants_Accounts_Id",
                table: "Accounts_and_plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_and_plants_Plants_Id",
                table: "Accounts_and_plants");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Accounts_and_plants",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PlantId",
                table: "Accounts_and_plants",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_and_plants_AccountId",
                table: "Accounts_and_plants",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_and_plants_PlantId",
                table: "Accounts_and_plants",
                column: "PlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_and_plants_Accounts_AccountId",
                table: "Accounts_and_plants",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_and_plants_Plants_PlantId",
                table: "Accounts_and_plants",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_and_plants_Accounts_AccountId",
                table: "Accounts_and_plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_and_plants_Plants_PlantId",
                table: "Accounts_and_plants");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_and_plants_AccountId",
                table: "Accounts_and_plants");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_and_plants_PlantId",
                table: "Accounts_and_plants");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Accounts_and_plants");

            migrationBuilder.DropColumn(
                name: "PlantId",
                table: "Accounts_and_plants");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_and_plants_Accounts_Id",
                table: "Accounts_and_plants",
                column: "Id",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_and_plants_Plants_Id",
                table: "Accounts_and_plants",
                column: "Id",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
