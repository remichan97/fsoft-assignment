using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    public partial class AddUniqueConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UrlSlug",
                table: "Tags",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UrlSlug",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UrlSlug",
                table: "Tags",
                column: "UrlSlug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UrlSlug",
                table: "Posts",
                column: "UrlSlug",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tags_UrlSlug",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UrlSlug",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "UrlSlug",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UrlSlug",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
