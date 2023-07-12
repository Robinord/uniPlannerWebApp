using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace uniPlanner.Migrations
{
    /// <inheritdoc />
    public partial class UniversityModelsCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniProgrammes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniProgrammes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Programmes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniProgrammesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programmes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Programmes_UniProgrammes_UniProgrammesID",
                        column: x => x.UniProgrammesID,
                        principalTable: "UniProgrammes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UniversityInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    THErank = table.Column<int>(type: "int", nullable: false),
                    QSrank = table.Column<int>(type: "int", nullable: false),
                    ARWUrank = table.Column<int>(type: "int", nullable: false),
                    UniProgrammesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UniversityInfo_UniProgrammes_UniProgrammesID",
                        column: x => x.UniProgrammesID,
                        principalTable: "UniProgrammes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programmes_UniProgrammesID",
                table: "Programmes",
                column: "UniProgrammesID");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityInfo_UniProgrammesID",
                table: "UniversityInfo",
                column: "UniProgrammesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programmes");

            migrationBuilder.DropTable(
                name: "UniversityInfo");

            migrationBuilder.DropTable(
                name: "UniProgrammes");
        }
    }
}
