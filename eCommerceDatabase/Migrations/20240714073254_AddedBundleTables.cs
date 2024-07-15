using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerceDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddedBundleTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BundleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BundleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActiveSpecials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BundleTypeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveSpecials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveSpecials_BundleTypes_BundleTypeId",
                        column: x => x.BundleTypeId,
                        principalTable: "BundleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOnSpecials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveSpecialId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOnSpecials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOnSpecials_ActiveSpecials_ActiveSpecialId",
                        column: x => x.ActiveSpecialId,
                        principalTable: "ActiveSpecials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveSpecials_BundleTypeId",
                table: "ActiveSpecials",
                column: "BundleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOnSpecials_ActiveSpecialId",
                table: "ProductOnSpecials",
                column: "ActiveSpecialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOnSpecials");

            migrationBuilder.DropTable(
                name: "ActiveSpecials");

            migrationBuilder.DropTable(
                name: "BundleTypes");
        }
    }
}
