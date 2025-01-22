using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlliantProductManagementServer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Identification = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerProducts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "Identification", "IsDeleted", "LastName", "Name", "Note", "PhoneNumber", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 16, 0, 0, 0, DateTimeKind.Utc), 1, "john.doe@example.com", "123456789", false, "Doe", "John", "Seed data", "555-1234", new DateTime(2025, 1, 15, 19, 30, 0, 0, DateTimeKind.Utc), null },
                    { 2, new DateTime(2025, 1, 1, 16, 0, 0, 0, DateTimeKind.Utc), 1, "jane.smith@example.com", "987654321", false, "Smith", "Jane", "Seed data", "555-9876", new DateTime(2025, 1, 15, 19, 30, 0, 0, DateTimeKind.Utc), null },
                    { 3, new DateTime(2025, 1, 1, 16, 0, 0, 0, DateTimeKind.Utc), 1, "alice.johnson@example.com", "112233445", false, "Johnson", "Alice", "Seed data", "555-1122", new DateTime(2025, 1, 15, 19, 30, 0, 0, DateTimeKind.Utc), null },
                    { 4, new DateTime(2025, 1, 1, 16, 0, 0, 0, DateTimeKind.Utc), 1, "bob.brown@example.com", "556677889", false, "Brown", "Bob", "Seed data", "555-3344", new DateTime(2025, 1, 15, 19, 30, 0, 0, DateTimeKind.Utc), null },
                    { 5, new DateTime(2025, 1, 1, 16, 0, 0, 0, DateTimeKind.Utc), 1, "charlie.davis@example.com", "998877665", false, "Davis", "Charlie", "Seed data", "555-5566", new DateTime(2025, 1, 15, 19, 30, 0, 0, DateTimeKind.Utc), null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "IsDeleted", "Name", "Note", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Devices and gadgets", false, "Electronics", "Seed data", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 2, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Printed and digital books", false, "Books", "Seed data", new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 3, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Apparel and fashion", false, "Clothing", "Seed data", new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 4, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Food and beverages", false, "Groceries", "Seed data", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 5, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Home and office furniture", false, "Furniture", "Seed data", new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Utc), null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "Description", "IsDeleted", "Name", "Note", "Price", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Flagship smartphone with high-end features", false, "Samsung Galaxy S23", "Seed data", 799.99m, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 2, 1, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), 1, "High-performance laptop for professionals", false, "Apple MacBook Pro 16\" M1", "Seed data", 2399.99m, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 3, 1, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Smart TV with immersive 4K resolution", false, "Sony 4K Ultra HD TV", "Seed data", 1199.99m, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 4, 1, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Noise-cancelling headphones with premium sound", false, "Bose QuietComfort 45 Headphones", "Seed data", 329.99m, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 5, 1, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), 1, "High-performance DSLR for photographers", false, "Canon EOS 90D Camera", "Seed data", 1299.99m, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 6, 1, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Premium smartphone with amazing camera", false, "Apple iPhone 13", "Seed data", 699.99m, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 7, 1, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Smartwatch with fitness tracking", false, "Samsung Smartwatch Galaxy", "Seed data", 249.99m, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 8, 1, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), 1, "High-quality OLED TV with stunning colors", false, "LG OLED 55\" TV", "Seed data", 1499.99m, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 9, 1, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Powerful tablet with laptop functionality", false, "Microsoft Surface Pro 7", "Seed data", 849.99m, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 10, 1, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Smart thermostat with energy savings", false, "Google Nest Thermostat", "Seed data", 129.99m, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 11, 2, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Classic novel by F. Scott Fitzgerald", false, "The Great Gatsby", "Seed data", 10.99m, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 12, 2, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Dystopian novel by George Orwell", false, "1984", "Seed data", 12.99m, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 13, 2, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), 1, "J.D. Salinger's novel about teenage rebellion", false, "The Catcher in the Rye", "Seed data", 9.99m, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 14, 2, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Harper Lee's Pulitzer Prize-winning novel", false, "To Kill a Mockingbird", "Seed data", 11.99m, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 15, 2, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Classic novel by Jane Austen", false, "Pride and Prejudice", "Seed data", 14.99m, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 16, 2, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Herman Melville's epic about obsession", false, "Moby-Dick", "Seed data", 13.99m, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 17, 2, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Homer's ancient Greek epic poem", false, "The Odyssey", "Seed data", 15.99m, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 18, 2, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Leo Tolstoy's epic about Napoleonic wars", false, "War and Peace", "Seed data", 19.99m, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 19, 2, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Fyodor Dostoevsky's novel about morality", false, "Crime and Punishment", "Seed data", 18.99m, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 20, 2, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Dostoevsky's exploration of faith and doubt", false, "The Brothers Karamazov", "Seed data", 16.99m, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 21, 3, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Cotton t-shirt in various colors", false, "T-shirt", "Seed data", 15.99m, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 22, 3, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Denim jeans for men and women", false, "Jeans", "Seed data", 29.99m, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 23, 3, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Stylish leather jacket for winter", false, "Leather Jacket", "Seed data", 89.99m, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 24, 3, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Comfortable sneakers for casual wear", false, "Sneakers", "Seed data", 49.99m, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 25, 3, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Warm and stylish coat for cold weather", false, "Winter Coat", "Seed data", 120.00m, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 26, 3, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Soft woolen sweater for layering", false, "Sweater", "Seed data", 40.00m, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 27, 3, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Baseball cap in various colors", false, "Cap", "Seed data", 18.00m, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 28, 3, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Wool scarf for winter warmth", false, "Scarf", "Seed data", 25.00m, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 29, 3, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Comfortable cotton socks", false, "Socks", "Seed data", 5.00m, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { 30, 3, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Leather belt for formal and casual wear", false, "Belt", "Seed data", 30.00m, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), null }
                });

            migrationBuilder.InsertData(
                table: "CustomerProducts",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CustomerId", "IsDeleted", "Note", "Price", "ProductId", "Quantity", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 16, 0, 0, 0, DateTimeKind.Utc), 1, 1, false, "Seed data", 20.0m, 1, 2, new DateTime(2025, 1, 15, 19, 30, 0, 0, DateTimeKind.Utc), null },
                    { 2, new DateTime(2025, 1, 1, 16, 0, 0, 0, DateTimeKind.Utc), 1, 1, false, "Seed data", 15.0m, 2, 1, new DateTime(2025, 1, 15, 19, 30, 0, 0, DateTimeKind.Utc), null },
                    { 3, new DateTime(2025, 1, 1, 16, 0, 0, 0, DateTimeKind.Utc), 1, 2, false, "Seed data", 30.0m, 3, 3, new DateTime(2025, 1, 15, 19, 30, 0, 0, DateTimeKind.Utc), null },
                    { 4, new DateTime(2025, 1, 1, 16, 0, 0, 0, DateTimeKind.Utc), 1, 3, false, "Seed data", 12.0m, 6, 1, new DateTime(2025, 1, 15, 19, 30, 0, 0, DateTimeKind.Utc), null },
                    { 5, new DateTime(2025, 1, 1, 16, 0, 0, 0, DateTimeKind.Utc), 1, 3, false, "Seed data", 18.0m, 7, 2, new DateTime(2025, 1, 15, 19, 30, 0, 0, DateTimeKind.Utc), null },
                    { 6, new DateTime(2025, 1, 1, 16, 0, 0, 0, DateTimeKind.Utc), 1, 4, false, "Seed data", 40.0m, 10, 4, new DateTime(2025, 1, 15, 19, 30, 0, 0, DateTimeKind.Utc), null },
                    { 7, new DateTime(2025, 1, 1, 16, 0, 0, 0, DateTimeKind.Utc), 1, 5, false, "Seed data", 45.0m, 15, 3, new DateTime(2025, 1, 15, 19, 30, 0, 0, DateTimeKind.Utc), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProducts_CustomerId",
                table: "CustomerProducts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProducts_ProductId",
                table: "CustomerProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerProducts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategory");
        }
    }
}
