using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OurPlace.Data.Migrations
{
    public partial class ImageLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageLikes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    DateLiked = table.Column<DateTime>(nullable: false),
                    ImageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageLikes_UserImages_ImageId",
                        column: x => x.ImageId,
                        principalTable: "UserImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageLikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageLikes_ImageId",
                table: "ImageLikes",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageLikes_UserId",
                table: "ImageLikes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageLikes");
        }
    }
}
