using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EfSamurai.Data.Migrations
{
    public partial class EnumFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_QuoteTypes_QuouteTypesId",
                table: "Quotes");

            migrationBuilder.DropTable(
                name: "QuoteTypes");

            migrationBuilder.CreateTable(
                name: "QuoteType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_QuoteType_QuouteTypesId",
                table: "Quotes",
                column: "QuouteTypesId",
                principalTable: "QuoteType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_QuoteType_QuouteTypesId",
                table: "Quotes");

            migrationBuilder.DropTable(
                name: "QuoteType");

            migrationBuilder.CreateTable(
                name: "QuoteTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteTypes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_QuoteTypes_QuouteTypesId",
                table: "Quotes",
                column: "QuouteTypesId",
                principalTable: "QuoteTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
