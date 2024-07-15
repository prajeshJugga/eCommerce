using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerceDatabase.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedBundleTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "ProductOnSpecials");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "ProductOnSpecials");

            migrationBuilder.DropColumn(
                name: "CsustomerId",
                table: "Baskets");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductOnSpecials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequiredQuantity",
                table: "ProductOnSpecials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ActiveSpecials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ActiveSpecials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "PercentageOff",
                table: "ActiveSpecials",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductOnSpecials_ProductId",
                table: "ProductOnSpecials",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOnSpecials_Products_ProductId",
                table: "ProductOnSpecials",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOnSpecials_Products_ProductId",
                table: "ProductOnSpecials");

            migrationBuilder.DropIndex(
                name: "IX_ProductOnSpecials_ProductId",
                table: "ProductOnSpecials");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductOnSpecials");

            migrationBuilder.DropColumn(
                name: "RequiredQuantity",
                table: "ProductOnSpecials");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ActiveSpecials");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ActiveSpecials");

            migrationBuilder.DropColumn(
                name: "PercentageOff",
                table: "ActiveSpecials");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "ProductOnSpecials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "ProductOnSpecials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CsustomerId",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
