using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LS.Kennel.Cloud.Repositories.EF.Migrations
{
    /// <inheritdoc />
    public partial class EditMakingHeatIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Heats_HeatId",
                table: "Dogs");

            migrationBuilder.AlterColumn<Guid>(
                name: "HeatId",
                table: "Dogs",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Heats_HeatId",
                table: "Dogs",
                column: "HeatId",
                principalTable: "Heats",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Heats_HeatId",
                table: "Dogs");

            migrationBuilder.AlterColumn<Guid>(
                name: "HeatId",
                table: "Dogs",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Heats_HeatId",
                table: "Dogs",
                column: "HeatId",
                principalTable: "Heats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
