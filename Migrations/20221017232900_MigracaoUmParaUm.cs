using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    public partial class MigracaoUmParaUm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Jogador",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "Armas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonagemHabilidade",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonagemHabilidade", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidade_Habilidades_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "Habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidade_Personagens_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 47, "Adormecer" },
                    { 2, 34, "Congelar" },
                    { 3, 237, "Hipnotizar" }
                });

            migrationBuilder.InsertData(
                table: "PersonagemHabilidade",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Latitude", "Longitude", "PasswordHash", "PasswordSalt" },
                values: new object[] { "Admin@gamil.com", -23.520024100000001, -46.596497999999997, new byte[] { 14, 29, 44, 46, 124, 128, 181, 217, 138, 80, 125, 162, 130, 41, 18, 169, 141, 23, 253, 89, 101, 4, 171, 17, 19, 55, 175, 168, 237, 47, 215, 141, 29, 32, 59, 141, 139, 81, 231, 71, 179, 91, 159, 14, 144, 191, 122, 248, 70, 57, 21, 54, 82, 92, 218, 21, 130, 144, 60, 86, 161, 118, 38, 35 }, new byte[] { 185, 160, 250, 36, 95, 220, 209, 225, 240, 76, 236, 157, 57, 141, 148, 246, 187, 84, 180, 149, 150, 72, 134, 88, 187, 144, 208, 177, 71, 168, 167, 224, 49, 175, 143, 18, 200, 85, 28, 18, 107, 95, 196, 112, 233, 250, 177, 58, 68, 204, 140, 219, 228, 44, 248, 147, 127, 200, 72, 184, 92, 117, 246, 60, 67, 210, 57, 107, 102, 42, 33, 191, 24, 194, 111, 55, 8, 89, 123, 255, 91, 5, 246, 242, 157, 128, 73, 238, 46, 116, 142, 13, 154, 78, 29, 146, 78, 206, 23, 179, 112, 116, 13, 111, 131, 247, 72, 16, 124, 242, 143, 74, 173, 150, 206, 114, 238, 255, 204, 252, 194, 62, 22, 170, 217, 208, 192, 69 } });

            migrationBuilder.InsertData(
                table: "PersonagemHabilidade",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "PersonagemHabilidade",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "PersonagemHabilidade",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[] { 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonagemHabilidade_HabilidadeId",
                table: "PersonagemHabilidade",
                column: "HabilidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Armas_Personagens_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                principalTable: "Personagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armas_Personagens_PersonagemId",
                table: "Armas");

            migrationBuilder.DropTable(
                name: "PersonagemHabilidade");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "Armas");

            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Jogador");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Latitude", "Longitude", "PasswordHash", "PasswordSalt" },
                values: new object[] { null, null, null, new byte[] { 81, 111, 167, 194, 80, 67, 215, 65, 96, 165, 205, 146, 97, 87, 188, 146, 115, 86, 247, 225, 81, 102, 210, 117, 208, 29, 187, 108, 241, 249, 207, 161, 112, 79, 36, 241, 143, 170, 31, 134, 227, 253, 158, 104, 12, 23, 2, 60, 163, 59, 174, 209, 3, 177, 121, 136, 69, 80, 221, 158, 188, 226, 221, 92 }, new byte[] { 211, 79, 237, 150, 140, 36, 68, 4, 27, 180, 71, 192, 30, 99, 132, 150, 53, 130, 17, 93, 188, 162, 34, 79, 206, 212, 212, 139, 168, 197, 234, 79, 39, 163, 177, 111, 63, 102, 83, 88, 230, 190, 54, 151, 127, 189, 38, 158, 69, 159, 6, 176, 120, 68, 13, 161, 185, 187, 226, 194, 151, 156, 61, 55, 51, 157, 52, 216, 253, 185, 140, 11, 87, 22, 77, 128, 117, 220, 152, 253, 100, 109, 33, 244, 77, 169, 169, 202, 222, 42, 247, 254, 237, 211, 75, 147, 145, 194, 137, 126, 154, 162, 90, 223, 172, 171, 91, 47, 199, 140, 27, 107, 134, 64, 99, 162, 103, 71, 111, 60, 188, 161, 27, 60, 198, 15, 23, 225 } });
        }
    }
}
