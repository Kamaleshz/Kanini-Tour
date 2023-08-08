using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_Management.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "package_bookings",
                columns: table => new
                {
                    Booking_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Traveller_Id = table.Column<int>(type: "int", nullable: true),
                    Package_Id = table.Column<int>(type: "int", nullable: true),
                    Booking_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Travellers_Count = table.Column<int>(type: "int", nullable: true),
                    Booked_On = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Booking_Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_package_bookings", x => x.Booking_Id);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    Review_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Package_Id = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.Review_Id);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    Payment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Booking_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Card_Number = table.Column<long>(type: "bigint", nullable: false),
                    CVV = table.Column<int>(type: "int", nullable: false),
                    Expiry_Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Card_Holder_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.Payment_Id);
                    table.ForeignKey(
                        name: "FK_payments_package_bookings_Booking_Id",
                        column: x => x.Booking_Id,
                        principalTable: "package_bookings",
                        principalColumn: "Booking_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_payments_Booking_Id",
                table: "payments",
                column: "Booking_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "package_bookings");
        }
    }
}
