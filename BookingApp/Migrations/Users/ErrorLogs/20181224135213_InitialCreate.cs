using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingApp.Migrations.Users.ErrorLogs
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PasswordExceptionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    ParamName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordExceptionLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordExceptionLogs");
        }
    }
}
