namespace eShop.Ordering.API.Application.Validations
{
    public class CompleteOrderCommandValidator : AbstractValidator<CompleteOrderCommand>
    {
        public CompleteOrderCommandValidator()
        {
            RuleFor(command => command.OrderId)
                .GreaterThan(0).WithMessage("OrderId must be greater than 0");
        }
    }
}

