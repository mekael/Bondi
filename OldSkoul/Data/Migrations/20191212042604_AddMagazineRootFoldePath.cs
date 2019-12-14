using Microsoft.EntityFrameworkCore.Migrations;

namespace OldSkoul.Data.Migrations
{
    public partial class AddMagazineRootFoldePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Magazines_MagazineId",
                table: "Issues");

            migrationBuilder.AddColumn<string>(
                name: "MagazineRootFolderPath",
                table: "Magazines",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MagazineId",
                table: "Issues",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Magazines_MagazineId",
                table: "Issues",
                column: "MagazineId",
                principalTable: "Magazines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Magazines_MagazineId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "MagazineRootFolderPath",
                table: "Magazines");

            migrationBuilder.AlterColumn<int>(
                name: "MagazineId",
                table: "Issues",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Magazines_MagazineId",
                table: "Issues",
                column: "MagazineId",
                principalTable: "Magazines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
