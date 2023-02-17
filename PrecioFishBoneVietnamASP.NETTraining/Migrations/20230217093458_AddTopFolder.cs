using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrecioFishboneVietnamASP.NETTraining.Migrations
{
    public partial class AddTopFolder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "ItemType", "Modified", "ModifiedBy", "Name", "ParentFolderId" },
                values: new object[] { -1, 1, new DateTime(2023, 2, 17, 16, 34, 58, 434, DateTimeKind.Local).AddTicks(4673), "System", "Top Folder", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
