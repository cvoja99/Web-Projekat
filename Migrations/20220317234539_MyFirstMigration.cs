using Microsoft.EntityFrameworkCore.Migrations;

namespace projekatWP_bar.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klub",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klub", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlubID = table.Column<int>(type: "int", nullable: true),
                    ImeEventa = table.Column<string>(name: "Ime Eventa", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Kategorija = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IzvodjacID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Event_Klub_KlubID",
                        column: x => x.KlubID,
                        principalTable: "Klub",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_User_IzvodjacID",
                        column: x => x.IzvodjacID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoterID = table.Column<int>(type: "int", nullable: true),
                    EventID = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vote_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vote_User_VoterID",
                        column: x => x.VoterID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendingEvents_AttendeeID",
                table: "AttendingEvents",
                column: "AttendeeID");

            migrationBuilder.CreateIndex(
                name: "IX_AttendingEvents_EventID",
                table: "AttendingEvents",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_IzvodjacID",
                table: "Event",
                column: "IzvodjacID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_KlubID",
                table: "Event",
                column: "KlubID");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_EventID",
                table: "Vote",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_VoterID",
                table: "Vote",
                column: "VoterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendingEvents");

            migrationBuilder.DropTable(
                name: "Vote");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Klub");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
