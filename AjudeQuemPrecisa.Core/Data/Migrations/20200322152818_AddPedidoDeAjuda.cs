using Microsoft.EntityFrameworkCore.Migrations;

namespace AjudeQuemPrecisa.Core.Migrations
{
    public partial class AddPedidoDeAjuda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PedidosDeAjuda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: true),
                    FotoUrl = table.Column<string>(nullable: true),
                    TipoPessoa = table.Column<int>(nullable: false),
                    TipoAjuda = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    Cidade = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    WhatsApp = table.Column<string>(nullable: true),
                    WebsiteUrl = table.Column<string>(nullable: true),
                    FacebookUrl = table.Column<string>(nullable: true),
                    FinanciamentoColetivoUrl = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosDeAjuda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosDeAjuda_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDeAjuda_UsuarioId",
                table: "PedidosDeAjuda",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidosDeAjuda");
        }
    }
}
