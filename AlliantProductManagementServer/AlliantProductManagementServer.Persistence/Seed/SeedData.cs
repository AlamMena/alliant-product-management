using AlliantProductManagementServer.Domain.Entities.Customers;
using AlliantProductManagementServer.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Persistence.Seed
{
    public static class SeedData
    {

        public static void SeedInitialData(this ModelBuilder modelBuilder)
        {
            var createdAt = new DateTime(2025, 1, 1, 12, 0, 0).ToUniversalTime();
            var updatedAt = new DateTime(2025, 1, 15, 15, 30, 0).ToUniversalTime();

            // Seed Categories

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { Id = 1, Name = "Electronics", Description = "Devices and gadgets", CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new ProductCategory { Id = 2, Name = "Books", Description = "Printed and digital books", CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new ProductCategory { Id = 3, Name = "Clothing", Description = "Apparel and fashion", CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new ProductCategory { Id = 4, Name = "Groceries", Description = "Food and beverages", CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 20, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 20, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new ProductCategory { Id = 5, Name = "Furniture", Description = "Home and office furniture", CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 23, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 23, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" }
            );

            modelBuilder.Entity<Product>().HasData(
                // Electronics
                new Product { Id = 1, Name = "Samsung Galaxy S23", Description = "Flagship smartphone with high-end features", Price = 799.99m, CategoryId = 1, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 2, Name = "Apple MacBook Pro 16\" M1", Description = "High-performance laptop for professionals", Price = 2399.99m, CategoryId = 1, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 3, Name = "Sony 4K Ultra HD TV", Description = "Smart TV with immersive 4K resolution", Price = 1199.99m, CategoryId = 1, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 4, Name = "Bose QuietComfort 45 Headphones", Description = "Noise-cancelling headphones with premium sound", Price = 329.99m, CategoryId = 1, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 5, Name = "Canon EOS 90D Camera", Description = "High-performance DSLR for photographers", Price = 1299.99m, CategoryId = 1, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 6, Name = "Apple iPhone 13", Description = "Premium smartphone with amazing camera", Price = 699.99m, CategoryId = 1, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 7, Name = "Samsung Smartwatch Galaxy", Description = "Smartwatch with fitness tracking", Price = 249.99m, CategoryId = 1, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 8, Name = "LG OLED 55\" TV", Description = "High-quality OLED TV with stunning colors", Price = 1499.99m, CategoryId = 1, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 9, Name = "Microsoft Surface Pro 7", Description = "Powerful tablet with laptop functionality", Price = 849.99m, CategoryId = 1, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 10, Name = "Google Nest Thermostat", Description = "Smart thermostat with energy savings", Price = 129.99m, CategoryId = 1, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },

                // Books
                new Product { Id = 11, Name = "The Great Gatsby", Description = "Classic novel by F. Scott Fitzgerald", Price = 10.99m, CategoryId = 2, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 12, Name = "1984", Description = "Dystopian novel by George Orwell", Price = 12.99m, CategoryId = 2, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 13, Name = "The Catcher in the Rye", Description = "J.D. Salinger's novel about teenage rebellion", Price = 9.99m, CategoryId = 2, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 14, Name = "To Kill a Mockingbird", Description = "Harper Lee's Pulitzer Prize-winning novel", Price = 11.99m, CategoryId = 2, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 15, Name = "Pride and Prejudice", Description = "Classic novel by Jane Austen", Price = 14.99m, CategoryId = 2, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 16, Name = "Moby-Dick", Description = "Herman Melville's epic about obsession", Price = 13.99m, CategoryId = 2, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 17, Name = "The Odyssey", Description = "Homer's ancient Greek epic poem", Price = 15.99m, CategoryId = 2, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 18, Name = "War and Peace", Description = "Leo Tolstoy's epic about Napoleonic wars", Price = 19.99m, CategoryId = 2, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 19, Name = "Crime and Punishment", Description = "Fyodor Dostoevsky's novel about morality", Price = 18.99m, CategoryId = 2, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 20, Name = "The Brothers Karamazov", Description = "Dostoevsky's exploration of faith and doubt", Price = 16.99m, CategoryId = 2, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },

                // Clothing
                new Product { Id = 21, Name = "T-shirt", Description = "Cotton t-shirt in various colors", Price = 15.99m, CategoryId = 3, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 22, Name = "Jeans", Description = "Denim jeans for men and women", Price = 29.99m, CategoryId = 3, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 23, Name = "Leather Jacket", Description = "Stylish leather jacket for winter", Price = 89.99m, CategoryId = 3, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 24, Name = "Sneakers", Description = "Comfortable sneakers for casual wear", Price = 49.99m, CategoryId = 3, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 25, Name = "Winter Coat", Description = "Warm and stylish coat for cold weather", Price = 120.00m, CategoryId = 3, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 26, Name = "Sweater", Description = "Soft woolen sweater for layering", Price = 40.00m, CategoryId = 3, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 27, Name = "Cap", Description = "Baseball cap in various colors", Price = 18.00m, CategoryId = 3, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 28, Name = "Scarf", Description = "Wool scarf for winter warmth", Price = 25.00m, CategoryId = 3, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 29, Name = "Socks", Description = "Comfortable cotton socks", Price = 5.00m, CategoryId = 3, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" },
                new Product { Id = 30, Name = "Belt", Description = "Leather belt for formal and casual wear", Price = 30.00m, CategoryId = 3, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false, Note = "Seed data" }
            );


            // Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "John", LastName = "Doe", Identification = "123456789", PhoneNumber = "555-1234", Email = "john.doe@example.com", CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = updatedAt, IsDeleted = false, Note = "Seed data" },
                new Customer { Id = 2, Name = "Jane", LastName = "Smith", Identification = "987654321", PhoneNumber = "555-9876", Email = "jane.smith@example.com", CreatedBy = 1, CreatedAt = createdAt, UpdatedAt = updatedAt, IsDeleted = false, Note = "Seed data" },
                new Customer { Id = 3, Name = "Alice", LastName = "Johnson", Identification = "112233445", PhoneNumber = "555-1122", Email = "alice.johnson@example.com", CreatedBy = 1, CreatedAt = createdAt, UpdatedAt = updatedAt, IsDeleted = false, Note = "Seed data" },
                new Customer { Id = 4, Name = "Bob", LastName = "Brown", Identification = "556677889", PhoneNumber = "555-3344", Email = "bob.brown@example.com", CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 19, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = updatedAt, IsDeleted = false, Note = "Seed data" },
                new Customer { Id = 5, Name = "Charlie", LastName = "Davis", Identification = "998877665", PhoneNumber = "555-5566", Email = "charlie.davis@example.com", CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = updatedAt, IsDeleted = false, Note = "Seed data" }
            );

            // Seed Customer Products
            modelBuilder.Entity<CustomerProduct>().HasData(
                new CustomerProduct { Id = 1, CustomerId = 1, ProductId = 1, Quantity = 2, Price = 20.0m, CreatedBy = 1, CreatedAt = createdAt, UpdatedAt = updatedAt, IsDeleted = false, Note = "Seed data" },
                new CustomerProduct { Id = 2, CustomerId = 1, ProductId = 2, Quantity = 1, Price = 15.0m, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = updatedAt, IsDeleted = false, Note = "Seed data" },
                new CustomerProduct { Id = 3, CustomerId = 2, ProductId = 3, Quantity = 3, Price = 30.0m, CreatedBy = 1, CreatedAt = createdAt, UpdatedAt = updatedAt, IsDeleted = false, Note = "Seed data" },
                new CustomerProduct { Id = 4, CustomerId = 3, ProductId = 6, Quantity = 1, Price = 12.0m, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = updatedAt, IsDeleted = false, Note = "Seed data" },
                new CustomerProduct { Id = 5, CustomerId = 3, ProductId = 7, Quantity = 2, Price = 18.0m, CreatedBy = 1, CreatedAt = createdAt, UpdatedAt = updatedAt, IsDeleted = false, Note = "Seed data" },
                new CustomerProduct { Id = 6, CustomerId = 4, ProductId = 10, Quantity = 4, Price = 40.0m, CreatedBy = 1, CreatedAt = createdAt, UpdatedAt = updatedAt, IsDeleted = false, Note = "Seed data" },
                new CustomerProduct { Id = 7, CustomerId = 5, ProductId = 15, Quantity = 3, Price = 45.0m, CreatedBy = 1, CreatedAt = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = updatedAt, IsDeleted = false, Note = "Seed data" }
            );
        }
    }
}
