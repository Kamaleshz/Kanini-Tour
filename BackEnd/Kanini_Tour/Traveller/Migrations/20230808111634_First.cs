using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travellers.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Travellers",
                columns: table => new
                {
                    Traveller_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Traveller_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Traveller_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Traveller_Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Traveller_Contact = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travellers", x => x.Traveller_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Travellers");
        }
    }
}
