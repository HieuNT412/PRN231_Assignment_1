using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    fullname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    gender = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    birthday = table.Column<DateTime>(type: "date", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.username);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "username", "address", "birthday", "fullname", "gender", "password" },
                values: new object[,]
                {
                    { "datnce", "123", new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen Dat", "nam", "1" },
                    { "hieu", "123", new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thanh Hieu", "nam", "1" },
                    { "khoiminh", "123", new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khoi Minh", "nam", "1" },
                    { "minh", "123", new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Duy Minh", "nam", "1" },
                    { "phong", "123", new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thanh Phong", "nam", "1" }
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
