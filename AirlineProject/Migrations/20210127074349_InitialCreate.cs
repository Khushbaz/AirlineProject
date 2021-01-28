using Microsoft.EntityFrameworkCore.Migrations;

namespace AirlineProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailID",
                table: "Traveller");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmailID",
                table: "Traveller",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
