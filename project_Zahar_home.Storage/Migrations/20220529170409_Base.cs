using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_Zahar_home.Storage.Migrations
{
    public partial class Base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Ingridients",
                columns: table => new
                {
                    Ingridient_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ingridient_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingridients", x => x.Ingridient_Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type_Of_Kitchens",
                columns: table => new
                {
                    Type_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingridient_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Of_Kitchens", x => x.Type_Id);
                    table.ForeignKey(
                        name: "FK_Type_Of_Kitchens_Ingridients_Ingridient_id",
                        column: x => x.Ingridient_id,
                        principalTable: "Ingridients",
                        principalColumn: "Ingridient_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cooked",
                columns: table => new
                {
                    Cooked_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Favourite_Id = table.Column<int>(type: "int", nullable: false),
                    UserRating_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooked", x => x.Cooked_Id);
                    table.ForeignKey(
                        name: "FK_Cooked_Favourites_Favourite_Id",
                        column: x => x.Favourite_Id,
                        principalTable: "Favourites",
                        principalColumn: "Favourite_Id",
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
                    Callories = table.Column<int>(type: "int", nullable: false),
                    Protein = table.Column<int>(type: "int", nullable: false),
                    Carbohydrat = table.Column<int>(type: "int", nullable: false),
                    Fat = table.Column<int>(type: "int", nullable: false),
                    Cook_Time = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating_Id = table.Column<int>(type: "int", nullable: false),
                    Type_Id = table.Column<int>(type: "int", nullable: false),
                    Cooked_Id = table.Column<int>(type: "int", nullable: true),
                    Favourite_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Dish_Id);
                    table.ForeignKey(
                        name: "FK_Dishes_Cooked_Cooked_Id",
                        column: x => x.Cooked_Id,
                        principalTable: "Cooked",
                        principalColumn: "Cooked_Id");
                    table.ForeignKey(
                        name: "FK_Dishes_Favourites_Favourite_Id",
                        column: x => x.Favourite_Id,
                        principalTable: "Favourites",
                        principalColumn: "Favourite_Id");
                    table.ForeignKey(
                        name: "FK_Dishes_Type_Of_Kitchens_Type_Id",
                        column: x => x.Type_Id,
                        principalTable: "Type_Of_Kitchens",
                        principalColumn: "Type_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imgs",
                columns: table => new
                {
                    Img_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dish_Id = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imgs", x => x.Img_Id);
                    table.ForeignKey(
                        name: "FK_Imgs_Dishes_Dish_Id",
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
                    Rating_Value = table.Column<double>(type: "float", nullable: false),
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
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cooked_Id = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Rating_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                    table.ForeignKey(
                        name: "FK_Users_Cooked_Cooked_Id",
                        column: x => x.Cooked_Id,
                        principalTable: "Cooked",
                        principalColumn: "Cooked_Id");
                    table.ForeignKey(
                        name: "FK_Users_Ratings_Rating_Id",
                        column: x => x.Rating_Id,
                        principalTable: "Ratings",
                        principalColumn: "Rating_Id");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRatings",
                columns: table => new
                {
                    UserRating_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Rating_Id = table.Column<int>(type: "int", nullable: false),
                    Rating_Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRatings", x => x.UserRating_Id);
                    table.ForeignKey(
                        name: "FK_UserRatings_Ratings_Rating_Id",
                        column: x => x.Rating_Id,
                        principalTable: "Ratings",
                        principalColumn: "Rating_Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserRatings_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cooked_Favourite_Id",
                table: "Cooked",
                column: "Favourite_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cooked_UserRating_Id",
                table: "Cooked",
                column: "UserRating_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_Cooked_Id",
                table: "Dishes",
                column: "Cooked_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_Favourite_Id",
                table: "Dishes",
                column: "Favourite_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_Type_Id",
                table: "Dishes",
                column: "Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Imgs_Dish_Id",
                table: "Imgs",
                column: "Dish_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_Dish_Id",
                table: "Ratings",
                column: "Dish_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Type_Of_Kitchens_Ingridient_id",
                table: "Type_Of_Kitchens",
                column: "Ingridient_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_Rating_Id",
                table: "UserRatings",
                column: "Rating_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_User_Id",
                table: "UserRatings",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Cooked_Id",
                table: "Users",
                column: "Cooked_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Rating_Id",
                table: "Users",
                column: "Rating_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cooked_UserRatings_UserRating_Id",
                table: "Cooked",
                column: "UserRating_Id",
                principalTable: "UserRatings",
                principalColumn: "UserRating_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cooked_Favourites_Favourite_Id",
                table: "Cooked");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Favourites_Favourite_Id",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Cooked_UserRatings_UserRating_Id",
                table: "Cooked");

            migrationBuilder.DropTable(
                name: "Imgs");

            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DropTable(
                name: "UserRatings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Cooked");

            migrationBuilder.DropTable(
                name: "Type_Of_Kitchens");

            migrationBuilder.DropTable(
                name: "Ingridients");
        }
    }
}
