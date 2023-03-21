using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrecioFishboneVietnamASP.NETTraining.Migrations
{
    public partial class testaddcli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Folders_FolderId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Folders_ParentFolderId",
                table: "Folders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Folders",
                table: "Folders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                table: "Files");

            migrationBuilder.RenameTable(
                name: "Folders",
                newName: "Folder");

            migrationBuilder.RenameTable(
                name: "Files",
                newName: "MyFile");

            migrationBuilder.RenameIndex(
                name: "IX_Folders_ParentFolderId",
                table: "Folder",
                newName: "IX_Folder_ParentFolderId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_FolderId",
                table: "MyFile",
                newName: "IX_MyFile_FolderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Folder",
                table: "Folder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyFile",
                table: "MyFile",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Folder",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedTime", "Modified" },
                values: new object[] { new DateTime(2023, 3, 21, 16, 30, 51, 128, DateTimeKind.Local).AddTicks(2034), new DateTime(2023, 3, 21, 16, 30, 51, 128, DateTimeKind.Local).AddTicks(2806) });

            migrationBuilder.AddForeignKey(
                name: "FK_Folder_Folder_ParentFolderId",
                table: "Folder",
                column: "ParentFolderId",
                principalTable: "Folder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyFile_Folder_FolderId",
                table: "MyFile",
                column: "FolderId",
                principalTable: "Folder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folder_Folder_ParentFolderId",
                table: "Folder");

            migrationBuilder.DropForeignKey(
                name: "FK_MyFile_Folder_FolderId",
                table: "MyFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyFile",
                table: "MyFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Folder",
                table: "Folder");

            migrationBuilder.RenameTable(
                name: "MyFile",
                newName: "Files");

            migrationBuilder.RenameTable(
                name: "Folder",
                newName: "Folders");

            migrationBuilder.RenameIndex(
                name: "IX_MyFile_FolderId",
                table: "Files",
                newName: "IX_Files_FolderId");

            migrationBuilder.RenameIndex(
                name: "IX_Folder_ParentFolderId",
                table: "Folders",
                newName: "IX_Folders_ParentFolderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                table: "Files",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Folders",
                table: "Folders",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedTime", "Modified" },
                values: new object[] { new DateTime(2023, 2, 23, 13, 33, 10, 865, DateTimeKind.Local).AddTicks(7540), new DateTime(2023, 2, 23, 13, 33, 10, 865, DateTimeKind.Local).AddTicks(8292) });

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Folders_FolderId",
                table: "Files",
                column: "FolderId",
                principalTable: "Folders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Folders_ParentFolderId",
                table: "Folders",
                column: "ParentFolderId",
                principalTable: "Folders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
