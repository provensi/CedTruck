using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CedTruck.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TruckModels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<long>(type: "bigint", nullable: true),
                    YearFabrication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YearModel = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trucks_TruckModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "TruckModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TruckModels",
                columns: new[] { "Id", "Model" },
                values: new object[] { 1L, "FH" });

            migrationBuilder.InsertData(
                table: "TruckModels",
                columns: new[] { "Id", "Model" },
                values: new object[] { 2L, "FM" });

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_ModelId",
                table: "Trucks",
                column: "ModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trucks");

            migrationBuilder.DropTable(
                name: "TruckModels");
        }
    }
}
