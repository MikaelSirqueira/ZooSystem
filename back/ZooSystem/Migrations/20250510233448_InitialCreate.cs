using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZooSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Especie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Habitat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisOrigem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuidados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequencia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuidados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimaisCuidados",
                columns: table => new
                {
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CuidadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimaisCuidados", x => new { x.AnimalId, x.CuidadoId });
                    table.ForeignKey(
                        name: "FK_AnimaisCuidados_Animais_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimaisCuidados_Cuidados_CuidadoId",
                        column: x => x.CuidadoId,
                        principalTable: "Cuidados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Animais",
                columns: new[] { "Id", "DataNascimento", "Descricao", "Especie", "Habitat", "Nome", "PaisOrigem" },
                values: new object[,]
                {
                    { new Guid("94620ad4-a804-4489-9fb5-bda950ddfaff"), new DateTime(2017, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Girafa macho adulto", "Giraffa camelopardalis", "Savana", "Girafa", "Quênia" },
                    { new Guid("95bf54a5-f2d7-4d9f-a858-b1eb8a3731f2"), new DateTime(2015, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leão africano", "Panthera leo", "Savana", "Leão", "África do Sul" }
                });

            migrationBuilder.InsertData(
                table: "Cuidados",
                columns: new[] { "Id", "Descricao", "Frequencia", "Nome" },
                values: new object[,]
                {
                    { new Guid("1a5349ad-5240-4c7f-a9b7-e497bcb99aac"), "Aplicação de vacinas", "Anual", "Vacinação" },
                    { new Guid("6221bd98-d3a6-4a56-b98a-46613606c964"), "Fornecimento de alimento", "Diária", "Alimentação" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimaisCuidados_CuidadoId",
                table: "AnimaisCuidados",
                column: "CuidadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimaisCuidados");

            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "Cuidados");
        }
    }
}
