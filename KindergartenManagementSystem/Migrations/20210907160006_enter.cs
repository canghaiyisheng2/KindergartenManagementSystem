using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KindergartenManagementSystem.Migrations
{
    public partial class enter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "auth",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "banding",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cla",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "birth",
                table: "Children",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "cla",
                table: "Children",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gua_name",
                table: "Children",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gua_phone",
                table: "Children",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "home_addr",
                table: "Children",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Children",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "sex",
                table: "Children",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "enter_Requests",
                columns: table => new
                {
                    Pro_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(nullable: false),
                    Starter = table.Column<string>(nullable: true),
                    Approver = table.Column<string>(nullable: true),
                    Child_Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Sex = table.Column<bool>(nullable: false),
                    Gua_name = table.Column<string>(nullable: false),
                    Gua_phone = table.Column<string>(nullable: false),
                    Home_addr = table.Column<string>(nullable: false),
                    Cla = table.Column<string>(nullable: false),
                    Suggest = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enter_Requests", x => x.Pro_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enter_Requests");

            migrationBuilder.DropColumn(
                name: "auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "banding",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "cla",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "birth",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "cla",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "gua_name",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "gua_phone",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "home_addr",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "sex",
                table: "Children");
        }
    }
}
