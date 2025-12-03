using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace webProject.Migrations
{
    /// <inheritdoc />
    public partial class ilkmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Antrenorlar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    Soyad = table.Column<string>(type: "text", nullable: false),
                    UzmanlıkAlanı = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antrenorlar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hizmetler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    SureDaikia = table.Column<int>(type: "integer", nullable: false),
                    Fiyat = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hizmetler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Salonlar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CalismaSaatleri = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salonlar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Uyeler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    Soyad = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Sifre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uyeler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AtrMusaitlikler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AntID = table.Column<int>(type: "integer", nullable: false),
                    Gun = table.Column<string>(type: "text", nullable: false),
                    BaslangicSaat = table.Column<TimeSpan>(type: "interval", nullable: false),
                    BitisSaat = table.Column<TimeSpan>(type: "interval", nullable: false),
                    AntrenorID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtrMusaitlikler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AtrMusaitlikler_Antrenorlar_AntrenorID",
                        column: x => x.AntrenorID,
                        principalTable: "Antrenorlar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtrHizmetler",
                columns: table => new
                {
                    AntID = table.Column<int>(type: "integer", nullable: false),
                    HizID = table.Column<int>(type: "integer", nullable: false),
                    AntrenorID = table.Column<int>(type: "integer", nullable: false),
                    HizmetID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtrHizmetler", x => new { x.AntID, x.HizID });
                    table.ForeignKey(
                        name: "FK_AtrHizmetler_Antrenorlar_AntrenorID",
                        column: x => x.AntrenorID,
                        principalTable: "Antrenorlar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtrHizmetler_Hizmetler_HizmetID",
                        column: x => x.HizmetID,
                        principalTable: "Hizmetler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HizSalonlar",
                columns: table => new
                {
                    HizID = table.Column<int>(type: "integer", nullable: false),
                    SalID = table.Column<int>(type: "integer", nullable: false),
                    Fiyat = table.Column<decimal>(type: "numeric", nullable: false),
                    Sure = table.Column<int>(type: "integer", nullable: false),
                    HizmetID = table.Column<int>(type: "integer", nullable: false),
                    SalonID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HizSalonlar", x => new { x.HizID, x.SalID });
                    table.ForeignKey(
                        name: "FK_HizSalonlar_Hizmetler_HizmetID",
                        column: x => x.HizmetID,
                        principalTable: "Hizmetler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HizSalonlar_Salonlar_SalonID",
                        column: x => x.SalonID,
                        principalTable: "Salonlar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Randevular",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UyeID = table.Column<int>(type: "integer", nullable: false),
                    AtrenorID = table.Column<int>(type: "integer", nullable: false),
                    HizmetID = table.Column<int>(type: "integer", nullable: false),
                    salonID = table.Column<int>(type: "integer", nullable: false),
                    Ucret = table.Column<decimal>(type: "numeric", nullable: false),
                    RandevuTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OnayDurumu = table.Column<bool>(type: "boolean", nullable: false),
                    BaslangicSaat = table.Column<TimeSpan>(type: "interval", nullable: false),
                    BitisSaat = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevular", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Randevular_Antrenorlar_AtrenorID",
                        column: x => x.AtrenorID,
                        principalTable: "Antrenorlar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Hizmetler_HizmetID",
                        column: x => x.HizmetID,
                        principalTable: "Hizmetler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Salonlar_salonID",
                        column: x => x.salonID,
                        principalTable: "Salonlar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Uyeler_UyeID",
                        column: x => x.UyeID,
                        principalTable: "Uyeler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtrHizmetler_AntrenorID",
                table: "AtrHizmetler",
                column: "AntrenorID");

            migrationBuilder.CreateIndex(
                name: "IX_AtrHizmetler_HizmetID",
                table: "AtrHizmetler",
                column: "HizmetID");

            migrationBuilder.CreateIndex(
                name: "IX_AtrMusaitlikler_AntrenorID",
                table: "AtrMusaitlikler",
                column: "AntrenorID");

            migrationBuilder.CreateIndex(
                name: "IX_HizSalonlar_HizmetID",
                table: "HizSalonlar",
                column: "HizmetID");

            migrationBuilder.CreateIndex(
                name: "IX_HizSalonlar_SalonID",
                table: "HizSalonlar",
                column: "SalonID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_AtrenorID",
                table: "Randevular",
                column: "AtrenorID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_HizmetID",
                table: "Randevular",
                column: "HizmetID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_salonID",
                table: "Randevular",
                column: "salonID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_UyeID",
                table: "Randevular",
                column: "UyeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtrHizmetler");

            migrationBuilder.DropTable(
                name: "AtrMusaitlikler");

            migrationBuilder.DropTable(
                name: "HizSalonlar");

            migrationBuilder.DropTable(
                name: "Randevular");

            migrationBuilder.DropTable(
                name: "Antrenorlar");

            migrationBuilder.DropTable(
                name: "Hizmetler");

            migrationBuilder.DropTable(
                name: "Salonlar");

            migrationBuilder.DropTable(
                name: "Uyeler");
        }
    }
}
