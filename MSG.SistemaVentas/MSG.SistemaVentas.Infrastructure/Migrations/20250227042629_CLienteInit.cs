using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSG.SistemaVentas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CLienteInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Clientes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Clientes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Clientes");
        }
    }
}
