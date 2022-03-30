using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultipleImageUpload.Migrations
{
    public partial class Iniitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "coverImage",
                table: "Users",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "coverImage",
                table: "Users");
        }
    }
}
