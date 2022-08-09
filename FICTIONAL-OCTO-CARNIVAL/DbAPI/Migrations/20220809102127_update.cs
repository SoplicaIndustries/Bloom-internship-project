using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbAPI.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitsOfUsages",
                table: "UnitsOfUsages");

            migrationBuilder.RenameTable(
                name: "UnitsOfUsages",
                newName: "UnitsOfUsage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitsOfUsage",
                table: "UnitsOfUsage",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitsOfUsage",
                table: "UnitsOfUsage");

            migrationBuilder.RenameTable(
                name: "UnitsOfUsage",
                newName: "UnitsOfUsages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitsOfUsages",
                table: "UnitsOfUsages",
                column: "Id");
        }
    }
}
