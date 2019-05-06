using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    City = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(maxLength: 6, nullable: false),
                    Street = table.Column<string>(nullable: false),
                    Number = table.Column<string>(maxLength: 10, nullable: false),
                    Flat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    BusinessId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BusinessId = table.Column<int>(nullable: false),
                    Monday_Opening_Hours = table.Column<int>(nullable: true),
                    Monday_Opening_Minutes = table.Column<int>(nullable: true),
                    Monday_Closing_Hours = table.Column<int>(nullable: true),
                    Monday_Closing_Minutes = table.Column<int>(nullable: true),
                    Tuesday_Opening_Hours = table.Column<int>(nullable: true),
                    Tuesday_Opening_Minutes = table.Column<int>(nullable: true),
                    Tuesday_Closing_Hours = table.Column<int>(nullable: true),
                    Tuesday_Closing_Minutes = table.Column<int>(nullable: true),
                    Wednesday_Opening_Hours = table.Column<int>(nullable: true),
                    Wednesday_Opening_Minutes = table.Column<int>(nullable: true),
                    Wednesday_Closing_Hours = table.Column<int>(nullable: true),
                    Wednesday_Closing_Minutes = table.Column<int>(nullable: true),
                    Thursday_Opening_Hours = table.Column<int>(nullable: true),
                    Thursday_Opening_Minutes = table.Column<int>(nullable: true),
                    Thursday_Closing_Hours = table.Column<int>(nullable: true),
                    Thursday_Closing_Minutes = table.Column<int>(nullable: true),
                    Friday_Opening_Hours = table.Column<int>(nullable: true),
                    Friday_Opening_Minutes = table.Column<int>(nullable: true),
                    Friday_Closing_Hours = table.Column<int>(nullable: true),
                    Friday_Closing_Minutes = table.Column<int>(nullable: true),
                    Saturday_Opening_Hours = table.Column<int>(nullable: true),
                    Saturday_Opening_Minutes = table.Column<int>(nullable: true),
                    Saturday_Closing_Hours = table.Column<int>(nullable: true),
                    Saturday_Closing_Minutes = table.Column<int>(nullable: true),
                    Sunday_Opening_Hours = table.Column<int>(nullable: true),
                    Sunday_Opening_Minutes = table.Column<int>(nullable: true),
                    Sunday_Closing_Hours = table.Column<int>(nullable: true),
                    Sunday_Closing_Minutes = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    CompanyName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Businesses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_AddressId",
                table: "Businesses",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
