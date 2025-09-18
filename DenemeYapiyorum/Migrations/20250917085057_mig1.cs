using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenemeYapiyorum.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arabalar",
                columns: table => new
                {
                    ArabaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArabaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArabaRengi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArabaModeli = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arabalar", x => x.ArabaId);
                });

            migrationBuilder.CreateTable(
                name: "Kisiler",
                columns: table => new
                {
                    KisiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KisiAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KisiSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KisiTc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler", x => x.KisiId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arabalar");

            migrationBuilder.DropTable(
                name: "Kisiler");
        }
    }
}
