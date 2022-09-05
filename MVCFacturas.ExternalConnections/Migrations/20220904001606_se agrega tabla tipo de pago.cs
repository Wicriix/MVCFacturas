using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCFacturas.ExternalConnections.Migrations
{
    public partial class seagregatablatipodepago : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposDePagos",
                columns: table => new
                {
                    IdTipoDePago = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipodePago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDePagos", x => x.IdTipoDePago);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiposDePagos");
        }
    }
}
