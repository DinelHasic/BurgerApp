using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerApp.Storage.Migrations
{
    public partial class InitDbBurger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burgers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    IsVegetarian = table.Column<bool>(type: "bit", nullable: false),
                    IsVegan = table.Column<bool>(type: "bit", nullable: false),
                    HasFries = table.Column<bool>(type: "bit", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burgers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserFk",
                        column: x => x.UserFk,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BurgerOrder",
                columns: table => new
                {
                    BurgersId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurgerOrder", x => new { x.BurgersId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_BurgerOrder_Burgers_BurgersId",
                        column: x => x.BurgersId,
                        principalTable: "Burgers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BurgerOrder_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Burgers",
                columns: new[] { "Id", "HasFries", "ImageURL", "IsVegan", "IsVegetarian", "Name", "Price" },
                values: new object[,]
                {
                    { 1, true, "https://cdn.sanity.io/images/czqk28jt/prod_bk_us/84743a96a55cb36ef603c512d5b97c9141c40a33-1333x1333.png?w=750&q=40&fit=max&auto=format", false, false, "Whooper", 12m },
                    { 2, true, "https://cdn.sanity.io/images/czqk28jt/prod_bk_us/f574650a6eecf9595cfcd164387cd6bbc54b5040-1333x1333.png?w=750&q=40&fit=max&auto=format", true, false, "Vegy", 18m },
                    { 3, false, "https://freepngimg.com/thumb/salad/76555-king-hamburger-mcdonald's-cheeseburger-veggie-pounder-burger.png", false, true, "Nature", 20m },
                    { 4, true, "https://cdn.shopify.com/s/files/1/0271/0205/2407/products/03299-86_20DIG_Silo_Double_20Whopper_500x540_CR_500x.png?v=1597779164", false, false, "Double Whooper", 24m },
                    { 5, true, "https://cdn.sanity.io/images/czqk28jt/prod_bk_us/bcd42730abc57596736977ba25daae24d197354a-1333x1333.png?w=750&q=40&fit=max&auto=format", false, false, "Chiken Burger", 10m },
                    { 6, true, "https://cdn.sanity.io/images/czqk28jt/prod_bk_us/f3d7588c1f46ad6a1afaa3404cec65ed6053879f-1333x1333.png?w=750&q=40&fit=max&auto=format", false, false, "DoubleChesse Burger", 10m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adress", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Bulevar 12", "Tomy", "Cruse", "222 222 333" },
                    { 2, "Bulevar 11", "Jhon", "Klon", "222 111 131" },
                    { 3, "Bulevar 7", "Elizabet", "Brown", "222 244 232" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BurgerOrder_OrdersId",
                table: "BurgerOrder",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserFk",
                table: "Orders",
                column: "UserFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BurgerOrder");

            migrationBuilder.DropTable(
                name: "Burgers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
