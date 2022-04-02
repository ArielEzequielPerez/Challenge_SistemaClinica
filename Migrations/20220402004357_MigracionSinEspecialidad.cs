using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemasClinica.Migrations
{
    public partial class MigracionSinEspecialidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professionals_Specialities_SpecialityId",
                table: "Professionals");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropIndex(
                name: "IX_Professionals_SpecialityId",
                table: "Professionals");

            migrationBuilder.DropColumn(
                name: "SpecialityId",
                table: "Professionals");

            migrationBuilder.AddColumn<string>(
                name: "Speciality",
                table: "Professionals",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "Professionals");

            migrationBuilder.AddColumn<int>(
                name: "SpecialityId",
                table: "Professionals",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_SpecialityId",
                table: "Professionals",
                column: "SpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professionals_Specialities_SpecialityId",
                table: "Professionals",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
