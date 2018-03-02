using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MvcProyecto.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CedulaJuridica = table.Column<int>(nullable: false),
                    DireccionFisica = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    NumeroTelefono = table.Column<int>(nullable: false),
                    PaginaWeb = table.Column<string>(nullable: true),
                    Sector = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Apellido = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    TipoUsuario = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Apellidos = table.Column<string>(nullable: true),
                    ClienteId = table.Column<int>(nullable: false),
                    Correo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    NumeroTelefono = table.Column<int>(nullable: false),
                    Puesto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contacto_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReporteProblema",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(nullable: false),
                    DetalleProblema = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    QuienReporto = table.Column<string>(nullable: true),
                    TituloProblema = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReporteProblema", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReporteProblema_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reunion",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EsVirtual = table.Column<bool>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    TituloReunion = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reunion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reunion_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_ClienteId",
                table: "Contacto",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteProblema_ClienteId",
                table: "ReporteProblema",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reunion_UsuarioId",
                table: "Reunion",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropTable(
                name: "ReporteProblema");

            migrationBuilder.DropTable(
                name: "Reunion");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
