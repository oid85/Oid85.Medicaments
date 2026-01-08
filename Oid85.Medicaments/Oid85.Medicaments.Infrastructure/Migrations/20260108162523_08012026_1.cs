using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oid85.Medicaments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _08012026_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alias",
                schema: "public",
                table: "MedicamentEntities",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                schema: "public",
                table: "MedicamentEntities");
        }
    }
}
