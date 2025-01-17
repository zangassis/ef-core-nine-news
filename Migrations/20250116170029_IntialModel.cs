using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreNews.Migrations
{
    /// <inheritdoc />
    public partial class IntialModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress_Number = table.Column<int>(type: "int", nullable: false),
                    CustomerAddress_PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
