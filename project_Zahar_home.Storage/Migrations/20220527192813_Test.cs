using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_Zahar_home.Storage.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_User_Id",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_User_Id",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "CountOfUsers",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Ratings");

            migrationBuilder.AddColumn<int>(
                name: "Rating_Id",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type_Name",
                table: "Type_Of_Kitchens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "Rating_Value",
                table: "Ratings",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "User_Id",
                table: "Cooked",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_Cooked_User_Id",
                table: "Cooked",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cooked_Users_User_Id",
                table: "Cooked",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "User_Id",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cooked_Users_User_Id",
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
                name: "IX_Cooked_User_Id",
                table: "Cooked");

            migrationBuilder.DropColumn(
                name: "Rating_Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Type_Name",
                table: "Type_Of_Kitchens");

            migrationBuilder.DropColumn(
                name: "Cooked_Id",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Favourite_Id",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Cooked");

            migrationBuilder.AlterColumn<int>(
                name: "Rating_Value",
                table: "Ratings",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "CountOfUsers",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_User_Id",
                table: "Ratings",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_User_Id",
                table: "Ratings",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
