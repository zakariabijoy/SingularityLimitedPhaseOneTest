using Microsoft.EntityFrameworkCore.Migrations;

namespace SingularityLimitedPhaseOneTest.Migrations
{
    public partial class ProductModelisupdatedforlockanddeletestatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DeleteStatus",
                table: "Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockStatus",
                table: "Product",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteStatus",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "Product");
        }
    }
}
