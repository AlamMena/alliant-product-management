using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AlliantProductManagementServer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CustomerProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProduct_Customers_CustomersId",
                table: "CustomerProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProduct_Product_ProductsId",
                table: "CustomerProduct");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerProduct",
                table: "CustomerProduct");

            migrationBuilder.DropIndex(
                name: "IX_CustomerProduct_ProductsId",
                table: "CustomerProduct");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "CustomerProduct",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "CustomersId",
                table: "CustomerProduct",
                newName: "ProductId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CustomerProduct",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CustomerProduct",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "CustomerProduct",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "CustomerProduct",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CustomerProduct",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "CustomerProduct",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "CustomerProduct",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "CustomerProduct",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerProduct",
                table: "CustomerProduct",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProduct_CustomerId",
                table: "CustomerProduct",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProduct_Customers_CustomerId",
                table: "CustomerProduct",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProduct_Customers_CustomerId",
                table: "CustomerProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerProduct",
                table: "CustomerProduct");

            migrationBuilder.DropIndex(
                name: "IX_CustomerProduct_CustomerId",
                table: "CustomerProduct");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CustomerProduct");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CustomerProduct");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CustomerProduct");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerProduct");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomerProduct");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "CustomerProduct");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CustomerProduct");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CustomerProduct");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "CustomerProduct",
                newName: "ProductsId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CustomerProduct",
                newName: "CustomersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerProduct",
                table: "CustomerProduct",
                columns: new[] { "CustomersId", "ProductsId" });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProduct_ProductsId",
                table: "CustomerProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProduct_Customers_CustomersId",
                table: "CustomerProduct",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProduct_Product_ProductsId",
                table: "CustomerProduct",
                column: "ProductsId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
