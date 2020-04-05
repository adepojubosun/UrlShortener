using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlShortener.Migrations
{
    public partial class AnnotationDeclaration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UniqueId",
                table: "UrlShorteners",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortUrl",
                table: "UrlShorteners",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LongUrl",
                table: "UrlShorteners",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlDescription",
                table: "UrlShorteners",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VisitCount",
                table: "UrlShorteners",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlDescription",
                table: "UrlShorteners");

            migrationBuilder.DropColumn(
                name: "VisitCount",
                table: "UrlShorteners");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueId",
                table: "UrlShorteners",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "ShortUrl",
                table: "UrlShorteners",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "LongUrl",
                table: "UrlShorteners",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250);
        }
    }
}
