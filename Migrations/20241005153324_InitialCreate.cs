using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseInventory.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__3214EC076EA597CA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false),
                    Phone = table.Column<string>(type: "nchar(12)", fixedLength: true, maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__3214EC07718A04DE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false),
                    Position = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Phone = table.Column<string>(type: "nchar(12)", fixedLength: true, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__3214EC07499072D0", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    ContactName = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nchar(12)", fixedLength: true, maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Supplier__3214EC078AC6FABD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__3214EC07753B596F", x => x.Id);
                    table.ForeignKey(
                        name: "CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    ReorderLevel = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Products__3214EC078818BA40", x => x.Id);
                    table.ForeignKey(
                        name: "CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Carrier = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    TrackingNumber = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shipment__3214EC07301A73E0", x => x.Id);
                    table.ForeignKey(
                        name: "OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__3214EC073FEEE309", x => x.Id);
                    table.ForeignKey(
                        name: "OrdersID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductID",
                table: "OrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierID",
                table: "Products",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_OrderID",
                table: "Shipments",
                column: "OrderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
