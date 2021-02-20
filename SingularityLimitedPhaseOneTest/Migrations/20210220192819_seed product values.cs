using Microsoft.EntityFrameworkCore.Migrations;

namespace SingularityLimitedPhaseOneTest.Migrations
{
    public partial class seedproductvalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name", "Price", "SKU" },
                values: new object[] { 1, "Product 101 des", "Product 101", 10.0, "#001" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name", "Price", "SKU" },
                values: new object[] { 2, "Product 102 des", "Product 103", 20.0, "#002" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name", "Price", "SKU" },
                values: new object[] { 3, "Product 103 des", "Product 102", 30.0, "#003" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
