using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LS.Kennel.Cloud.Repositories.EF.Migrations
{
    /// <inheritdoc />
    public partial class EditMakingHeatEndNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heats_Dogs_DogId",
                table: "Heats");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Heats",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "DogId",
                table: "Heats",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CallName",
                table: "Dogs",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Heats_Dogs_DogId",
                table: "Heats",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heats_Dogs_DogId",
                table: "Heats");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Heats",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DogId",
                table: "Heats",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CallName",
                table: "Dogs",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Heats_Dogs_DogId",
                table: "Heats",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id");
        }
    }
}
