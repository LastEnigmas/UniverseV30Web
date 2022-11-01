using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataApp.Migrations
{
    public partial class AddUserNametoArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsernameUser",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsernameUser",
                table: "Articles");
        }
    }
}
