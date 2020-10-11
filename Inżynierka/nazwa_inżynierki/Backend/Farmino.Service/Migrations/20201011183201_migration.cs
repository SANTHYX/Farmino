using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Farmino.Service.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    StreetNumber = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
