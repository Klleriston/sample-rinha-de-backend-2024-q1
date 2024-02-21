using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rinha.Migrations
{
    /// <inheritdoc />
    public partial class caralhovsf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Saldos_SaldoId",
                table: "Transacoes");

            migrationBuilder.RenameColumn(
                name: "transacaoID",
                table: "Transacoes",
                newName: "TransacaoID");

            migrationBuilder.RenameColumn(
                name: "limite",
                table: "Saldos",
                newName: "Limite");

            migrationBuilder.AlterColumn<int>(
                name: "SaldoId",
                table: "Transacoes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Saldos_SaldoId",
                table: "Transacoes",
                column: "SaldoId",
                principalTable: "Saldos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Saldos_SaldoId",
                table: "Transacoes");

            migrationBuilder.RenameColumn(
                name: "TransacaoID",
                table: "Transacoes",
                newName: "transacaoID");

            migrationBuilder.RenameColumn(
                name: "Limite",
                table: "Saldos",
                newName: "limite");

            migrationBuilder.AlterColumn<int>(
                name: "SaldoId",
                table: "Transacoes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Saldos_SaldoId",
                table: "Transacoes",
                column: "SaldoId",
                principalTable: "Saldos",
                principalColumn: "Id");
        }
    }
}
