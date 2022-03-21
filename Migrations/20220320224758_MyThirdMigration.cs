using Microsoft.EntityFrameworkCore.Migrations;

namespace projekatWP_bar.Migrations
{
    public partial class MyThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vote_User_VoterID",
                table: "Vote");

            migrationBuilder.DropIndex(
                name: "IX_Vote_VoterID",
                table: "Vote");

            migrationBuilder.DropColumn(
                name: "VoterID",
                table: "Vote");

            migrationBuilder.AlterColumn<int>(
                name: "EventID",
                table: "Vote",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Vote",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vote_UserID",
                table: "Vote",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_User_UserID",
                table: "Vote",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vote_User_UserID",
                table: "Vote");

            migrationBuilder.DropIndex(
                name: "IX_Vote_UserID",
                table: "Vote");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Vote");

            migrationBuilder.AlterColumn<int>(
                name: "EventID",
                table: "Vote",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "VoterID",
                table: "Vote",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vote_VoterID",
                table: "Vote",
                column: "VoterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_User_VoterID",
                table: "Vote",
                column: "VoterID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
