using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JaiVendas.CrossCutting.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "CountryRegions",
                columns: table => new
                {
                    CountryRegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryRegions", x => x.CountryRegionId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    CustomerAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.CustomerAddressId);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_CountryRegions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "CountryRegions",
                        principalColumn: "CountryRegionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPhones",
                columns: table => new
                {
                    CustomerPhoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPhones", x => x.CustomerPhoneId);
                    table.ForeignKey(
                        name: "FK_CustomerPhones_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("0cf96f71-605e-4cca-b2b7-df4ed8bc35f9"), "Brazil" },
                    { new Guid("bea6856e-f59a-4505-9f8b-dc96b374a2c5"), "Germany" }
                });

            migrationBuilder.InsertData(
                table: "CountryRegions",
                columns: new[] { "CountryRegionId", "Code", "CountryId", "Description" },
                values: new object[,]
                {
                    { new Guid("9a227e78-f037-4593-a103-e3626316666f"), "SP", new Guid("0cf96f71-605e-4cca-b2b7-df4ed8bc35f9"), "São Paulo" },
                    { new Guid("e9970d15-d7c3-47b4-80b1-3b1d148032f7"), "MG", new Guid("0cf96f71-605e-4cca-b2b7-df4ed8bc35f9"), "Minas Gerais" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_CountryId",
                table: "CustomerAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_CustomerId",
                table: "CustomerAddresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_RegionId",
                table: "CustomerAddresses",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhones_CustomerId",
                table: "CustomerPhones",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "CustomerPhones");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "CountryRegions");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
