using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemasClinica.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denominacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professionals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialityId = table.Column<int>(type: "int", nullable: false),
                    ConsultId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professionals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professionals_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRealitazion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfessionalId = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    CostMaterial = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consults_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consults_Professionals_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "Professionals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consults_PatientId",
                table: "Consults",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Consults_ProfessionalId",
                table: "Consults",
                column: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ConsultId",
                table: "Patients",
                column: "ConsultId");

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_ConsultId",
                table: "Professionals",
                column: "ConsultId");

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_SpecialityId",
                table: "Professionals",
                column: "SpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Consults_ConsultId",
                table: "Patients",
                column: "ConsultId",
                principalTable: "Consults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professionals_Consults_ConsultId",
                table: "Professionals",
                column: "ConsultId",
                principalTable: "Consults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consults_Patients_PatientId",
                table: "Consults");

            migrationBuilder.DropForeignKey(
                name: "FK_Consults_Professionals_ProfessionalId",
                table: "Consults");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Professionals");

            migrationBuilder.DropTable(
                name: "Consults");

            migrationBuilder.DropTable(
                name: "Specialities");
        }
    }
}
