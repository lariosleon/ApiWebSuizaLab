using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    Idespecialidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.Idespecialidad);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                columns: table => new
                {
                    Idtipodocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.Idtipodocumento);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Idpaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idtipodocumento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Idpaciente);
                    table.ForeignKey(
                        name: "FK_Paciente_TipoDocumento_Idtipodocumento",
                        column: x => x.Idtipodocumento,
                        principalTable: "TipoDocumento",
                        principalColumn: "Idtipodocumento");
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Idcita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idpaciente = table.Column<int>(type: "int", nullable: true),
                    Idespecialidad = table.Column<int>(type: "int", nullable: true),
                    Fechacita = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Idcita);
                    table.ForeignKey(
                        name: "FK_Citas_Especialidad_Idespecialidad",
                        column: x => x.Idespecialidad,
                        principalTable: "Especialidad",
                        principalColumn: "Idespecialidad");
                    table.ForeignKey(
                        name: "FK_Citas_Paciente_Idpaciente",
                        column: x => x.Idpaciente,
                        principalTable: "Paciente",
                        principalColumn: "Idpaciente");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Idespecialidad",
                table: "Citas",
                column: "Idespecialidad");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Idpaciente",
                table: "Citas",
                column: "Idpaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_Idtipodocumento",
                table: "Paciente",
                column: "Idtipodocumento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Especialidad");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "TipoDocumento");
        }
    }
}
