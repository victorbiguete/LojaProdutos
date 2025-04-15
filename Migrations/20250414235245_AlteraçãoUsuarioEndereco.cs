using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaProdutos.Migrations
{
    /// <inheritdoc />
    public partial class AlteraçãoUsuarioEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EderecoModelId",
                table: "Usuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EderecoModelId",
                table: "Usuarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
