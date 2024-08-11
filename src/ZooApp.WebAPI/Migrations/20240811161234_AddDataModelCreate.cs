using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooApp.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDataModelCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zoos",
                columns: table => new
                {
                    UUID = table.Column<string>(type: "TEXT", nullable: false),
                    ID = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zoos", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    UUID = table.Column<string>(type: "TEXT", nullable: false),
                    ZooUUID = table.Column<string>(type: "TEXT", nullable: false),
                    ID = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Species = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TypeSound = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    SoundUrl = table.Column<string>(type: "TEXT", nullable: true),
                    SoundFileName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.UUID);
                    table.ForeignKey(
                        name: "FK_Animals_Zoos_ZooUUID",
                        column: x => x.ZooUUID,
                        principalTable: "Zoos",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    UUID = table.Column<string>(type: "TEXT", nullable: false),
                    ZooUUID = table.Column<string>(type: "TEXT", nullable: false),
                    ID = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.UUID);
                    table.ForeignKey(
                        name: "FK_Guests_Zoos_ZooUUID",
                        column: x => x.ZooUUID,
                        principalTable: "Zoos",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_ZooUUID",
                table: "Animals",
                column: "ZooUUID");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_Email",
                table: "Guests",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_ZooUUID",
                table: "Guests",
                column: "ZooUUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Zoos");
        }
    }
}
