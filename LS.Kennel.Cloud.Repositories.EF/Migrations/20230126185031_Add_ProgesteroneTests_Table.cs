using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LS.Kennel.Cloud.Repositories.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddProgesteroneTestsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgesteroneTest_Heats_HeatId",
                table: "ProgesteroneTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgesteroneTest",
                table: "ProgesteroneTest");

            migrationBuilder.RenameTable(
                name: "ProgesteroneTest",
                newName: "ProgesteroneTests");

            migrationBuilder.RenameIndex(
                name: "IX_ProgesteroneTest_HeatId",
                table: "ProgesteroneTests",
                newName: "IX_ProgesteroneTests_HeatId");

            migrationBuilder.AlterColumn<Guid>(
                name: "HeatId",
                table: "ProgesteroneTests",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgesteroneTests",
                table: "ProgesteroneTests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgesteroneTests_Heats_HeatId",
                table: "ProgesteroneTests",
                column: "HeatId",
                principalTable: "Heats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgesteroneTests_Heats_HeatId",
                table: "ProgesteroneTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgesteroneTests",
                table: "ProgesteroneTests");

            migrationBuilder.RenameTable(
                name: "ProgesteroneTests",
                newName: "ProgesteroneTest");

            migrationBuilder.RenameIndex(
                name: "IX_ProgesteroneTests_HeatId",
                table: "ProgesteroneTest",
                newName: "IX_ProgesteroneTest_HeatId");

            migrationBuilder.AlterColumn<Guid>(
                name: "HeatId",
                table: "ProgesteroneTest",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgesteroneTest",
                table: "ProgesteroneTest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgesteroneTest_Heats_HeatId",
                table: "ProgesteroneTest",
                column: "HeatId",
                principalTable: "Heats",
                principalColumn: "Id");
        }
    }
}
