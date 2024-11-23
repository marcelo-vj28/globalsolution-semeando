using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Semeando.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Level",
                columns: table => new
                {
                    id_level = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dificuldade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Level", x => x.id_level);
                });

            migrationBuilder.CreateTable(
                name: "tb_Usuario",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_usuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ranking = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Usuario", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "tb_Pergunta",
                columns: table => new
                {
                    id_pergunta = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    id_level = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    texto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    tipo_pergunta = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Pergunta", x => x.id_pergunta);
                    table.ForeignKey(
                        name: "FK_tb_Pergunta_tb_Level_id_level",
                        column: x => x.id_level,
                        principalTable: "tb_Level",
                        principalColumn: "id_level",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "tb_Opcao",
                columns: table => new
                {
                    id_pergunta = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    id_opcao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    texto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    op_correta = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Opcao", x => new { x.id_opcao, x.id_pergunta });
                    table.ForeignKey(
                        name: "FK_tb_Opcao_tb_Pergunta_id_pergunta",
                        column: x => x.id_pergunta,
                        principalTable: "tb_Pergunta",
                        principalColumn: "id_pergunta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Resposta",
                columns: table => new
                {
                    id_resposta = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    id_pergunta = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    op_escolhida = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Resposta", x => x.id_resposta);
                    table.ForeignKey(
                        name: "FK_tb_Resposta_tb_Opcao_id_pergunta_op_escolhida",
                        columns: x => new { x.id_pergunta, x.op_escolhida },
                        principalTable: "tb_Opcao",
                        principalColumns: new[] { "id_opcao", "id_pergunta" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_Resposta_tb_Pergunta_id_pergunta",
                        column: x => x.id_pergunta,
                        principalTable: "tb_Pergunta",
                        principalColumn: "id_pergunta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_Resposta_tb_Usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "tb_Usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Opcao_id_pergunta",
                table: "tb_Opcao",
                column: "id_pergunta");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Pergunta_id_level",
                table: "tb_Pergunta",
                column: "id_level");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Resposta_id_pergunta_op_escolhida",
                table: "tb_Resposta",
                columns: new[] { "id_pergunta", "op_escolhida" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Resposta_id_usuario",
                table: "tb_Resposta",
                column: "id_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Resposta");

            migrationBuilder.DropTable(
                name: "tb_Opcao");

            migrationBuilder.DropTable(
                name: "tb_Usuario");

            migrationBuilder.DropTable(
                name: "tb_Pergunta");

            migrationBuilder.DropTable(
                name: "tb_Level");
        }
    }
}
