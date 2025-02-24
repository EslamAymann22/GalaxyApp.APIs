using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalaxyApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_suppliers_purchases_LatestPurchaseId",
                table: "suppliers");

            migrationBuilder.DropIndex(
                name: "IX_suppliers_LatestPurchaseId",
                table: "suppliers");

            migrationBuilder.DropColumn(
                name: "TotalInDiscount",
                table: "purchases");

            migrationBuilder.DropColumn(
                name: "TotalInDiscount",
                table: "InvoiceItems");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_LatestPurchaseId",
                table: "suppliers",
                column: "LatestPurchaseId",
                unique: true,
                filter: "[LatestPurchaseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_purchases_SupplierId",
                table: "purchases",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_purchases_suppliers_SupplierId",
                table: "purchases",
                column: "SupplierId",
                principalTable: "suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_suppliers_purchases_LatestPurchaseId",
                table: "suppliers",
                column: "LatestPurchaseId",
                principalTable: "purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchases_suppliers_SupplierId",
                table: "purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_suppliers_purchases_LatestPurchaseId",
                table: "suppliers");

            migrationBuilder.DropIndex(
                name: "IX_suppliers_LatestPurchaseId",
                table: "suppliers");

            migrationBuilder.DropIndex(
                name: "IX_purchases_SupplierId",
                table: "purchases");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "purchases");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalInDiscount",
                table: "purchases",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalInDiscount",
                table: "InvoiceItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_LatestPurchaseId",
                table: "suppliers",
                column: "LatestPurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_suppliers_purchases_LatestPurchaseId",
                table: "suppliers",
                column: "LatestPurchaseId",
                principalTable: "purchases",
                principalColumn: "Id");
        }
    }
}
