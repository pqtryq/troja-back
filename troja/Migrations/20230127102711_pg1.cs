using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace troja.Migrations
{
    /// <inheritdoc />
    public partial class pg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    idcountry = table.Column<int>(type: "integer", nullable: false),
                    countryname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_country", x => x.idcountry);
                });

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    idreservation = table.Column<int>(type: "integer", nullable: false),
                    firstname = table.Column<string>(type: "text", nullable: false),
                    secondname = table.Column<string>(type: "text", nullable: false),
                    nop = table.Column<int>(type: "integer", nullable: false),
                    idtravel = table.Column<int>(type: "integer", nullable: false),
                    comments = table.Column<string>(type: "text", nullable: false),
                    orderdatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reservation", x => x.idreservation);
                });

            migrationBuilder.CreateTable(
                name: "travel",
                columns: table => new
                {
                    idtravel = table.Column<int>(type: "integer", nullable: false),
                    idcountry = table.Column<int>(type: "integer", nullable: false),
                    location = table.Column<string>(type: "text", nullable: false),
                    hotel = table.Column<string>(type: "text", nullable: false),
                    startdate = table.Column<DateOnly>(type: "date", nullable: false),
                    enddate = table.Column<DateOnly>(type: "date", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    xcord = table.Column<string>(type: "text", nullable: false),
                    ycord = table.Column<string>(type: "text", nullable: false),
                    slots = table.Column<int>(type: "integer", nullable: false),
                    remslots = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_travel", x => x.idtravel);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "travel");
        }
    }
}
