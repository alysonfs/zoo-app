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
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UUID = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zoos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ZooModelID = table.Column<int>(type: "INTEGER", nullable: true),
                    UUID = table.Column<string>(type: "TEXT", nullable: true),
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
                    table.PrimaryKey("PK_Animals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Animals_Zoos_ZooModelID",
                        column: x => x.ZooModelID,
                        principalTable: "Zoos",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ZooModelID = table.Column<int>(type: "INTEGER", nullable: true),
                    UUID = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Guests_Zoos_ZooModelID",
                        column: x => x.ZooModelID,
                        principalTable: "Zoos",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_UUID",
                table: "Animals",
                column: "UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_ZooModelID",
                table: "Animals",
                column: "ZooModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_Email",
                table: "Guests",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_UUID",
                table: "Guests",
                column: "UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_ZooModelID",
                table: "Guests",
                column: "ZooModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Zoos_UUID",
                table: "Zoos",
                column: "UUID",
                unique: true);
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
