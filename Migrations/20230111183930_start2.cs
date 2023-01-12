using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projekt.Migrations
{
    /// <inheritdoc />
    public partial class start2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gatuenk = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fisheries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OkregId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fisheries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fisheries_Districts_OkregId",
                        column: x => x.OkregId,
                        principalTable: "Districts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dataz = table.Column<DateTime>(name: "Data_z", type: "datetime2", nullable: true),
                    Waga = table.Column<float>(type: "real", nullable: true),
                    Rozmiar = table.Column<int>(type: "int", nullable: true),
                    GatunekId = table.Column<int>(type: "int", nullable: true),
                    ZbiornikId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fish_Fisheries_ZbiornikId",
                        column: x => x.ZbiornikId,
                        principalTable: "Fisheries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fish_Species_GatunekId",
                        column: x => x.GatunekId,
                        principalTable: "Species",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FisherySpecie",
                columns: table => new
                {
                    GatunekId = table.Column<int>(type: "int", nullable: false),
                    ZbiornikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FisherySpecie", x => new { x.GatunekId, x.ZbiornikId });
                    table.ForeignKey(
                        name: "FK_FisherySpecie_Fisheries_ZbiornikId",
                        column: x => x.ZbiornikId,
                        principalTable: "Fisheries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FisherySpecie_Species_GatunekId",
                        column: x => x.GatunekId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fish_GatunekId",
                table: "Fish",
                column: "GatunekId");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_ZbiornikId",
                table: "Fish",
                column: "ZbiornikId");

            migrationBuilder.CreateIndex(
                name: "IX_Fisheries_OkregId",
                table: "Fisheries",
                column: "OkregId");

            migrationBuilder.CreateIndex(
                name: "IX_FisherySpecie_ZbiornikId",
                table: "FisherySpecie",
                column: "ZbiornikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fish");

            migrationBuilder.DropTable(
                name: "FisherySpecie");

            migrationBuilder.DropTable(
                name: "Fisheries");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Districts");
        }
    }
}
