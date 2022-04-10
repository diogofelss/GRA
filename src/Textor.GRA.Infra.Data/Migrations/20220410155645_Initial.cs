using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Textor.GRA.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MovieProducers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    MovieID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProducerID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieProducers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieProducers_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieProducers_Producers_ProducerID",
                        column: x => x.ProducerID,
                        principalTable: "Producers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieStudios",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    MovieID = table.Column<Guid>(type: "TEXT", nullable: false),
                    StudioID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieStudios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieStudios_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieStudios_Studios_StudioID",
                        column: x => x.StudioID,
                        principalTable: "Studios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieProducers_MovieID",
                table: "MovieProducers",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieProducers_ProducerID",
                table: "MovieProducers",
                column: "ProducerID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieStudios_MovieID",
                table: "MovieStudios",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieStudios_StudioID",
                table: "MovieStudios",
                column: "StudioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieProducers");

            migrationBuilder.DropTable(
                name: "MovieStudios");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
