using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleDeEstoque.Migrations
{
    /// <inheritdoc />
    public partial class MovimentacaoEstoque2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cadMovimentacaoEstoque",
                columns: table => new
                {
                    cdMovimentacaoEstoque = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tpMovimentacao = table.Column<string>(type: "text", nullable: false),
                    cdProduto = table.Column<int>(type: "integer", nullable: false),
                    ProdutocdProduto = table.Column<int>(type: "integer", nullable: false),
                    cdMotivo = table.Column<int>(type: "integer", nullable: false),
                    MotivocdMotivo = table.Column<int>(type: "integer", nullable: false),
                    qtMovimentacao = table.Column<decimal>(type: "numeric", nullable: false),
                    vlUnitario = table.Column<decimal>(type: "numeric", nullable: true),
                    vlTotal = table.Column<decimal>(type: "numeric", nullable: true),
                    qtSaldoFinal = table.Column<decimal>(type: "numeric", nullable: true),
                    dsObservacao = table.Column<string>(type: "text", nullable: false),
                    dtMovimentacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dtAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    cancelado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cadMovimentacaoEstoque", x => x.cdMovimentacaoEstoque);
                    table.ForeignKey(
                        name: "FK_cadMovimentacaoEstoque_cadMotivos_MotivocdMotivo",
                        column: x => x.MotivocdMotivo,
                        principalTable: "cadMotivos",
                        principalColumn: "cdMotivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cadMovimentacaoEstoque_cadProdutos_ProdutocdProduto",
                        column: x => x.ProdutocdProduto,
                        principalTable: "cadProdutos",
                        principalColumn: "cdProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cadMovimentacaoEstoque_MotivocdMotivo",
                table: "cadMovimentacaoEstoque",
                column: "MotivocdMotivo");

            migrationBuilder.CreateIndex(
                name: "IX_cadMovimentacaoEstoque_ProdutocdProduto",
                table: "cadMovimentacaoEstoque",
                column: "ProdutocdProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cadMovimentacaoEstoque");
        }
    }
}
