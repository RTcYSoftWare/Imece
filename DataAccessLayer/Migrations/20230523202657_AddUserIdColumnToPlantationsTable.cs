using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdColumnToPlantationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Plantations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_GrowingAreaId",
                table: "Plantations",
                column: "GrowingAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_IrrigationTypeId",
                table: "Plantations",
                column: "IrrigationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_ProductId",
                table: "Plantations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_ProductTypeId",
                table: "Plantations",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_SoilTypeId",
                table: "Plantations",
                column: "SoilTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantations_GrowingAreas_GrowingAreaId",
                table: "Plantations",
                column: "GrowingAreaId",
                principalTable: "GrowingAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantations_IrrigationTypes_IrrigationTypeId",
                table: "Plantations",
                column: "IrrigationTypeId",
                principalTable: "IrrigationTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantations_ProductTypes_ProductTypeId",
                table: "Plantations",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantations_Products_ProductId",
                table: "Plantations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantations_SoilTypes_SoilTypeId",
                table: "Plantations",
                column: "SoilTypeId",
                principalTable: "SoilTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantations_GrowingAreas_GrowingAreaId",
                table: "Plantations");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantations_IrrigationTypes_IrrigationTypeId",
                table: "Plantations");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantations_ProductTypes_ProductTypeId",
                table: "Plantations");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantations_Products_ProductId",
                table: "Plantations");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantations_SoilTypes_SoilTypeId",
                table: "Plantations");

            migrationBuilder.DropIndex(
                name: "IX_Plantations_GrowingAreaId",
                table: "Plantations");

            migrationBuilder.DropIndex(
                name: "IX_Plantations_IrrigationTypeId",
                table: "Plantations");

            migrationBuilder.DropIndex(
                name: "IX_Plantations_ProductId",
                table: "Plantations");

            migrationBuilder.DropIndex(
                name: "IX_Plantations_ProductTypeId",
                table: "Plantations");

            migrationBuilder.DropIndex(
                name: "IX_Plantations_SoilTypeId",
                table: "Plantations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Plantations");
        }
    }
}
