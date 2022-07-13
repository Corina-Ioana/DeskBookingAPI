using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DeskBookingAPI.Data.Migrations
{
    public partial class Bookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyRooms_Desks_DeskId",
                table: "CompanyRooms");

            migrationBuilder.DropIndex(
                name: "IX_CompanyRooms_DeskId",
                table: "CompanyRooms");

            migrationBuilder.AddColumn<int>(
                name: "CompanyRoomsID",
                table: "Desks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyRoomsId",
                table: "Desks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    DeskId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desks_CompanyRoomsID",
                table: "Desks",
                column: "CompanyRoomsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Desks_CompanyRooms_CompanyRoomsID",
                table: "Desks",
                column: "CompanyRoomsID",
                principalTable: "CompanyRooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desks_CompanyRooms_CompanyRoomsID",
                table: "Desks");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Desks_CompanyRoomsID",
                table: "Desks");

            migrationBuilder.DropColumn(
                name: "CompanyRoomsID",
                table: "Desks");

            migrationBuilder.DropColumn(
                name: "CompanyRoomsId",
                table: "Desks");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRooms_DeskId",
                table: "CompanyRooms",
                column: "DeskId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyRooms_Desks_DeskId",
                table: "CompanyRooms",
                column: "DeskId",
                principalTable: "Desks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
