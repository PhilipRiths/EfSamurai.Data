using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EfSamurai.Data.Migrations
{
    public partial class QuickFixEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_QuoteType_QuouteTypesId",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_HairStyle_HairStyleTypesId",
                table: "Samurais");

            migrationBuilder.DropTable(
                name: "HairStyle");

            migrationBuilder.DropTable(
                name: "QuoteType");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_HairStyleTypesId",
                table: "Samurais");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_QuouteTypesId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "HairStyleTypesId",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "QuouteTypesId",
                table: "Quotes");

            migrationBuilder.AddColumn<int>(
                name: "HairStyleTypes",
                table: "Samurais",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuouteTypes",
                table: "Quotes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HairStyleTypes",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "QuouteTypes",
                table: "Quotes");

            migrationBuilder.AddColumn<int>(
                name: "HairStyleTypesId",
                table: "Samurais",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuouteTypesId",
                table: "Quotes",
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

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_HairStyleTypesId",
                table: "Samurais",
                column: "HairStyleTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_QuouteTypesId",
                table: "Quotes",
                column: "QuouteTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_QuoteType_QuouteTypesId",
                table: "Quotes",
                column: "QuouteTypesId",
                principalTable: "QuoteType",
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
    }
}
