using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrecioFishboneVietnamASP.NETTraining.Migrations
{
    public partial class AddFileUrlTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fileUrl",
                table: "Files",
                newName: "FileUrl");

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedTime", "Modified" },
                values: new object[] { new DateTime(2023, 2, 20, 9, 40, 40, 201, DateTimeKind.Local).AddTicks(5875), new DateTime(2023, 2, 20, 9, 40, 40, 202, DateTimeKind.Local).AddTicks(6963) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileUrl",
                table: "Files",
                newName: "fileUrl");

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedTime", "Modified" },
                values: new object[] { new DateTime(2023, 2, 20, 9, 38, 51, 21, DateTimeKind.Local).AddTicks(1520), new DateTime(2023, 2, 20, 9, 38, 51, 22, DateTimeKind.Local).AddTicks(6966) });
        }
    }
}
