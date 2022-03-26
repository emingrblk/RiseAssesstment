using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class middlewareLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MiddlewareLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LogMessage = table.Column<string>(type: "text", nullable: true),
                    LogInnerException = table.Column<string>(type: "text", nullable: true),
                    LogStackTrace = table.Column<string>(type: "text", nullable: true),
                    LogMethod = table.Column<string>(type: "text", nullable: true),
                    ControllerName = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: true),
                    UserIp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiddlewareLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiddlewareLogs");
        }
    }
}
