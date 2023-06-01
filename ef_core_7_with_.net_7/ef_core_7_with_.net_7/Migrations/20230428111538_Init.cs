using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef_core_7_with_.net_7.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Infos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Field1 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Field2 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Field3 = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Field4 = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Field5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Field6 = table.Column<bool>(type: "bit", nullable: false),
                    Field7 = table.Column<byte>(type: "tinyint", nullable: false),
                    Field8 = table.Column<short>(type: "smallint", nullable: false),
                    Field9 = table.Column<int>(type: "int", nullable: false),
                    Field10 = table.Column<long>(type: "bigint", nullable: false),
                    Field11 = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    Field12 = table.Column<decimal>(type: "decimal(9,5)", precision: 9, scale: 5, nullable: false),
                    Field13 = table.Column<decimal>(type: "decimal(19,10)", precision: 19, scale: 10, nullable: false),
                    Field14 = table.Column<decimal>(type: "decimal(38,19)", precision: 38, scale: 19, nullable: false),
                    Field15 = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConversionNode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NvarcharNode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JsonNode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roots", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Infos");

            migrationBuilder.DropTable(
                name: "Roots");
        }
    }
}
