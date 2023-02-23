using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrecioFishboneVietnamASP.NETTraining.Migrations
{
    public partial class UpdateDefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedTime", "Modified" },
                values: new object[] { new DateTime(2023, 2, 23, 13, 33, 10, 865, DateTimeKind.Local).AddTicks(7540), new DateTime(2023, 2, 23, 13, 33, 10, 865, DateTimeKind.Local).AddTicks(8292) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedTime", "Modified" },
                values: new object[] { new DateTime(2023, 2, 20, 9, 40, 40, 201, DateTimeKind.Local).AddTicks(5875), new DateTime(2023, 2, 20, 9, 40, 40, 202, DateTimeKind.Local).AddTicks(6963) });
        }
    }
}
