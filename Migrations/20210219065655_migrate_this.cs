using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BabyTracker.Migrations
{
    public partial class migrate_this : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Infants",
                columns: table => new
                {
                    InfantId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infants", x => x.InfantId);
                });

            migrationBuilder.CreateTable(
                name: "Diapers",
                columns: table => new
                {
                    DiaperId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaperType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InfantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diapers", x => x.DiaperId);
                    table.ForeignKey(
                        name: "FK_Diapers_Infants_InfantId",
                        column: x => x.InfantId,
                        principalTable: "Infants",
                        principalColumn: "InfantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedings",
                columns: table => new
                {
                    FeedingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    Duration = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    InfantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedings", x => x.FeedingId);
                    table.ForeignKey(
                        name: "FK_Feedings_Infants_InfantId",
                        column: x => x.InfantId,
                        principalTable: "Infants",
                        principalColumn: "InfantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Growths",
                columns: table => new
                {
                    GrowthId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrowthType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InfantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Growths", x => x.GrowthId);
                    table.ForeignKey(
                        name: "FK_Growths_Infants_InfantId",
                        column: x => x.InfantId,
                        principalTable: "Infants",
                        principalColumn: "InfantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    MedicationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationType = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    InfantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.MedicationId);
                    table.ForeignKey(
                        name: "FK_Medications_Infants_InfantId",
                        column: x => x.InfantId,
                        principalTable: "Infants",
                        principalColumn: "InfantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sleeps",
                columns: table => new
                {
                    SleepId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    InfantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sleeps", x => x.SleepId);
                    table.ForeignKey(
                        name: "FK_Sleeps_Infants_InfantId",
                        column: x => x.InfantId,
                        principalTable: "Infants",
                        principalColumn: "InfantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diapers_InfantId",
                table: "Diapers",
                column: "InfantId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedings_InfantId",
                table: "Feedings",
                column: "InfantId");

            migrationBuilder.CreateIndex(
                name: "IX_Growths_InfantId",
                table: "Growths",
                column: "InfantId");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_InfantId",
                table: "Medications",
                column: "InfantId");

            migrationBuilder.CreateIndex(
                name: "IX_Sleeps_InfantId",
                table: "Sleeps",
                column: "InfantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diapers");

            migrationBuilder.DropTable(
                name: "Feedings");

            migrationBuilder.DropTable(
                name: "Growths");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Sleeps");

            migrationBuilder.DropTable(
                name: "Infants");
        }
    }
}
