using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopMVC.Migrations
{
    /// <inheritdoc />
    public partial class product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.CreateTable(
				name: "Product",
				columns: table => new
				{
					ProductId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					ProductDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
					ProductQuantity = table.Column<int>(type: "int", nullable: false),
					ProductImage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
					BrandId = table.Column<int>(type: "int", nullable: false),
					CategoryId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Product", x => x.ProductId);
					table.ForeignKey(
						name: "FK_Product_Brand_BrandId",
						column: x => x.BrandId,
						principalTable: "Brand",
						principalColumn: "BrandId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Product_Category_CategoryId",
						column: x => x.CategoryId,
						principalTable: "Category",
						principalColumn: "CategoryId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Product_BrandId",
				table: "Product",
				column: "BrandId");

			migrationBuilder.CreateIndex(
				name: "IX_Product_CategoryId",
				table: "Product",
				column: "CategoryId");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropTable(
				name: "Product");
		}
    }
}
