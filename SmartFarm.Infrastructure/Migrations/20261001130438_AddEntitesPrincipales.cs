using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFarm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEntitesPrincipales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cultures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Variete = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParcelleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cultures_Parcelles_ParcelleId",
                        column: x => x.ParcelleId,
                        principalTable: "Parcelles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interventions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateIntervention = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParcelleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interventions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interventions_Parcelles_ParcelleId",
                        column: x => x.ParcelleId,
                        principalTable: "Parcelles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Irrigations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateIrrigation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VolumeEauLitres = table.Column<double>(type: "float", nullable: false),
                    Methode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParcelleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Irrigations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Irrigations_Parcelles_ParcelleId",
                        column: x => x.ParcelleId,
                        principalTable: "Parcelles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mesures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Humidite = table.Column<double>(type: "float", nullable: false),
                    DateMesure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParcelleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesures_Parcelles_ParcelleId",
                        column: x => x.ParcelleId,
                        principalTable: "Parcelles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plantations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatePlantation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRecoltePrevue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plantations_Cultures_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cultures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cultures_ParcelleId",
                table: "Cultures",
                column: "ParcelleId");

            migrationBuilder.CreateIndex(
                name: "IX_Interventions_ParcelleId",
                table: "Interventions",
                column: "ParcelleId");

            migrationBuilder.CreateIndex(
                name: "IX_Irrigations_ParcelleId",
                table: "Irrigations",
                column: "ParcelleId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesures_ParcelleId",
                table: "Mesures",
                column: "ParcelleId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantations_CultureId",
                table: "Plantations",
                column: "CultureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interventions");

            migrationBuilder.DropTable(
                name: "Irrigations");

            migrationBuilder.DropTable(
                name: "Mesures");

            migrationBuilder.DropTable(
                name: "Plantations");

            migrationBuilder.DropTable(
                name: "Cultures");
        }
    }
}
