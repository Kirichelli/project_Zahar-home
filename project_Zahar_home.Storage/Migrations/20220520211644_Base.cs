using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_Zahar_home.Storage.Migrations
{
    public partial class Base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type_id",
                table: "Dishes",
                newName: "Type_Id");

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
                name: "Type_Of_Dish",
                columns: table => new
                {
                    Type_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ingridient_id = table.Column<int>(type: "int", nullable: false),
                    Ingridient_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Of_Dish", x => x.Type_Id);
                    table.ForeignKey(
                        name: "FK_Type_Of_Dish_Ingridient_Ingridient_id",
                        column: x => x.Ingridient_id,
                        principalTable: "Ingridient",
                        principalColumn: "Ingridient_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_Type_Id",
                table: "Dishes",
                column: "Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Type_Of_Dish_Ingridient_id",
                table: "Type_Of_Dish",
                column: "Ingridient_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Type_Of_Dish_Type_Id",
                table: "Dishes",
                column: "Type_Id",
                principalTable: "Type_Of_Dish",
                principalColumn: "Type_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Type_Of_Dish_Type_Id",
                table: "Dishes");

            migrationBuilder.DropTable(
                name: "Type_Of_Dish");

            migrationBuilder.DropTable(
                name: "Ingridient");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_Type_Id",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "Type_Id",
                table: "Dishes",
                newName: "Type_id");
        }
    }
}
