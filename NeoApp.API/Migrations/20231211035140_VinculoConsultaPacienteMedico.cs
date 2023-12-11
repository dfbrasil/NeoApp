using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeoApp.API.Migrations
{
    public partial class VinculoConsultaPacienteMedico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMedico",
                table: "Consulta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPaciente",
                table: "Consulta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdMedico",
                table: "Consulta",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdPaciente",
                table: "Consulta",
                column: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Medico_IdMedico",
                table: "Consulta",
                column: "IdMedico",
                principalTable: "Medico",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Paciente_IdPaciente",
                table: "Consulta",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Medico_IdMedico",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Paciente_IdPaciente",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_IdMedico",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_IdPaciente",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "IdMedico",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "IdPaciente",
                table: "Consulta");
        }
    }
}
