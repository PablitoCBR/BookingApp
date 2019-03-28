using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingApp.Migrations.Schedules
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}
