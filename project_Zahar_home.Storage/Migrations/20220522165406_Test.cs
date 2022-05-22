using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_Zahar_home.Storage.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cooked",
                columns: table => new
                {
                    Cooked_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooked", x => x.Cooked_Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingridient",
                columns: table => new
                {
                    Ingridient_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ingridient_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingridient", x => x.Ingridient_Id);
                });

            migrationBuilder.CreateTable(
                name: "Type_Of_Dishes",
                columns: table => new
                {
                    Type_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ingridient_id = table.Column<int>(type: "int", nullable: false),
                    Ingridient_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Of_Dishes", x => x.Type_Id);
                    table.ForeignKey(
                        name: "FK_Type_Of_Dishes_Ingridient_Ingridient_id",
                        column: x => x.Ingridient_id,
                        principalTable: "Ingridient",
                        principalColumn: "Ingridient_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Dish_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Dish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Cook_Time = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category_id = table.Column<int>(type: "int", nullable: false),
                    Rating_id = table.Column<int>(type: "int", nullable: false),
                    Type_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Dish_Id);
                    table.ForeignKey(
                        name: "FK_Dishes_Type_Of_Dishes_Type_Id",
                        column: x => x.Type_Id,
                        principalTable: "Type_Of_Dishes",
                        principalColumn: "Type_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favourites",
                columns: table => new
                {
                    Favourite_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dish_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => x.Favourite_Id);
                    table.ForeignKey(
                        name: "FK_Favourites_Dishes_Dish_Id",
                        column: x => x.Dish_Id,
                        principalTable: "Dishes",
                        principalColumn: "Dish_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Rating_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating_Value = table.Column<int>(type: "int", nullable: false),
                    Dish_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Rating_Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Dishes_Dish_Id",
                        column: x => x.Dish_Id,
                        principalTable: "Dishes",
                        principalColumn: "Dish_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cooked_Id = table.Column<int>(type: "int", nullable: false),
                    Favourite_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                    table.ForeignKey(
                        name: "FK_Users_Cooked_Cooked_Id",
                        column: x => x.Cooked_Id,
                        principalTable: "Cooked",
                        principalColumn: "Cooked_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Favourites_Favourite_Id",
                        column: x => x.Favourite_Id,
                        principalTable: "Favourites",
                        principalColumn: "Favourite_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating_Users",
                columns: table => new
                {
                    Rating_user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating_Users", x => x.Rating_user_id);
                    table.ForeignKey(
                        name: "FK_Rating_Users_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_Type_Id",
                table: "Dishes",
                column: "Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_Dish_Id",
                table: "Favourites",
                column: "Dish_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_Users_User_Id",
                table: "Rating_Users",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_Dish_Id",
                table: "Ratings",
                column: "Dish_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Type_Of_Dishes_Ingridient_id",
                table: "Type_Of_Dishes",
                column: "Ingridient_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Cooked_Id",
                table: "Users",
                column: "Cooked_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Favourite_Id",
                table: "Users",
                column: "Favourite_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating_Users");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cooked");

            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Type_Of_Dishes");

            migrationBuilder.DropTable(
                name: "Ingridient");
        }
    }
}
