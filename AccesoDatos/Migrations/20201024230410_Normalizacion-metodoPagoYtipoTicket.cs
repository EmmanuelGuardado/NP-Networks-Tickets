using Microsoft.EntityFrameworkCore.Migrations;

namespace AccesoDatos.Migrations
{
    public partial class NormalizacionmetodoPagoYtipoTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Ubicaciones_UbicacionId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Contactos_Clientes_ClienteId",
                table: "Contactos");

            migrationBuilder.DropIndex(
                name: "IX_Contactos_ClienteId",
                table: "Contactos");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_UbicacionId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Contactos");

            migrationBuilder.DropColumn(
                name: "UbicacionId",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "Cliente_id",
                table: "Contactos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Ubicacion_id",
                table: "Clientes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_Cliente_id",
                table: "Contactos",
                column: "Cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Ubicacion_id",
                table: "Clientes",
                column: "Ubicacion_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Ubicaciones_Ubicacion_id",
                table: "Clientes",
                column: "Ubicacion_id",
                principalTable: "Ubicaciones",
                principalColumn: "UbicacionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contactos_Clientes_Cliente_id",
                table: "Contactos",
                column: "Cliente_id",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Ubicaciones_Ubicacion_id",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Contactos_Clientes_Cliente_id",
                table: "Contactos");

            migrationBuilder.DropIndex(
                name: "IX_Contactos_Cliente_id",
                table: "Contactos");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_Ubicacion_id",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Cliente_id",
                table: "Contactos");

            migrationBuilder.DropColumn(
                name: "Ubicacion_id",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Contactos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UbicacionId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_ClienteId",
                table: "Contactos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UbicacionId",
                table: "Clientes",
                column: "UbicacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Ubicaciones_UbicacionId",
                table: "Clientes",
                column: "UbicacionId",
                principalTable: "Ubicaciones",
                principalColumn: "UbicacionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contactos_Clientes_ClienteId",
                table: "Contactos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
