using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeoApp.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_medico = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_paciente = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaciente = table.Column<int>(type: "int", nullable: true),
                    idMedico = table.Column<int>(type: "int", nullable: true),
                    dataConsulta = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.id);
                    table.ForeignKey(
                        name: "FK_Consulta_Medico",
                        column: x => x.idMedico,
                        principalTable: "Medico",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Consulta_Paciente",
                        column: x => x.idPaciente,
                        principalTable: "Paciente",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_idMedico",
                table: "Consulta",
                column: "idMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_idPaciente",
                table: "Consulta",
                column: "idPaciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
