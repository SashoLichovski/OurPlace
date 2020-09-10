using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OurPlace.Data.Migrations
{
    public partial class NotificationImageColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Notifications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Notifications");
        }
    }
}
