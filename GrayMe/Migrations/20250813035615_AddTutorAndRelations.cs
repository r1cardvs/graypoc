using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GrayMe.Migrations
{
    /// <inheritdoc />
    public partial class AddTutorAndRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tutores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Profissao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Observacao = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Instituicao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Usuario = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Senha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FotoBase64 = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tutores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "crianca_tutor",
                columns: table => new
                {
                    CriancaId = table.Column<int>(type: "integer", nullable: false),
                    TutorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crianca_tutor", x => new { x.CriancaId, x.TutorId });
                    table.ForeignKey(
                        name: "FK_CriancaTutor_CriancaId",
                        column: x => x.CriancaId,
                        principalTable: "criancas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CriancaTutor_TutorId",
                        column: x => x.TutorId,
                        principalTable: "tutores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_crianca_tutor_TutorId",
                table: "crianca_tutor",
                column: "TutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "crianca_tutor");

            migrationBuilder.DropTable(
                name: "tutores");
        }
    }
}
