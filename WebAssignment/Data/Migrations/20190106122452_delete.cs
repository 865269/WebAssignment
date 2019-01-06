using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAssignment.Data.Migrations
{
    public partial class delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_BlogPost_MyBlogPostId",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "MyBlogPostId",
                table: "Comment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_BlogPost_MyBlogPostId",
                table: "Comment",
                column: "MyBlogPostId",
                principalTable: "BlogPost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_BlogPost_MyBlogPostId",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "MyBlogPostId",
                table: "Comment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_BlogPost_MyBlogPostId",
                table: "Comment",
                column: "MyBlogPostId",
                principalTable: "BlogPost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
