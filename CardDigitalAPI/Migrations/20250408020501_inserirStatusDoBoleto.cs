using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardDigitalAPI.Migrations
{
    /// <inheritdoc />
    public partial class inserirStatusDoBoleto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BoletoPago",
                table: "Boletos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoletoPago",
                table: "Boletos");
        }
    }
}
