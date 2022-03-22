using Microsoft.EntityFrameworkCore.Migrations;

namespace projekatWP_bar.Migrations
{
    public partial class MyNextMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendingEvents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttendingEvents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendeeID = table.Column<int>(type: "int", nullable: true),
                    EventID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendingEvents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AttendingEvents_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendingEvents_User_AttendeeID",
                        column: x => x.AttendeeID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendingEvents_AttendeeID",
                table: "AttendingEvents",
                column: "AttendeeID");

            migrationBuilder.CreateIndex(
                name: "IX_AttendingEvents_EventID",
                table: "AttendingEvents",
                column: "EventID");
        }
    }
}
