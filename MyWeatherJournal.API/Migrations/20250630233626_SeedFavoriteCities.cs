using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyWeatherJournal.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedFavoriteCities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CustomerFavoriteCity",
                columns: new[] { "CityId", "CustomerId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerFavoriteCity",
                keyColumns: new[] { "CityId", "CustomerId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CustomerFavoriteCity",
                keyColumns: new[] { "CityId", "CustomerId" },
                keyValues: new object[] { 2, 1 });
        }
    }
}
