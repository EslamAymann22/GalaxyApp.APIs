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
                name: "FK_customerPurchaseItems_customerPurchases_CustomerPurchaseId",
                table: "customerPurchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_customerPurchaseItems_products_ProductId",
                table: "customerPurchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_customerPurchases_customers_CustomerId",
                table: "customerPurchases");

            migrationBuilder.AddForeignKey(
                name: "FK_customerPurchaseItems_customerPurchases_CustomerPurchaseId",
                table: "customerPurchaseItems",
                column: "CustomerPurchaseId",
                principalTable: "customerPurchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_customerPurchaseItems_products_ProductId",
                table: "customerPurchaseItems",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_customerPurchases_customers_CustomerId",
                table: "customerPurchases",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customerPurchaseItems_customerPurchases_CustomerPurchaseId",
                table: "customerPurchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_customerPurchaseItems_products_ProductId",
                table: "customerPurchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_customerPurchases_customers_CustomerId",
                table: "customerPurchases");

            migrationBuilder.AddForeignKey(
                name: "FK_customerPurchaseItems_customerPurchases_CustomerPurchaseId",
                table: "customerPurchaseItems",
                column: "CustomerPurchaseId",
                principalTable: "customerPurchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_customerPurchaseItems_products_ProductId",
                table: "customerPurchaseItems",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_customerPurchases_customers_CustomerId",
                table: "customerPurchases",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
