using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buildora.Domain.Entities;
using Buildora.Domain.Enums;
using Buildora.Infrastructure.Context;

namespace Buildora.Infrastructure.Seeding;

public class DbInitializer
{
    public static async Task SeedData(AppDbContext context)
    {
        // Check if there are any transaction records in the database
        if (context.Transactions.Any()) return;

        var transactions = new List<Transaction>
        {
            new()
            {
                Name = "Grocery Shopping",
                Description = "Bought groceries for the week",
                Date = DateTime.Now.AddDays(-7),
                Amount = 150.75m,
                Category = Category.Groceries,
                AddedAt = DateTime.Now.AddDays(-7),
                UpdatedAt = DateTime.Now.AddDays(-7)
            },
            new()
            {
                Name = "Electric Bill",
                Description = "Paid the monthly electric bill",
                Date = DateTime.Now.AddDays(-5),
                Amount = 75.50m,
                Category = Category.Utilities,
                AddedAt = DateTime.Now.AddDays(-5),
                UpdatedAt = DateTime.Now.AddDays(-5)
            },
            new()
            {
                Name = "Movie Night",
                Description = "Watched a movie at the cinema",
                Date = DateTime.Now.AddDays(-3),
                Amount = 20.00m,
                Category = Category.Entertainment,
                AddedAt = DateTime.Now.AddDays(-3),
                UpdatedAt = DateTime.Now.AddDays(-3)
            },
            new()
            {
                Name = "Bus Ticket",
                Description = "Bought a bus ticket for commuting",
                Date = DateTime.Now.AddDays(-1),
                Amount = 2.50m,
                Category = Category.Transportation,
                AddedAt = DateTime.Now.AddDays(-1),
                UpdatedAt = DateTime.Now.AddDays(-1)
            },
            new()
            {
                Name = "Gym Membership",
                Description = "Paid for a monthly gym membership",
                Date = DateTime.Now,
                Amount = 50.00m,
                Category = Category.Health,
                AddedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };

        context.Transactions.AddRange(transactions);

        await context.SaveChangesAsync();
    }
}