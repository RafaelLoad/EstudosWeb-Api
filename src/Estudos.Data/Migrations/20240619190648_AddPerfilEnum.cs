using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estudos.Data.Migrations
{
    public partial class AddPerfilEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "enum_perfil",
                table: "cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "enum_perfil",
                table: "cliente");
        }
    }
}
