using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Migrations
{
    public partial class AddMiniaturesTableToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Miniatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    databaseReady = table.Column<bool>(type: "INTEGER", nullable: false),
                    Temp = table.Column<float>(type: "REAL", nullable: false),
                    Pressure = table.Column<int>(type: "INTEGER", nullable: false),
                    Humidity = table.Column<int>(type: "INTEGER", nullable: false),
                    TempMin = table.Column<float>(type: "REAL", nullable: false),
                    TempMax = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miniatures", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Miniatures");
        }
    }
}
