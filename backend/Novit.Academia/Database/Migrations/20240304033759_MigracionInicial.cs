using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Novit.Academia.Database.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(type: "TEXT", nullable: false),
                    Barrio = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    UrlImagen = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cliente = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IdProducto = table.Column<int>(type: "INTEGER", nullable: false),
                    EstadoReserva = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reserva_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "IdProducto", "Barrio", "Codigo", "Estado", "Precio", "UrlImagen" },
                values: new object[,]
                {
                    { 1, "San Martin", "H3730BAN125", 0, 7200000m, null },
                    { 2, "Belgrano", "H3500BSN322", 0, 16500000m, null },
                    { 3, "Pellegrini", "H2575CPA777", 0, 14000000m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdProducto",
                table: "Reserva",
                column: "IdProducto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
