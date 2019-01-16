using Microsoft.EntityFrameworkCore.Migrations;

namespace oef7.Migrations
{
    public partial class Constraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "punten",
                table: "Inschrijving",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "Cursus",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Voornaam",
                table: "Cursist",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Achternaam",
                table: "Cursist",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "punten",
                table: "Inschrijving");

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "Cursus",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Voornaam",
                table: "Cursist",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Achternaam",
                table: "Cursist",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
