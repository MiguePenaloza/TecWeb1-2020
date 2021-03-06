﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStoreAPI.Migrations
{
    public partial class AddColumnInstrumentsImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Instruments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Instruments");
        }
    }
}
