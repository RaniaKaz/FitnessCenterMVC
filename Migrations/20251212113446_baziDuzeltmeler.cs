using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webProject.Migrations
{
    /// <inheritdoc />
    public partial class baziDuzeltmeler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtrHizmet_Antrenor_AntrenorID",
                table: "AtrHizmet");

            migrationBuilder.DropForeignKey(
                name: "FK_AtrHizmet_Hizmet_HizmetID",
                table: "AtrHizmet");

            migrationBuilder.DropForeignKey(
                name: "FK_AtrMusaitlik_Antrenor_AntrenorID",
                table: "AtrMusaitlik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtrMusaitlik",
                table: "AtrMusaitlik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtrHizmet",
                table: "AtrHizmet");

            migrationBuilder.RenameTable(
                name: "AtrMusaitlik",
                newName: "AntMusaitlik");

            migrationBuilder.RenameTable(
                name: "AtrHizmet",
                newName: "AntHizmet");

            migrationBuilder.RenameIndex(
                name: "IX_AtrMusaitlik_AntrenorID",
                table: "AntMusaitlik",
                newName: "IX_AntMusaitlik_AntrenorID");

            migrationBuilder.RenameIndex(
                name: "IX_AtrHizmet_HizmetID",
                table: "AntHizmet",
                newName: "IX_AntHizmet_HizmetID");

            migrationBuilder.RenameIndex(
                name: "IX_AtrHizmet_AntrenorID",
                table: "AntHizmet",
                newName: "IX_AntHizmet_AntrenorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AntMusaitlik",
                table: "AntMusaitlik",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AntHizmet",
                table: "AntHizmet",
                columns: new[] { "AntID", "HizID" });

            migrationBuilder.AddForeignKey(
                name: "FK_AntHizmet_Antrenor_AntrenorID",
                table: "AntHizmet",
                column: "AntrenorID",
                principalTable: "Antrenor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AntHizmet_Hizmet_HizmetID",
                table: "AntHizmet",
                column: "HizmetID",
                principalTable: "Hizmet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AntMusaitlik_Antrenor_AntrenorID",
                table: "AntMusaitlik",
                column: "AntrenorID",
                principalTable: "Antrenor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AntHizmet_Antrenor_AntrenorID",
                table: "AntHizmet");

            migrationBuilder.DropForeignKey(
                name: "FK_AntHizmet_Hizmet_HizmetID",
                table: "AntHizmet");

            migrationBuilder.DropForeignKey(
                name: "FK_AntMusaitlik_Antrenor_AntrenorID",
                table: "AntMusaitlik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AntMusaitlik",
                table: "AntMusaitlik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AntHizmet",
                table: "AntHizmet");

            migrationBuilder.RenameTable(
                name: "AntMusaitlik",
                newName: "AtrMusaitlik");

            migrationBuilder.RenameTable(
                name: "AntHizmet",
                newName: "AtrHizmet");

            migrationBuilder.RenameIndex(
                name: "IX_AntMusaitlik_AntrenorID",
                table: "AtrMusaitlik",
                newName: "IX_AtrMusaitlik_AntrenorID");

            migrationBuilder.RenameIndex(
                name: "IX_AntHizmet_HizmetID",
                table: "AtrHizmet",
                newName: "IX_AtrHizmet_HizmetID");

            migrationBuilder.RenameIndex(
                name: "IX_AntHizmet_AntrenorID",
                table: "AtrHizmet",
                newName: "IX_AtrHizmet_AntrenorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtrMusaitlik",
                table: "AtrMusaitlik",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtrHizmet",
                table: "AtrHizmet",
                columns: new[] { "AntID", "HizID" });

            migrationBuilder.AddForeignKey(
                name: "FK_AtrHizmet_Antrenor_AntrenorID",
                table: "AtrHizmet",
                column: "AntrenorID",
                principalTable: "Antrenor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtrHizmet_Hizmet_HizmetID",
                table: "AtrHizmet",
                column: "HizmetID",
                principalTable: "Hizmet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtrMusaitlik_Antrenor_AntrenorID",
                table: "AtrMusaitlik",
                column: "AntrenorID",
                principalTable: "Antrenor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
