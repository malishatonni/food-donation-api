using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace food_donation_api.Migrations
{
    public partial class locationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organization_Location_GoogleLocationLocationId",
                table: "Organization");

            migrationBuilder.DropIndex(
                name: "IX_Organization_GoogleLocationLocationId",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "GoogleLocationLocationId",
                table: "Organization");

            migrationBuilder.AddColumn<string>(
                name: "OrganizationEmail",
                table: "Location",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_OrganizationEmail",
                table: "Location",
                column: "OrganizationEmail",
                unique: true,
                filter: "[OrganizationEmail] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Organization_OrganizationEmail",
                table: "Location",
                column: "OrganizationEmail",
                principalTable: "Organization",
                principalColumn: "OrganizationEmail",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Organization_OrganizationEmail",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_OrganizationEmail",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "OrganizationEmail",
                table: "Location");

            migrationBuilder.AddColumn<Guid>(
                name: "GoogleLocationLocationId",
                table: "Organization",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organization_GoogleLocationLocationId",
                table: "Organization",
                column: "GoogleLocationLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_Location_GoogleLocationLocationId",
                table: "Organization",
                column: "GoogleLocationLocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
