using Microsoft.EntityFrameworkCore.Migrations;

namespace Skateshop.Migrations
{
    public partial class AddedNameAndImagePathToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "DeckProduct",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DeckProduct",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "DeckProduct");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DeckProduct");
        }
    }
}
