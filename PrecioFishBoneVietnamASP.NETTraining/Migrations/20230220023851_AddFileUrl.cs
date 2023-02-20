using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrecioFishboneVietnamASP.NETTraining.Migrations
{
    public partial class AddFileUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Folders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "fileUrl",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedTime", "Modified" },
                values: new object[] { new DateTime(2023, 2, 20, 9, 38, 51, 21, DateTimeKind.Local).AddTicks(1520), new DateTime(2023, 2, 20, 9, 38, 51, 22, DateTimeKind.Local).AddTicks(6966) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "fileUrl",
                table: "Files");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Files",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: -1,
                column: "Modified",
                value: new DateTime(2023, 2, 17, 16, 34, 58, 434, DateTimeKind.Local).AddTicks(4673));
        }
    }
}
