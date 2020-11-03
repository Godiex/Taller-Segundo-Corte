using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InicialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donaciones",
                columns: table => new
                {
                    DonacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modalidad = table.Column<string>(maxLength: 15, nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ValorDonacion = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donaciones", x => x.DonacionId);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Identificacion = table.Column<string>(maxLength: 10, nullable: false),
                    Nombres = table.Column<string>(maxLength: 45, nullable: true),
                    Apellidos = table.Column<string>(maxLength: 45, nullable: true),
                    Sexo = table.Column<string>(maxLength: 16, nullable: true),
                    Ciudad = table.Column<string>(maxLength: 16, nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    DonacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Identificacion);
                    table.ForeignKey(
                        name: "FK_Personas_Donaciones_DonacionId",
                        column: x => x.DonacionId,
                        principalTable: "Donaciones",
                        principalColumn: "DonacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_DonacionId",
                table: "Personas",
                column: "DonacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Donaciones");
        }
    }
}
