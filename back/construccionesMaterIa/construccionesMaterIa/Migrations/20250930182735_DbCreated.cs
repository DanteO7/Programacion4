using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace construccionesMaterIa.Migrations
{
    /// <inheritdoc />
    public partial class DbCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Camiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isInRecorrido = table.Column<bool>(type: "bit", nullable: false),
                    Materiales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Travellers = table.Column<int>(type: "int", nullable: false),
                    Salida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Entrada = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camiones", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Camiones");
        }
    }
}
