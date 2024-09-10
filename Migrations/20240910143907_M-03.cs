using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aula_api_fuel_manager.Migrations
{
    /// <inheritdoc />
    public partial class M03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LinkDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metodo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstabelecimentoId = table.Column<int>(type: "int", nullable: true),
                    ServicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkDto_Estabelecimentos_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LinkDto_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstabelecimentoUsuario",
                columns: table => new
                {
                    EstabelecimentoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EstabelecimentoId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabelecimentoUsuario", x => new { x.EstabelecimentoId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_EstabelecimentoUsuario_Estabelecimentos_EstabelecimentoId1",
                        column: x => x.EstabelecimentoId1,
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstabelecimentoUsuario_Usuarios_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentoUsuario_EstabelecimentoId1",
                table: "EstabelecimentoUsuario",
                column: "EstabelecimentoId1");

            migrationBuilder.CreateIndex(
                name: "IX_LinkDto_EstabelecimentoId",
                table: "LinkDto",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkDto_ServicoId",
                table: "LinkDto",
                column: "ServicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstabelecimentoUsuario");

            migrationBuilder.DropTable(
                name: "LinkDto");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
