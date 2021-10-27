using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagment.Infrastructure.EfCore.Migrations
{
    public partial class IsRemovedAddedToProductCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "ProductCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "ProductCategories");
        }
    }
}
