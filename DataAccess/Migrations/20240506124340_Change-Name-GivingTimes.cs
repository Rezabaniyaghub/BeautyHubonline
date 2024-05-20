using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameGivingTimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceModels_Customers_CustomerId",
                table: "ServiceModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceModels_Hairstylists_HairstylistId",
                table: "ServiceModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceModels",
                table: "ServiceModels");

            migrationBuilder.RenameTable(
                name: "ServiceModels",
                newName: "GivingTimes");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceModels_HairstylistId",
                table: "GivingTimes",
                newName: "IX_GivingTimes_HairstylistId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceModels_CustomerId",
                table: "GivingTimes",
                newName: "IX_GivingTimes_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GivingTimes",
                table: "GivingTimes",
                column: "GivingTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GivingTimes_Customers_CustomerId",
                table: "GivingTimes",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GivingTimes_Hairstylists_HairstylistId",
                table: "GivingTimes",
                column: "HairstylistId",
                principalTable: "Hairstylists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GivingTimes_Customers_CustomerId",
                table: "GivingTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_GivingTimes_Hairstylists_HairstylistId",
                table: "GivingTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GivingTimes",
                table: "GivingTimes");

            migrationBuilder.RenameTable(
                name: "GivingTimes",
                newName: "ServiceModels");

            migrationBuilder.RenameIndex(
                name: "IX_GivingTimes_HairstylistId",
                table: "ServiceModels",
                newName: "IX_ServiceModels_HairstylistId");

            migrationBuilder.RenameIndex(
                name: "IX_GivingTimes_CustomerId",
                table: "ServiceModels",
                newName: "IX_ServiceModels_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceModels",
                table: "ServiceModels",
                column: "GivingTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceModels_Customers_CustomerId",
                table: "ServiceModels",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceModels_Hairstylists_HairstylistId",
                table: "ServiceModels",
                column: "HairstylistId",
                principalTable: "Hairstylists",
                principalColumn: "Id");
        }
    }
}
