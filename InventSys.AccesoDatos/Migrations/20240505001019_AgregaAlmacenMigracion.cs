using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventSys.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregaAlmacenMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KAlmacenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Descrip = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KAlmacenes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KAlmacenes");
        }
    }
}
