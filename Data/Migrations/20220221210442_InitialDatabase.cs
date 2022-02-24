using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: false),
                    Logradouro = table.Column<string>(maxLength: 150, nullable: false),
                    Bairro = table.Column<string>(maxLength: 50, nullable: false),
                    Complemento = table.Column<string>(maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(maxLength: 50, nullable: false),
                    Estado = table.Column<string>(maxLength: 50, nullable: false),
                    CEP = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prestador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    IdEmpresa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestador_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdemServico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    NumeroOS = table.Column<string>(nullable: true),
                    IdContrato = table.Column<int>(nullable: false),
                    IdServico = table.Column<int>(nullable: false),
                    IdPrestador = table.Column<int>(nullable: false),
                    DataAbertura = table.Column<DateTime>(nullable: false),
                    DateExecucao = table.Column<DateTime>(nullable: false),
                    ValorServico = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Contrato_IdContrato",
                        column: x => x.IdContrato,
                        principalTable: "Contrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Prestador_IdPrestador",
                        column: x => x.IdPrestador,
                        principalTable: "Prestador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Servico_IdServico",
                        column: x => x.IdServico,
                        principalTable: "Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_CNPJ",
                table: "Contrato",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_IdContrato",
                table: "OrdemServico",
                column: "IdContrato");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_IdPrestador",
                table: "OrdemServico",
                column: "IdPrestador");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_IdServico",
                table: "OrdemServico",
                column: "IdServico");

            migrationBuilder.CreateIndex(
                name: "IX_Prestador_CPF",
                table: "Prestador",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prestador_IdEmpresa",
                table: "Prestador",
                column: "IdEmpresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdemServico");

            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "Prestador");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
