using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiVU.Migrations
{
    public partial class RecipeAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeAuthorId",
                table: "Recipes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeAuthorId",
                table: "Recipes",
                column: "RecipeAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_RecipeAuthorId",
                table: "Recipes",
                column: "RecipeAuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_RecipeAuthorId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipeAuthorId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeAuthorId",
                table: "Recipes");
        }
    }
}
