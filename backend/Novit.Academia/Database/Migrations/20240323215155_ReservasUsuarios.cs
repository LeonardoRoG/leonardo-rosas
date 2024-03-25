using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Novit.Academia.Database.Migrations
{
    /// <inheritdoc />
    public partial class ReservasUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Usuario_UsuarioId",
                table: "Reserva");

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "Id",
                keyValue: new Guid("1b7d7225-d028-4a54-a528-154cd1202982"));

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "Id",
                keyValue: new Guid("ac425c31-4b9c-4a77-b35b-291bce295bcf"));

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "Id",
                keyValue: new Guid("fd824a8b-d90f-4afe-8c27-011740b081fd"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Reserva",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2bd9a8e3-973d-4485-ae8a-cd4224ed3bb7"), "vendedor" },
                    { new Guid("34cfab52-a3ed-4b0c-8ac4-d9613eb74315"), "comercial" },
                    { new Guid("f964cf0b-32c2-4bad-855c-70ea638b4776"), "administrador" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Usuario_UsuarioId",
                table: "Reserva",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Usuario_UsuarioId",
                table: "Reserva");

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "Id",
                keyValue: new Guid("2bd9a8e3-973d-4485-ae8a-cd4224ed3bb7"));

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "Id",
                keyValue: new Guid("34cfab52-a3ed-4b0c-8ac4-d9613eb74315"));

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "Id",
                keyValue: new Guid("f964cf0b-32c2-4bad-855c-70ea638b4776"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Reserva",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1b7d7225-d028-4a54-a528-154cd1202982"), "administrador" },
                    { new Guid("ac425c31-4b9c-4a77-b35b-291bce295bcf"), "vendedor" },
                    { new Guid("fd824a8b-d90f-4afe-8c27-011740b081fd"), "comercial" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Usuario_UsuarioId",
                table: "Reserva",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }
    }
}
