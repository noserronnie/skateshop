using Microsoft.EntityFrameworkCore.Migrations;

namespace Skateshop.Migrations
{
    public partial class addedBrands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BrandId",
                table: "TrucksProduct",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BrandId",
                table: "DeckProduct",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrucksProduct_BrandId",
                table: "TrucksProduct",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckProduct_BrandId",
                table: "DeckProduct",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeckProduct_Brand_BrandId",
                table: "DeckProduct",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrucksProduct_Brand_BrandId",
                table: "TrucksProduct",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeckProduct_Brand_BrandId",
                table: "DeckProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_TrucksProduct_Brand_BrandId",
                table: "TrucksProduct");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_TrucksProduct_BrandId",
                table: "TrucksProduct");

            migrationBuilder.DropIndex(
                name: "IX_DeckProduct_BrandId",
                table: "DeckProduct");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "TrucksProduct");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "DeckProduct");
        }
    }
}
