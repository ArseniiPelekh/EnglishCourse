using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class delete_FK_in_PersonRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonRequests_ArticleTypes_FKArticleType",
                table: "PersonRequests");

            migrationBuilder.DropIndex(
                name: "IX_PersonRequests_FKArticleType",
                table: "PersonRequests");

            migrationBuilder.DropColumn(
                name: "FKArticleType",
                table: "PersonRequests");

            migrationBuilder.AddColumn<string>(
                name: "TypeForm",
                table: "PersonRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeForm",
                table: "PersonRequests");

            migrationBuilder.AddColumn<int>(
                name: "FKArticleType",
                table: "PersonRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonRequests_FKArticleType",
                table: "PersonRequests",
                column: "FKArticleType");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRequests_ArticleTypes_FKArticleType",
                table: "PersonRequests",
                column: "FKArticleType",
                principalTable: "ArticleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
