using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudSimples.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaoNome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Promocao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Promocao");
        }
    }
}
