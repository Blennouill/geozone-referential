using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoZoneReferential.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Wording = table.Column<string>(nullable: false),
                    ISO3166A2Code = table.Column<string>(nullable: false),
                    CountryOwnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Countries_CountryOwnerId",
                        column: x => x.CountryOwnerId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdministrativeLevelZones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Level = table.Column<byte>(nullable: false),
                    Wording = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativeLevelZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdministrativeLevelZones_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdministrativeZones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ISO3166A2Code = table.Column<string>(nullable: false),
                    ISO3166A2ParentCode = table.Column<string>(nullable: true),
                    Wording = table.Column<string>(nullable: false),
                    AdministrativeLevelZoneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativeZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdministrativeZones_AdministrativeLevelZones_AdministrativeLevelZoneId",
                        column: x => x.AdministrativeLevelZoneId,
                        principalTable: "AdministrativeLevelZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostalCode = table.Column<string>(nullable: true),
                    Wording = table.Column<string>(nullable: false),
                    WordingS42Standard = table.Column<string>(nullable: true),
                    ComplementaryWording = table.Column<string>(nullable: true),
                    LastReliabilitingDate = table.Column<DateTime>(nullable: true),
                    AdministrativeZoneId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_AdministrativeZones_AdministrativeZoneId",
                        column: x => x.AdministrativeZoneId,
                        principalTable: "AdministrativeZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministrativeLevelZones_CountryId",
                table: "AdministrativeLevelZones",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AdministrativeZones_AdministrativeLevelZoneId",
                table: "AdministrativeZones",
                column: "AdministrativeLevelZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_AdministrativeZoneId",
                table: "Cities",
                column: "AdministrativeZoneId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_WordingS42Standard",
                table: "Cities",
                column: "WordingS42Standard",
                unique: true,
                filter: "[WordingS42Standard] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_WordingS42Standard_PostalCode",
                table: "Cities",
                columns: new[] { "WordingS42Standard", "PostalCode" },
                unique: true,
                filter: "[WordingS42Standard] IS NOT NULL AND [PostalCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CountryOwnerId",
                table: "Countries",
                column: "CountryOwnerId",
                unique: true,
                filter: "[CountryOwnerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ISO3166A2Code",
                table: "Countries",
                column: "ISO3166A2Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Wording",
                table: "Countries",
                column: "Wording",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ISO3166A2Code_Wording",
                table: "Countries",
                columns: new[] { "ISO3166A2Code", "Wording" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "AdministrativeZones");

            migrationBuilder.DropTable(
                name: "AdministrativeLevelZones");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
