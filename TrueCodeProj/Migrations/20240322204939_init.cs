using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrueCodeProj.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TagToUsers",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagToUsers", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_TagToUsers_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagToUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Domain", "Value" },
                values: new object[,]
                {
                    { new Guid("21b16e09-3168-4cc0-a4a8-4c5f831c8969"), "example1.com", "Tag3" },
                    { new Guid("676ede86-26d3-4a36-bc98-549fc0812820"), "example.com", "Tag1" },
                    { new Guid("d37c0e93-18ab-47d8-8fdc-51ba77bb9f9b"), "example2.com", "Tag4" },
                    { new Guid("dbad0d84-52d7-4fe2-95dd-efd93603e99f"), "example.com", "Tag2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Domain", "Name" },
                values: new object[,]
                {
                    { new Guid("0c349c34-640b-40d7-a282-726cfa65f070"), "example.com", "Test User 9" },
                    { new Guid("1b5e587f-f0ee-44b0-9dc7-fcdc772e8504"), "example.com", "Test User 4" },
                    { new Guid("27f70a0d-9eda-4522-acef-b783bf085321"), "example.com", "Test User 11" },
                    { new Guid("4c34425f-a176-4388-b822-7f97e449a7b1"), "example.com", "Test User 6" },
                    { new Guid("5c7f39ff-f38a-45f6-9357-774277d31215"), "example.com", "Test User 8" },
                    { new Guid("67ed6e86-26d3-4a36-bc98-549fc0812829"), "example.com", "Test User 1" },
                    { new Guid("6f5a467b-406b-4066-a037-ebe2f98d709d"), "example.com", "Test User 12" },
                    { new Guid("70594673-8609-450e-be8b-372948684ad8"), "example.com", "Test User 3" },
                    { new Guid("779f9dd6-6bd8-45de-9405-1a8350f4dc35"), "example.com", "Test User 13" },
                    { new Guid("7d356887-46d0-446b-b875-a0cd7b629f07"), "example.com", "Test User 10" },
                    { new Guid("a4feaf10-5e1e-4f6c-a4d1-0493b86558b4"), "example.com", "Test User 7" },
                    { new Guid("d65c4e28-481b-41cf-8c2e-21fcddfba2f6"), "example.com", "Test User 5" },
                    { new Guid("dbbcf8df-8879-459d-853e-060bf4d4b05b"), "example.com", "Test User 2" }
                });

            migrationBuilder.InsertData(
                table: "TagToUsers",
                columns: new[] { "EntityId", "TagId", "UserId" },
                values: new object[] { new Guid("3e2edb24-5250-4dcd-966a-62e75e79c676"), new Guid("676ede86-26d3-4a36-bc98-549fc0812820"), new Guid("67ed6e86-26d3-4a36-bc98-549fc0812829") });

            migrationBuilder.CreateIndex(
                name: "IX_TagToUsers_TagId",
                table: "TagToUsers",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TagToUsers_UserId",
                table: "TagToUsers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagToUsers");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
