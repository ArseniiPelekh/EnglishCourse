using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class change_FK_in_PersonRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_ArticleTypes_ArticleTypeId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRequests_ArticleTypes_ArticleTypeId",
                table: "PersonRequests");

            migrationBuilder.DropIndex(
                name: "IX_PersonRequests_ArticleTypeId",
                table: "PersonRequests");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ArticleTypeId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ArticleTypeId",
                table: "PersonRequests");

            migrationBuilder.DropColumn(
                name: "ArticleTypeId",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "FKArticleType",
                table: "PersonRequests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonRequests_FKArticleType",
                table: "PersonRequests",
                column: "FKArticleType");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_FKArticleType",
                table: "Articles",
                column: "FKArticleType");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_ArticleTypes_FKArticleType",
                table: "Articles",
                column: "FKArticleType",
                principalTable: "ArticleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRequests_ArticleTypes_FKArticleType",
                table: "PersonRequests",
                column: "FKArticleType",
                principalTable: "ArticleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_ArticleTypes_FKArticleType",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRequests_ArticleTypes_FKArticleType",
                table: "PersonRequests");

            migrationBuilder.DropIndex(
                name: "IX_PersonRequests_FKArticleType",
                table: "PersonRequests");

            migrationBuilder.DropIndex(
                name: "IX_Articles_FKArticleType",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "FKArticleType",
                table: "PersonRequests");

            migrationBuilder.AddColumn<int>(
                name: "ArticleTypeId",
                table: "PersonRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArticleTypeId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonRequests_ArticleTypeId",
                table: "PersonRequests",
                column: "ArticleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleTypeId",
                table: "Articles",
                column: "ArticleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_ArticleTypes_ArticleTypeId",
                table: "Articles",
                column: "ArticleTypeId",
                principalTable: "ArticleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRequests_ArticleTypes_ArticleTypeId",
                table: "PersonRequests",
                column: "ArticleTypeId",
                principalTable: "ArticleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
