using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estudos.Data.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contato_cliente_IdCliente",
                table: "contato");

            migrationBuilder.DropForeignKey(
                name: "FK_endereco_cliente_id_cliente",
                table: "endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuario",
                table: "usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_endereco",
                table: "endereco");

            migrationBuilder.DropIndex(
                name: "IX_endereco_id_cliente",
                table: "endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contato",
                table: "contato");

            migrationBuilder.DropIndex(
                name: "IX_contato_IdCliente",
                table: "contato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cliente",
                table: "cliente");

            migrationBuilder.RenameTable(
                name: "usuario",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "endereco",
                newName: "Endereco");

            migrationBuilder.RenameTable(
                name: "contato",
                newName: "Contato");

            migrationBuilder.RenameTable(
                name: "cliente",
                newName: "Cliente");

            migrationBuilder.RenameColumn(
                name: "usuario",
                table: "Usuario",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Usuario",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Usuario",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "enum_perfil",
                table: "Usuario",
                newName: "Perfil");

            migrationBuilder.RenameColumn(
                name: "tipo",
                table: "Endereco",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "referencia",
                table: "Endereco",
                newName: "Referencia");

            migrationBuilder.RenameColumn(
                name: "numero",
                table: "Endereco",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "logradouro",
                table: "Endereco",
                newName: "Logradouro");

            migrationBuilder.RenameColumn(
                name: "estado",
                table: "Endereco",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "complemento",
                table: "Endereco",
                newName: "Complemento");

            migrationBuilder.RenameColumn(
                name: "cidade",
                table: "Endereco",
                newName: "Cidade");

            migrationBuilder.RenameColumn(
                name: "cep",
                table: "Endereco",
                newName: "CEP");

            migrationBuilder.RenameColumn(
                name: "bairro",
                table: "Endereco",
                newName: "Bairro");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Endereco",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id_cliente",
                table: "Endereco",
                newName: "IdCliente");

            migrationBuilder.RenameColumn(
                name: "tipo",
                table: "Contato",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "telefone",
                table: "Contato",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "ddd",
                table: "Contato",
                newName: "DDD");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Contato",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "rg",
                table: "Cliente",
                newName: "RG");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Cliente",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Cliente",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "Cliente",
                newName: "CPF");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Cliente",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Contato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Cliente",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contato",
                table: "Contato",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contato_ClienteId",
                table: "Contato",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EnderecoId",
                table: "Cliente",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Endereco_EnderecoId",
                table: "Cliente",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Cliente_ClienteId",
                table: "Contato",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Endereco_EnderecoId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Cliente_ClienteId",
                table: "Contato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contato",
                table: "Contato");

            migrationBuilder.DropIndex(
                name: "IX_Contato_ClienteId",
                table: "Contato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_EnderecoId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "usuario");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "endereco");

            migrationBuilder.RenameTable(
                name: "Contato",
                newName: "contato");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "cliente");

            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "usuario",
                newName: "usuario");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "usuario",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "usuario",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Perfil",
                table: "usuario",
                newName: "enum_perfil");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "endereco",
                newName: "tipo");

            migrationBuilder.RenameColumn(
                name: "Referencia",
                table: "endereco",
                newName: "referencia");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "endereco",
                newName: "numero");

            migrationBuilder.RenameColumn(
                name: "Logradouro",
                table: "endereco",
                newName: "logradouro");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "endereco",
                newName: "estado");

            migrationBuilder.RenameColumn(
                name: "Complemento",
                table: "endereco",
                newName: "complemento");

            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "endereco",
                newName: "cidade");

            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "endereco",
                newName: "cep");

            migrationBuilder.RenameColumn(
                name: "Bairro",
                table: "endereco",
                newName: "bairro");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "endereco",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "endereco",
                newName: "id_cliente");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "contato",
                newName: "tipo");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "contato",
                newName: "telefone");

            migrationBuilder.RenameColumn(
                name: "DDD",
                table: "contato",
                newName: "ddd");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "contato",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RG",
                table: "cliente",
                newName: "rg");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "cliente",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "cliente",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "cliente",
                newName: "cpf");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cliente",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuario",
                table: "usuario",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_endereco",
                table: "endereco",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contato",
                table: "contato",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cliente",
                table: "cliente",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_endereco_id_cliente",
                table: "endereco",
                column: "id_cliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contato_IdCliente",
                table: "contato",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_contato_cliente_IdCliente",
                table: "contato",
                column: "IdCliente",
                principalTable: "cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_endereco_cliente_id_cliente",
                table: "endereco",
                column: "id_cliente",
                principalTable: "cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
