using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStoreAPI.Migrations
{
    public partial class AddColumnProductDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductDetails",
                table: "Instruments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductDetails",
                table: "Instruments");
        }
    }
}
