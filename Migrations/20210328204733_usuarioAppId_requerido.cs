using Microsoft.EntityFrameworkCore.Migrations;

namespace supervisor_agente.Migrations
{
    public partial class usuarioAppId_requerido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_AspNetUsers_usuarioAppId",
                table: "Actividades");

            migrationBuilder.AlterColumn<string>(
                name: "usuarioAppId",
                table: "Actividades",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_AspNetUsers_usuarioAppId",
                table: "Actividades",
                column: "usuarioAppId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_AspNetUsers_usuarioAppId",
                table: "Actividades");

            migrationBuilder.AlterColumn<string>(
                name: "usuarioAppId",
                table: "Actividades",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_AspNetUsers_usuarioAppId",
                table: "Actividades",
                column: "usuarioAppId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
