using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectED.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetTag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedUserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScreenCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyboardCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatteryCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChargerAvailable = table.Column<bool>(type: "bit", nullable: false),
                    WifiWorking = table.Column<bool>(type: "bit", nullable: false),
                    TestingReady = table.Column<bool>(type: "bit", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}