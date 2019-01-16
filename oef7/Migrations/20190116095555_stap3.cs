using Microsoft.EntityFrameworkCore.Migrations;

namespace oef7.Migrations
{
    public partial class stap3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "punten",
                table: "Inschrijving",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "punten",
                table: "Inschrijving",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
