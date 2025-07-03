using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWeatherJournal.API.Migrations
{
    /// <inheritdoc />
    public partial class DefineFavoriteCityKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerFavoriteCity",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFavoriteCity", x => new { x.CustomerId, x.CityId });
                    table.ForeignKey(
                        name: "FK_CustomerFavoriteCity_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerFavoriteCity_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { 1, "john.carbaugh@outlook.com", "John Carbaugh" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFavoriteCity_CityId",
                table: "CustomerFavoriteCity",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerFavoriteCity");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
