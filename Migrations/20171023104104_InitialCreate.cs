using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace lunchPollNet.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poll",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "BLOB", nullable: false),
                    ClosingTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poll", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "BLOB", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    LunchUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    StreetAddress = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PollItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "BLOB", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    PollId = table.Column<Guid>(type: "BLOB", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "BLOB", nullable: false),
                    TotalVoteCount = table.Column<int>(type: "INTEGER", nullable: false),
                    disabled = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollItem_Poll_PollId",
                        column: x => x.PollId,
                        principalTable: "Poll",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PollItem_Restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PollItem_PollId",
                table: "PollItem",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "IX_PollItem_RestaurantId",
                table: "PollItem",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PollItem");

            migrationBuilder.DropTable(
                name: "Poll");

            migrationBuilder.DropTable(
                name: "Restaurant");
        }
    }
}
