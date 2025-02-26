using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSG.SistemaVentas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductoInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Productos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Productos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Productos");
        }
    }
}
