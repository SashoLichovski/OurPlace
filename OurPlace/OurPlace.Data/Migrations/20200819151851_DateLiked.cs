using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OurPlace.Data.Migrations
{
    public partial class DateLiked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateLiked",
                table: "PostLikes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateLiked",
                table: "PostLikes");
        }
    }
}
