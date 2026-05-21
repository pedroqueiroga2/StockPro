using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleDeEstoque.Migrations
{
    /// <inheritdoc />
    public partial class MotivosMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "cadProdutos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cadProdutos",
                table: "cadProdutos",
                column: "cdProduto");

            migrationBuilder.CreateTable(
                name: "cadMotivos",
                columns: table => new
                {
                    cdMotivo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nmMotivo = table.Column<string>(type: "text", nullable: false),
                    dsMotivo = table.Column<string>(type: "text", nullable: false),
                    dtCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cancelado = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cadMotivos", x => x.cdMotivo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cadMotivos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cadProdutos",
                table: "cadProdutos");

            migrationBuilder.RenameTable(
                name: "cadProdutos",
                newName: "Produtos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "cdProduto");
        }
    }
}
