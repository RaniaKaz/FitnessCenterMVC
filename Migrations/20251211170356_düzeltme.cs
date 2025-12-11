using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webProject.Migrations
{
    /// <inheritdoc />
    public partial class düzeltme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtrHizmetler_Antrenorlar_AntrenorID",
                table: "AtrHizmetler");

            migrationBuilder.DropForeignKey(
                name: "FK_AtrHizmetler_Hizmetler_HizmetID",
                table: "AtrHizmetler");

            migrationBuilder.DropForeignKey(
                name: "FK_AtrMusaitlikler_Antrenorlar_AntrenorID",
                table: "AtrMusaitlikler");

            migrationBuilder.DropForeignKey(
                name: "FK_HizSalonlar_Hizmetler_HizmetID",
                table: "HizSalonlar");

            migrationBuilder.DropForeignKey(
                name: "FK_HizSalonlar_Salonlar_SalonID",
                table: "HizSalonlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Antrenorlar_AtrenorID",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Hizmetler_HizmetID",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Salonlar_salonID",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Uyeler_UyeID",
                table: "Randevular");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Uyeler",
                table: "Uyeler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salonlar",
                table: "Salonlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Randevular",
                table: "Randevular");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HizSalonlar",
                table: "HizSalonlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hizmetler",
                table: "Hizmetler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtrMusaitlikler",
                table: "AtrMusaitlikler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtrHizmetler",
                table: "AtrHizmetler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Antrenorlar",
                table: "Antrenorlar");

            migrationBuilder.RenameTable(
                name: "Uyeler",
                newName: "Uye");

            migrationBuilder.RenameTable(
                name: "Salonlar",
                newName: "Salon");

            migrationBuilder.RenameTable(
                name: "Randevular",
                newName: "Randevu");

            migrationBuilder.RenameTable(
                name: "HizSalonlar",
                newName: "HizSalon");

            migrationBuilder.RenameTable(
                name: "Hizmetler",
                newName: "Hizmet");

            migrationBuilder.RenameTable(
                name: "AtrMusaitlikler",
                newName: "AtrMusaitlik");

            migrationBuilder.RenameTable(
                name: "AtrHizmetler",
                newName: "AtrHizmet");

            migrationBuilder.RenameTable(
                name: "Antrenorlar",
                newName: "Antrenor");

            migrationBuilder.RenameIndex(
                name: "IX_Randevular_UyeID",
                table: "Randevu",
                newName: "IX_Randevu_UyeID");

            migrationBuilder.RenameIndex(
                name: "IX_Randevular_salonID",
                table: "Randevu",
                newName: "IX_Randevu_salonID");

            migrationBuilder.RenameIndex(
                name: "IX_Randevular_HizmetID",
                table: "Randevu",
                newName: "IX_Randevu_HizmetID");

            migrationBuilder.RenameIndex(
                name: "IX_Randevular_AtrenorID",
                table: "Randevu",
                newName: "IX_Randevu_AtrenorID");

            migrationBuilder.RenameIndex(
                name: "IX_HizSalonlar_SalonID",
                table: "HizSalon",
                newName: "IX_HizSalon_SalonID");

            migrationBuilder.RenameIndex(
                name: "IX_HizSalonlar_HizmetID",
                table: "HizSalon",
                newName: "IX_HizSalon_HizmetID");

            migrationBuilder.RenameIndex(
                name: "IX_AtrMusaitlikler_AntrenorID",
                table: "AtrMusaitlik",
                newName: "IX_AtrMusaitlik_AntrenorID");

            migrationBuilder.RenameIndex(
                name: "IX_AtrHizmetler_HizmetID",
                table: "AtrHizmet",
                newName: "IX_AtrHizmet_HizmetID");

            migrationBuilder.RenameIndex(
                name: "IX_AtrHizmetler_AntrenorID",
                table: "AtrHizmet",
                newName: "IX_AtrHizmet_AntrenorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Uye",
                table: "Uye",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salon",
                table: "Salon",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Randevu",
                table: "Randevu",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HizSalon",
                table: "HizSalon",
                columns: new[] { "HizID", "SalID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hizmet",
                table: "Hizmet",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtrMusaitlik",
                table: "AtrMusaitlik",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtrHizmet",
                table: "AtrHizmet",
                columns: new[] { "AntID", "HizID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Antrenor",
                table: "Antrenor",
                column: "ID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_HizSalon_Hizmet_HizmetID",
                table: "HizSalon",
                column: "HizmetID",
                principalTable: "Hizmet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HizSalon_Salon_SalonID",
                table: "HizSalon",
                column: "SalonID",
                principalTable: "Salon",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevu_Antrenor_AtrenorID",
                table: "Randevu",
                column: "AtrenorID",
                principalTable: "Antrenor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevu_Hizmet_HizmetID",
                table: "Randevu",
                column: "HizmetID",
                principalTable: "Hizmet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevu_Salon_salonID",
                table: "Randevu",
                column: "salonID",
                principalTable: "Salon",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevu_Uye_UyeID",
                table: "Randevu",
                column: "UyeID",
                principalTable: "Uye",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_HizSalon_Hizmet_HizmetID",
                table: "HizSalon");

            migrationBuilder.DropForeignKey(
                name: "FK_HizSalon_Salon_SalonID",
                table: "HizSalon");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevu_Antrenor_AtrenorID",
                table: "Randevu");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevu_Hizmet_HizmetID",
                table: "Randevu");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevu_Salon_salonID",
                table: "Randevu");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevu_Uye_UyeID",
                table: "Randevu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Uye",
                table: "Uye");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salon",
                table: "Salon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Randevu",
                table: "Randevu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HizSalon",
                table: "HizSalon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hizmet",
                table: "Hizmet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtrMusaitlik",
                table: "AtrMusaitlik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtrHizmet",
                table: "AtrHizmet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Antrenor",
                table: "Antrenor");

            migrationBuilder.RenameTable(
                name: "Uye",
                newName: "Uyeler");

            migrationBuilder.RenameTable(
                name: "Salon",
                newName: "Salonlar");

            migrationBuilder.RenameTable(
                name: "Randevu",
                newName: "Randevular");

            migrationBuilder.RenameTable(
                name: "HizSalon",
                newName: "HizSalonlar");

            migrationBuilder.RenameTable(
                name: "Hizmet",
                newName: "Hizmetler");

            migrationBuilder.RenameTable(
                name: "AtrMusaitlik",
                newName: "AtrMusaitlikler");

            migrationBuilder.RenameTable(
                name: "AtrHizmet",
                newName: "AtrHizmetler");

            migrationBuilder.RenameTable(
                name: "Antrenor",
                newName: "Antrenorlar");

            migrationBuilder.RenameIndex(
                name: "IX_Randevu_UyeID",
                table: "Randevular",
                newName: "IX_Randevular_UyeID");

            migrationBuilder.RenameIndex(
                name: "IX_Randevu_salonID",
                table: "Randevular",
                newName: "IX_Randevular_salonID");

            migrationBuilder.RenameIndex(
                name: "IX_Randevu_HizmetID",
                table: "Randevular",
                newName: "IX_Randevular_HizmetID");

            migrationBuilder.RenameIndex(
                name: "IX_Randevu_AtrenorID",
                table: "Randevular",
                newName: "IX_Randevular_AtrenorID");

            migrationBuilder.RenameIndex(
                name: "IX_HizSalon_SalonID",
                table: "HizSalonlar",
                newName: "IX_HizSalonlar_SalonID");

            migrationBuilder.RenameIndex(
                name: "IX_HizSalon_HizmetID",
                table: "HizSalonlar",
                newName: "IX_HizSalonlar_HizmetID");

            migrationBuilder.RenameIndex(
                name: "IX_AtrMusaitlik_AntrenorID",
                table: "AtrMusaitlikler",
                newName: "IX_AtrMusaitlikler_AntrenorID");

            migrationBuilder.RenameIndex(
                name: "IX_AtrHizmet_HizmetID",
                table: "AtrHizmetler",
                newName: "IX_AtrHizmetler_HizmetID");

            migrationBuilder.RenameIndex(
                name: "IX_AtrHizmet_AntrenorID",
                table: "AtrHizmetler",
                newName: "IX_AtrHizmetler_AntrenorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Uyeler",
                table: "Uyeler",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salonlar",
                table: "Salonlar",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Randevular",
                table: "Randevular",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HizSalonlar",
                table: "HizSalonlar",
                columns: new[] { "HizID", "SalID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hizmetler",
                table: "Hizmetler",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtrMusaitlikler",
                table: "AtrMusaitlikler",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtrHizmetler",
                table: "AtrHizmetler",
                columns: new[] { "AntID", "HizID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Antrenorlar",
                table: "Antrenorlar",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AtrHizmetler_Antrenorlar_AntrenorID",
                table: "AtrHizmetler",
                column: "AntrenorID",
                principalTable: "Antrenorlar",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtrHizmetler_Hizmetler_HizmetID",
                table: "AtrHizmetler",
                column: "HizmetID",
                principalTable: "Hizmetler",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtrMusaitlikler_Antrenorlar_AntrenorID",
                table: "AtrMusaitlikler",
                column: "AntrenorID",
                principalTable: "Antrenorlar",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HizSalonlar_Hizmetler_HizmetID",
                table: "HizSalonlar",
                column: "HizmetID",
                principalTable: "Hizmetler",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HizSalonlar_Salonlar_SalonID",
                table: "HizSalonlar",
                column: "SalonID",
                principalTable: "Salonlar",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Antrenorlar_AtrenorID",
                table: "Randevular",
                column: "AtrenorID",
                principalTable: "Antrenorlar",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Hizmetler_HizmetID",
                table: "Randevular",
                column: "HizmetID",
                principalTable: "Hizmetler",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Salonlar_salonID",
                table: "Randevular",
                column: "salonID",
                principalTable: "Salonlar",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Uyeler_UyeID",
                table: "Randevular",
                column: "UyeID",
                principalTable: "Uyeler",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
