using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace troja.Migrations
{
    /// <inheritdoc />
    public partial class pg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "secondname",
                table: "reservation",
                newName: "lastname");

            migrationBuilder.AddColumn<float>(
                name: "phonenumber",
                table: "reservation",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phonenumber",
                table: "reservation");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "reservation",
                newName: "secondname");
        }
    }
}
