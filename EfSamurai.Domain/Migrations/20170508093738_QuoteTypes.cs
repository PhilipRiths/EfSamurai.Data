using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfSamurai.Data.Migrations
{
    public partial class QuoteTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuouteTypesId",
                table: "Quotes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_QuouteTypesId",
                table: "Quotes",
                column: "QuouteTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Quotes_QuouteTypesId",
                table: "Quotes",
                column: "QuouteTypesId",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Quotes_QuouteTypesId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_QuouteTypesId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "QuouteTypesId",
                table: "Quotes");
        }
    }
}
