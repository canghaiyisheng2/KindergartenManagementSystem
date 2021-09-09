using Microsoft.EntityFrameworkCore.Migrations;

namespace KindergartenManagementSystem.Migrations
{
    public partial class AddEatScoreTestDiagramData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EatScores",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: "20210901");

            migrationBuilder.InsertData(
                table: "EatScores",
                columns: new[] { "Id", "Date", "EatScoreId", "Note", "Score", "StuId", "Teacher" },
                values: new object[,]
                {
                    { 3, "20210902", null, "eee", 1, 2, "fnsflm" },
                    { 4, "20210903", null, "eee", 1, 2, "fnsflm" },
                    { 5, "20210904", null, "eee", 1, 2, "fnsflm" },
                    { 6, "20210905", null, "eee", 1, 2, "fnsflm" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EatScores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EatScores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EatScores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EatScores",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "EatScores",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: "20210907");
        }
    }
}
