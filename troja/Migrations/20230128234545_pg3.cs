using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace troja.Migrations
{
    /// <inheritdoc />
    public partial class pg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "phonenumber",
                table: "reservation",
                type: "text",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "phonenumber",
                table: "reservation",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
