using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estudos.Data.Migrations
{
    public partial class removeIdEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEndereco",
                table: "cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEndereco",
                table: "cliente",
                type: "int",
                nullable: true);
        }
    }
}
