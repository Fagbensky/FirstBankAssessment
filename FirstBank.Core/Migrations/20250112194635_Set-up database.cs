using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstBank.Core.Migrations
{
    /// <inheritdoc />
    public partial class Setupdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndustryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequiredFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndustryId = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequiredFields_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Manufacturing" },
                    { 2, "Education" },
                    { 3, "Telecom" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AccountNumber", "IndustryId", "Name" },
                values: new object[,]
                {
                    { 1, "1234567890", 1, "Manufacturer A" },
                    { 2, "2345678901", 2, "School B" },
                    { 3, "3456789012", 3, "Telecom C" }
                });

            migrationBuilder.InsertData(
                table: "RequiredFields",
                columns: new[] { "Id", "FieldName", "IndustryId" },
                values: new object[,]
                {
                    { 1, "Invoice Number", 1 },
                    { 2, "Quantity", 1 },
                    { 3, "Delivery Address", 1 },
                    { 4, "Matric Number", 2 },
                    { 5, "Level", 2 },
                    { 6, "Course", 2 },
                    { 7, "GSM Number", 3 },
                    { 8, "Network", 3 },
                    { 9, "Residential Address", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IndustryId",
                table: "Customers",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_RequiredFields_IndustryId",
                table: "RequiredFields",
                column: "IndustryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "RequiredFields");

            migrationBuilder.DropTable(
                name: "Industries");
        }
    }
}
