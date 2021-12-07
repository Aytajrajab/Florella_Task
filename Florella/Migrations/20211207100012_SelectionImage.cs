using Microsoft.EntityFrameworkCore.Migrations;

namespace Florella.Migrations
{
    public partial class SelectionImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SelectionImage",
                table: "Sections",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectionImage",
                table: "Sections");
        }
    }
}
