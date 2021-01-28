using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirlineProject.Migrations
{
    public partial class IitialCrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airline",
                columns: table => new
                {
                    AirlineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineName = table.Column<string>(nullable: true),
                    DepatureDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline", x => x.AirlineID);
                });

            migrationBuilder.CreateTable(
                name: "StaffMember",
                columns: table => new
                {
                    StaffMemberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffMemberName = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<int>(nullable: false),
                    EmailId = table.Column<string>(nullable: true),
                    AirlineID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMember", x => x.StaffMemberID);
                    table.ForeignKey(
                        name: "FK_StaffMember_Airline_AirlineID",
                        column: x => x.AirlineID,
                        principalTable: "Airline",
                        principalColumn: "AirlineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketPrice",
                columns: table => new
                {
                    TicketID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketName = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    AirlineID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPrice", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_TicketPrice_Airline_AirlineID",
                        column: x => x.AirlineID,
                        principalTable: "Airline",
                        principalColumn: "AirlineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Traveller",
                columns: table => new
                {
                    TravellerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravellerName = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<int>(nullable: false),
                    EmailID = table.Column<int>(nullable: false),
                    StaffMemberID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traveller", x => x.TravellerID);
                    table.ForeignKey(
                        name: "FK_Traveller_StaffMember_StaffMemberID",
                        column: x => x.StaffMemberID,
                        principalTable: "StaffMember",
                        principalColumn: "StaffMemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffMember_AirlineID",
                table: "StaffMember",
                column: "AirlineID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPrice_AirlineID",
                table: "TicketPrice",
                column: "AirlineID");

            migrationBuilder.CreateIndex(
                name: "IX_Traveller_StaffMemberID",
                table: "Traveller",
                column: "StaffMemberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketPrice");

            migrationBuilder.DropTable(
                name: "Traveller");

            migrationBuilder.DropTable(
                name: "StaffMember");

            migrationBuilder.DropTable(
                name: "Airline");
        }
    }
}
