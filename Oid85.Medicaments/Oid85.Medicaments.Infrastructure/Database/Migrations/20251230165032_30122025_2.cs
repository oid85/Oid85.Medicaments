using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oid85.Medicaments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _30122025_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PillIncrementEntities_PillEntities_PillEntityId",
                schema: "public",
                table: "PillIncrementEntities");

            migrationBuilder.RenameColumn(
                name: "PillEntityId",
                schema: "public",
                table: "PillIncrementEntities",
                newName: "PillId");

            migrationBuilder.RenameIndex(
                name: "IX_PillIncrementEntities_PillEntityId",
                schema: "public",
                table: "PillIncrementEntities",
                newName: "IX_PillIncrementEntities_PillId");

            migrationBuilder.AddForeignKey(
                name: "FK_PillIncrementEntities_PillEntities_PillId",
                schema: "public",
                table: "PillIncrementEntities",
                column: "PillId",
                principalSchema: "public",
                principalTable: "PillEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PillIncrementEntities_PillEntities_PillId",
                schema: "public",
                table: "PillIncrementEntities");

            migrationBuilder.RenameColumn(
                name: "PillId",
                schema: "public",
                table: "PillIncrementEntities",
                newName: "PillEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_PillIncrementEntities_PillId",
                schema: "public",
                table: "PillIncrementEntities",
                newName: "IX_PillIncrementEntities_PillEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PillIncrementEntities_PillEntities_PillEntityId",
                schema: "public",
                table: "PillIncrementEntities",
                column: "PillEntityId",
                principalSchema: "public",
                principalTable: "PillEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
