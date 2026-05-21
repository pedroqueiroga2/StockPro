using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstoque.Migrations
{
    /// <inheritdoc />
    public partial class MotivosMigrations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dtAlteracao",
                table: "cadMotivos",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dtAlteracao",
                table: "cadMotivos");
        }
    }
}
