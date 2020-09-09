using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OurPlace.Data.Migrations
{
    public partial class ImageComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageCommentId",
                table: "CommentLikes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ImageComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: false),
                    DateSent = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ImageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageComments_UserImages_ImageId",
                        column: x => x.ImageId,
                        principalTable: "UserImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_ImageCommentId",
                table: "CommentLikes",
                column: "ImageCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageComments_ImageId",
                table: "ImageComments",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageComments_UserId",
                table: "ImageComments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLikes_ImageComments_ImageCommentId",
                table: "CommentLikes",
                column: "ImageCommentId",
                principalTable: "ImageComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_ImageComments_ImageCommentId",
                table: "CommentLikes");

            migrationBuilder.DropTable(
                name: "ImageComments");

            migrationBuilder.DropIndex(
                name: "IX_CommentLikes_ImageCommentId",
                table: "CommentLikes");

            migrationBuilder.DropColumn(
                name: "ImageCommentId",
                table: "CommentLikes");
        }
    }
}
