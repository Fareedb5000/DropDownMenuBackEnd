using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDropDownMenu.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Comment out the CarBrands table creation to avoid conflicts
            // migrationBuilder.CreateTable(
            //     name: "CarBrands",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_CarBrands", x => x.Id);
            //     });

            // Comment out the CarBrandCarMakeMatrix table creation to avoid conflicts
            // migrationBuilder.CreateTable(
            //     name: "CarBrandCarMakeMatrix",
            //     columns: table => new
            //     {
            //         CarBrandId = table.Column<int>(type: "int", nullable: false),
            //         CarMakeId = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_CarBrandCarMakeMatrix", x => new { x.CarBrandId, x.CarMakeId });
            //         table.ForeignKey(
            //             name: "FK_CarBrandCarMakeMatrix_CarBrands_CarBrandId",
            //             column: x => x.CarBrandId,
            //             principalTable: "CarBrands",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_CarBrandCarMakeMatrix_CarMakes_CarMakeId",
            //             column: x => x.CarMakeId,
            //             principalTable: "CarMakes",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            migrationBuilder.CreateTable(
                name: "CarMakes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarBrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarMakes", x => x.Id);
                });

            // Create other tables if needed
            migrationBuilder.CreateIndex(
                name: "IX_CarBrandCarMakeMatrix_CarMakeId",
                table: "CarBrandCarMakeMatrix",
                column: "CarMakeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarBrandCarMakeMatrix");

            // Do not drop CarBrands since it already exists
            // migrationBuilder.DropTable(
            //     name: "CarBrands");

            migrationBuilder.DropTable(
                name: "CarMakes");
        }
    }
}
