﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CedTruck.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trucks",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    model = table.Column<int>(type: "int", nullable: false),
                    yearFabrication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    yearModel = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trucks", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trucks");
        }
    }
}
