using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerceDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddedTotalToBasket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Baskets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Baskets");
        }
    }
}
