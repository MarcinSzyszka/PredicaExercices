using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Predica.WebApp.Migrations
{
	public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransportMode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportMode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Journey",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreatorUserObjectIdentifier = table.Column<string>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: true),
                    LastModifierUserObjectIdentifier = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    TransportModeId = table.Column<int>(nullable: false),
                    TravelerObjectIdentifier = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Journey_TransportMode_TransportModeId",
                        column: x => x.TransportModeId,
                        principalTable: "TransportMode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Journey_TransportModeId",
                table: "Journey",
                column: "TransportModeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Journey");

            migrationBuilder.DropTable(
                name: "TransportMode");
        }
    }
}
