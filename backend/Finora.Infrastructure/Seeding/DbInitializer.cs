using Finora.Domain;
using Finora.Domain.Common.Enums;
using Finora.Infrastructure.Context;

namespace Finora.Infrastructure.Seeding;

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
                Description = "Bought groceries for the week",
                Date = DateTime.Now.AddDays(-7),
                Amount = 150.75m,
                Category =  "Groceries",
                Type = TransactionType.Expense,
                CreatedAt = DateTime.Now.AddDays(-7),
            },
            new()
            {
                Description = "Paid the monthly electric bill",
                Date = DateTime.Now.AddDays(-5),
                Amount = 75.50m,
                Category =  "Utilities",
                Type = TransactionType.Expense,
                CreatedAt = DateTime.Now.AddDays(-5),
            },
            new()
            {
                Description = "Watched a movie at the cinema",
                Date = DateTime.Now.AddDays(-3),
                Amount = 20.00m,
                Category =  "Entertainment",
                Type = TransactionType.Expense,
                CreatedAt = DateTime.Now.AddDays(-3),
            },
            new()
            {
                Description = "Bought a bus ticket for commuting",
                Date = DateTime.Now.AddDays(-1),
                Amount = 2.50m,
                Category =  "Transportation",
                Type = TransactionType.Expense,
                CreatedAt = DateTime.Now.AddDays(-1),
            },
            new()
            {
                Description = "Paid for a monthly gym membership",
                Date = DateTime.Now,
                Amount = 50.00m,
                Category =  "Health",
                Type = TransactionType.Expense,
                CreatedAt = DateTime.Now,
            },
            new()
            {
                Description = "Received salary for the month",
                Date = DateTime.Now,
                Amount = 3000.00m,
                Category =  "Income",
                Type = TransactionType.Income,
                CreatedAt = DateTime.Now,
            }
        };

        context.Transactions.AddRange(transactions);

        await context.SaveChangesAsync();
    }
}