using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LS.Kennel.Cloud.Repositories.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddKennelOwnerships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Kennels_KennelId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_KennelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KennelId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "KennelOwnerships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    KennelId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KennelOwnerships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KennelOwnerships_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KennelOwnerships_Kennels_KennelId",
                        column: x => x.KennelId,
                        principalTable: "Kennels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KennelOwnerships_KennelId",
                table: "KennelOwnerships",
                column: "KennelId");

            migrationBuilder.CreateIndex(
                name: "IX_KennelOwnerships_UserId",
                table: "KennelOwnerships",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KennelOwnerships");

            migrationBuilder.AddColumn<Guid>(
                name: "KennelId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_KennelId",
                table: "AspNetUsers",
                column: "KennelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Kennels_KennelId",
                table: "AspNetUsers",
                column: "KennelId",
                principalTable: "Kennels",
                principalColumn: "Id");
        }
    }
}
