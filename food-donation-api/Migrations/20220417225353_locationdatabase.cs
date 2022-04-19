using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace food_donation_api.Migrations
{
    public partial class locationdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Organization",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Long",
                table: "Organization",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "Long",
                table: "Organization");

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Long = table.Column<double>(type: "float", nullable: false),
                    OrganizationEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Location_Organization_OrganizationEmail",
                        column: x => x.OrganizationEmail,
                        principalTable: "Organization",
                        principalColumn: "OrganizationEmail",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_OrganizationEmail",
                table: "Location",
                column: "OrganizationEmail",
                unique: true,
                filter: "[OrganizationEmail] IS NOT NULL");
        }
    }
}
