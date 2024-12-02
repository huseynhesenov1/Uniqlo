using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniqloProject.Migrations
{
    /// <inheritdoc />
    public partial class onetomantisdelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Catagories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Catagories");
        }
    }
}
