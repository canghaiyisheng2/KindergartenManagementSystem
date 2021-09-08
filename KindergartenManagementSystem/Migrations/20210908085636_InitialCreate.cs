using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KindergartenManagementSystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EatScores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StuId = table.Column<int>(nullable: false),
                    Teacher = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    EatScoreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EatScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EatScores_EatScores_EatScoreId",
                        column: x => x.EatScoreId,
                        principalTable: "EatScores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EatScores",
                columns: new[] { "Id", "Date", "EatScoreId", "Note", "Score", "StuId", "Teacher" },
                values: new object[] { 1, "20210908", null, "hhh", 4, 1, "fnsflm" });

            migrationBuilder.InsertData(
                table: "EatScores",
                columns: new[] { "Id", "Date", "EatScoreId", "Note", "Score", "StuId", "Teacher" },
                values: new object[] { 2, "20210907", null, "eee", 1, 2, "fnsflm" });

            migrationBuilder.CreateIndex(
                name: "IX_EatScores_EatScoreId",
                table: "EatScores",
                column: "EatScoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EatScores");
        }
    }
}
