using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace supervisor_agente.Migrations
{
    public partial class actividad_clave_primaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Actividades",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "correlativo",
                table: "Actividades");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Actividades",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actividades",
                table: "Actividades",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_asuntoId",
                table: "Actividades",
                column: "asuntoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Actividades",
                table: "Actividades");

            migrationBuilder.DropIndex(
                name: "IX_Actividades_asuntoId",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Actividades");

            migrationBuilder.AddColumn<int>(
                name: "correlativo",
                table: "Actividades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actividades",
                table: "Actividades",
                columns: new[] { "asuntoId", "correlativo" });
        }
    }
}
