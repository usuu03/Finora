using Finora.Application.Controllers.Transactions.Upsert;
using FluentValidation;

namespace Finora.Application.Controllers.Transactions;

public class TransactionValidator : AbstractValidator<UpsertTransactionCommand>
{
    public TransactionValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than zero");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required")
            .MaximumLength(100).WithMessage("Category must be less than 100 characters");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description must be less than 500 characters");

        RuleFor(x => x.Date)
            .LessThanOrEqualTo(DateTime.Today).WithMessage("Date cannot be in the future");

        RuleFor(x => x.Type)
            .IsInEnum().WithMessage("Transaction type is invalid");
    }

}
