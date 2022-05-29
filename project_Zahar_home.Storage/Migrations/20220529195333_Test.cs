using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_Zahar_home.Storage.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cooked_Favourites_Favourite_Id",
                table: "Cooked");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Cooked_Cooked_Id",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Favourites_Favourite_Id",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Ratings_Rating_Id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DropIndex(
                name: "IX_Users_Rating_Id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_Cooked_Id",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_Favourite_Id",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Cooked_Favourite_Id",
                table: "Cooked");

            migrationBuilder.DropColumn(
                name: "Rating_Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Cooked_Id",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Favourite_Id",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Rating_Id",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Favourite_Id",
                table: "Cooked");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating_Id",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cooked_Id",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Favourite_Id",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating_Id",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Favourite_Id",
                table: "Cooked",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Favourites",
                columns: table => new
                {
                    Favourite_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => x.Favourite_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Rating_Id",
                table: "Users",
                column: "Rating_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_Cooked_Id",
                table: "Dishes",
                column: "Cooked_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_Favourite_Id",
                table: "Dishes",
                column: "Favourite_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cooked_Favourite_Id",
                table: "Cooked",
                column: "Favourite_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cooked_Favourites_Favourite_Id",
                table: "Cooked",
                column: "Favourite_Id",
                principalTable: "Favourites",
                principalColumn: "Favourite_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Cooked_Cooked_Id",
                table: "Dishes",
                column: "Cooked_Id",
                principalTable: "Cooked",
                principalColumn: "Cooked_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Favourites_Favourite_Id",
                table: "Dishes",
                column: "Favourite_Id",
                principalTable: "Favourites",
                principalColumn: "Favourite_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Ratings_Rating_Id",
                table: "Users",
                column: "Rating_Id",
                principalTable: "Ratings",
                principalColumn: "Rating_Id");
        }
    }
}
