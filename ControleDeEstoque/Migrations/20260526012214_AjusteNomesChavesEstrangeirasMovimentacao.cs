using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstoque.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNomesChavesEstrangeirasMovimentacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cadMovimentacaoEstoque_cadMotivos_MotivocdMotivo",
                table: "cadMovimentacaoEstoque");

            migrationBuilder.DropForeignKey(
                name: "FK_cadMovimentacaoEstoque_cadProdutos_ProdutocdProduto",
                table: "cadMovimentacaoEstoque");

            migrationBuilder.DropIndex(
                name: "IX_cadMovimentacaoEstoque_MotivocdMotivo",
                table: "cadMovimentacaoEstoque");

            migrationBuilder.DropIndex(
                name: "IX_cadMovimentacaoEstoque_ProdutocdProduto",
                table: "cadMovimentacaoEstoque");

            migrationBuilder.DropColumn(
                name: "MotivocdMotivo",
                table: "cadMovimentacaoEstoque");

            migrationBuilder.DropColumn(
                name: "ProdutocdProduto",
                table: "cadMovimentacaoEstoque");

            migrationBuilder.CreateIndex(
                name: "IX_cadMovimentacaoEstoque_cdMotivo",
                table: "cadMovimentacaoEstoque",
                column: "cdMotivo");

            migrationBuilder.CreateIndex(
                name: "IX_cadMovimentacaoEstoque_cdProduto",
                table: "cadMovimentacaoEstoque",
                column: "cdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_cadMovimentacaoEstoque_cadMotivos_cdMotivo",
                table: "cadMovimentacaoEstoque",
                column: "cdMotivo",
                principalTable: "cadMotivos",
                principalColumn: "cdMotivo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cadMovimentacaoEstoque_cadProdutos_cdProduto",
                table: "cadMovimentacaoEstoque",
                column: "cdProduto",
                principalTable: "cadProdutos",
                principalColumn: "cdProduto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cadMovimentacaoEstoque_cadMotivos_cdMotivo",
                table: "cadMovimentacaoEstoque");

            migrationBuilder.DropForeignKey(
                name: "FK_cadMovimentacaoEstoque_cadProdutos_cdProduto",
                table: "cadMovimentacaoEstoque");

            migrationBuilder.DropIndex(
                name: "IX_cadMovimentacaoEstoque_cdMotivo",
                table: "cadMovimentacaoEstoque");

            migrationBuilder.DropIndex(
                name: "IX_cadMovimentacaoEstoque_cdProduto",
                table: "cadMovimentacaoEstoque");

            migrationBuilder.AddColumn<int>(
                name: "MotivocdMotivo",
                table: "cadMovimentacaoEstoque",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdutocdProduto",
                table: "cadMovimentacaoEstoque",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_cadMovimentacaoEstoque_MotivocdMotivo",
                table: "cadMovimentacaoEstoque",
                column: "MotivocdMotivo");

            migrationBuilder.CreateIndex(
                name: "IX_cadMovimentacaoEstoque_ProdutocdProduto",
                table: "cadMovimentacaoEstoque",
                column: "ProdutocdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_cadMovimentacaoEstoque_cadMotivos_MotivocdMotivo",
                table: "cadMovimentacaoEstoque",
                column: "MotivocdMotivo",
                principalTable: "cadMotivos",
                principalColumn: "cdMotivo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cadMovimentacaoEstoque_cadProdutos_ProdutocdProduto",
                table: "cadMovimentacaoEstoque",
                column: "ProdutocdProduto",
                principalTable: "cadProdutos",
                principalColumn: "cdProduto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
