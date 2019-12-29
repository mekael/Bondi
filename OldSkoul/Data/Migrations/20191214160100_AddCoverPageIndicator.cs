using Microsoft.EntityFrameworkCore.Migrations;

namespace OldSkoul.Data.Migrations
{
    public partial class AddCoverPageIndicator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCoverPage",
                table: "Pages",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCoverPage",
                table: "Pages");
        }
    }
}
