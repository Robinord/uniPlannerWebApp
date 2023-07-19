using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace uniPlanner.Migrations
{
    /// <inheritdoc />
    public partial class rankScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "UniProgrammes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RankScore",
                table: "UniProgrammes",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "UniProgrammes");

            migrationBuilder.DropColumn(
                name: "RankScore",
                table: "UniProgrammes");
        }
    }
}
