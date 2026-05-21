using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstoque.Migrations
{
    /// <inheritdoc />
    public partial class MotivosMigrations1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "dtCriacao",
                table: "cadMotivos",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            // 1. Força a conversão da coluna usando o comando nativo do PostgreSQL
            migrationBuilder.Sql("ALTER TABLE \"cadMotivos\" ALTER COLUMN cancelado TYPE boolean USING cancelado::boolean;");

            // 2. Define que a coluna agora aceita valores nulos (nullable: true)
            migrationBuilder.Sql("ALTER TABLE \"cadMotivos\" ALTER COLUMN cancelado DROP NOT NULL;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "dtCriacao",
                table: "cadMotivos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "cancelado",
                table: "cadMotivos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);
        }
    }
}
