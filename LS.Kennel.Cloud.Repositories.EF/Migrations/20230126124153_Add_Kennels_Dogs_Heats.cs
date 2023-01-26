using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LS.Kennel.Cloud.Repositories.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddKennelsDogsHeats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "KennelId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Kennels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kennels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    HeatId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CallName = table.Column<string>(type: "TEXT", nullable: false),
                    KennelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogs_Kennels_KennelId",
                        column: x => x.KennelId,
                        principalTable: "Kennels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Heats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    End = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DogId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heats_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    HeatId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MaleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FemaleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mating_Dogs_FemaleId",
                        column: x => x.FemaleId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mating_Dogs_MaleId",
                        column: x => x.MaleId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mating_Heats_HeatId",
                        column: x => x.HeatId,
                        principalTable: "Heats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgesteroneTest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TestTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    HeatId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgesteroneTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgesteroneTest_Heats_HeatId",
                        column: x => x.HeatId,
                        principalTable: "Heats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_KennelId",
                table: "AspNetUsers",
                column: "KennelId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_HeatId",
                table: "Dogs",
                column: "HeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_KennelId",
                table: "Dogs",
                column: "KennelId");

            migrationBuilder.CreateIndex(
                name: "IX_Heats_DogId",
                table: "Heats",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_Mating_FemaleId",
                table: "Mating",
                column: "FemaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Mating_HeatId",
                table: "Mating",
                column: "HeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Mating_MaleId",
                table: "Mating",
                column: "MaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgesteroneTest_HeatId",
                table: "ProgesteroneTest",
                column: "HeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Kennels_KennelId",
                table: "AspNetUsers",
                column: "KennelId",
                principalTable: "Kennels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Heats_HeatId",
                table: "Dogs",
                column: "HeatId",
                principalTable: "Heats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Kennels_KennelId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Heats_HeatId",
                table: "Dogs");

            migrationBuilder.DropTable(
                name: "Mating");

            migrationBuilder.DropTable(
                name: "ProgesteroneTest");

            migrationBuilder.DropTable(
                name: "Heats");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Kennels");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_KennelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KennelId",
                table: "AspNetUsers");
        }
    }
}
