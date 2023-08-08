using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tour_Package.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    Location_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location_Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.Location_Id);
                });

            migrationBuilder.CreateTable(
                name: "travel_agents",
                columns: table => new
                {
                    Travelagent_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Travelagent_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Travelagency_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Travelagent_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Travelagent_Contact = table.Column<long>(type: "bigint", nullable: true),
                    Travelagent_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Travelagent_Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Travelagent_Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_travel_agents", x => x.Travelagent_Id);
                });

            migrationBuilder.CreateTable(
                name: "packages",
                columns: table => new
                {
                    Package_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Package_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Package_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Package_Rate = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Package_Itenary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Package_Food = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Package_Hotel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Package_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location_Id = table.Column<int>(type: "int", nullable: false),
                    Travelagent_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packages", x => x.Package_Id);
                    table.ForeignKey(
                        name: "FK_packages_locations_Location_Id",
                        column: x => x.Location_Id,
                        principalTable: "locations",
                        principalColumn: "Location_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_packages_travel_agents_Travelagent_Id",
                        column: x => x.Travelagent_Id,
                        principalTable: "travel_agents",
                        principalColumn: "Travelagent_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "spots",
                columns: table => new
                {
                    Spot_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Spot_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spot_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spot_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Package_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spots", x => x.Spot_Id);
                    table.ForeignKey(
                        name: "FK_spots_packages_Package_Id",
                        column: x => x.Package_Id,
                        principalTable: "packages",
                        principalColumn: "Package_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_packages_Location_Id",
                table: "packages",
                column: "Location_Id");

            migrationBuilder.CreateIndex(
                name: "IX_packages_Travelagent_Id",
                table: "packages",
                column: "Travelagent_Id");

            migrationBuilder.CreateIndex(
                name: "IX_spots_Package_Id",
                table: "spots",
                column: "Package_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "spots");

            migrationBuilder.DropTable(
                name: "packages");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "travel_agents");
        }
    }
}
