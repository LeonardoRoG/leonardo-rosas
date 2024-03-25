using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Novit.Academia.Database.Migrations
{
    /// <inheritdoc />
    public partial class PopulateRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Reserva",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1b7d7225-d028-4a54-a528-154cd1202982"), "administrador" },
                    { new Guid("ac425c31-4b9c-4a77-b35b-291bce295bcf"), "vendedor" },
                    { new Guid("fd824a8b-d90f-4afe-8c27-011740b081fd"), "comercial" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_UsuarioId",
                table: "Reserva",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Usuario_UsuarioId",
                table: "Reserva",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Usuario_UsuarioId",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_UsuarioId",
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

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Reserva");
        }
    }
}
