using Microsoft.EntityFrameworkCore.Migrations;

namespace projekatWP_bar.Migrations
{
    public partial class CHangeVote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendingEvents_User_AttendeeID",
                table: "AttendingEvents");

            migrationBuilder.AddColumn<int>(
                name: "targetUID",
                table: "Vote",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vote_targetUID",
                table: "Vote",
                column: "targetUID");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendingEvents_User_AttendeeID",
                table: "AttendingEvents",
                column: "AttendeeID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_User_targetUID",
                table: "Vote",
                column: "targetUID",
                principalTable: "User",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendingEvents_User_AttendeeID",
                table: "AttendingEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_User_targetUID",
                table: "Vote");

            migrationBuilder.DropIndex(
                name: "IX_Vote_targetUID",
                table: "Vote");

            migrationBuilder.DropColumn(
                name: "targetUID",
                table: "Vote");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendingEvents_User_AttendeeID",
                table: "AttendingEvents",
                column: "AttendeeID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
