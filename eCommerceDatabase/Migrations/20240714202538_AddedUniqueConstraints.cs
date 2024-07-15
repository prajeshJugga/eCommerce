using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerceDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddedUniqueConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductOnSpecials_ProductId",
                table: "ProductOnSpecials");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductCategories",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BundleTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ActiveSpecials",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Products_Name_BrandId",
                table: "Products",
                columns: new[] { "Name", "BrandId" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProductOnSpecials_ProductId_ActiveSpecialId",
                table: "ProductOnSpecials",
                columns: new[] { "ProductId", "ActiveSpecialId" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProductCategories_Name",
                table: "ProductCategories",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Customers_Username_Email_Phone",
                table: "Customers",
                columns: new[] { "Username", "Email", "Phone" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_BundleTypes_Name",
                table: "BundleTypes",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Brands_Name",
                table: "Brands",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ActiveSpecials_Name_StartDate_EndDate",
                table: "ActiveSpecials",
                columns: new[] { "Name", "StartDate", "EndDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Products_Name_BrandId",
                table: "Products");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProductOnSpecials_ProductId_ActiveSpecialId",
                table: "ProductOnSpecials");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProductCategories_Name",
                table: "ProductCategories");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Customers_Username_Email_Phone",
                table: "Customers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_BundleTypes_Name",
                table: "BundleTypes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Brands_Name",
                table: "Brands");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ActiveSpecials_Name_StartDate_EndDate",
                table: "ActiveSpecials");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BundleTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ActiveSpecials",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOnSpecials_ProductId",
                table: "ProductOnSpecials",
                column: "ProductId");
        }
    }
}
