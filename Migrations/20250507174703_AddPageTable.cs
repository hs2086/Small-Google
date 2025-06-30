using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigDataProject.Migrations
{
    /// <inheritdoc />
    public partial class AddPageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageRankings",
                columns: table => new
                {
                    Url = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rank = table.Column<double>(type: "float", nullable: false),
                    InGoing = table.Column<int>(type: "int", nullable: false),
                    OutGoing = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageRankings", x => x.Url);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageRankings");
        }
    }
}
