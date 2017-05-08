using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EfSamurai.Data.Migrations
{
    public partial class HairstyleTypeQuoteTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Quotes_QuouteTypesId",
                table: "Quotes");

            migrationBuilder.AddColumn<int>(
                name: "HairStyleTypesId",
                table: "Samurais",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HairStyle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairStyle", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_HairStyleTypesId",
                table: "Samurais",
                column: "HairStyleTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_QuoteTypes_QuouteTypesId",
                table: "Quotes",
                column: "QuouteTypesId",
                principalTable: "QuoteTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_HairStyle_HairStyleTypesId",
                table: "Samurais",
                column: "HairStyleTypesId",
                principalTable: "HairStyle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_QuoteTypes_QuouteTypesId",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_HairStyle_HairStyleTypesId",
                table: "Samurais");

            migrationBuilder.DropTable(
                name: "HairStyle");

            migrationBuilder.DropTable(
                name: "QuoteTypes");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_HairStyleTypesId",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "HairStyleTypesId",
                table: "Samurais");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Quotes_QuouteTypesId",
                table: "Quotes",
                column: "QuouteTypesId",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
