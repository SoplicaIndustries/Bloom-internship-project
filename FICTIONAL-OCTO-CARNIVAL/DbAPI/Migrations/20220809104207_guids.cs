using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbAPI.Migrations
{
    public partial class guids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Reference_Number",
                table: "Transactions",
                type: "binary(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(36)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "Customer_Id",
                table: "Transactions",
                type: "binary(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(36)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "Customer_Id",
                table: "Invoices",
                type: "binary(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(36)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "Customer_Id",
                table: "Discounts",
                type: "binary(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(36)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "GUID",
                table: "Customers",
                type: "binary(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(36)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Reference_Number",
                table: "Transactions",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "binary(16)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Customer_Id",
                table: "Transactions",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "binary(16)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Customer_Id",
                table: "Invoices",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "binary(16)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Customer_Id",
                table: "Discounts",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "binary(16)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "GUID",
                table: "Customers",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "binary(16)")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
