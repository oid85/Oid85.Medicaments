using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oid85.Medicaments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _02012026_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Reserve",
                schema: "public",
                table: "PillEntities",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reserve",
                schema: "public",
                table: "PillEntities");
        }
    }
}
