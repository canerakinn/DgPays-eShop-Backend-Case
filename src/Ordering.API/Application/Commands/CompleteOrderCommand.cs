namespace eShop.Ordering.API.Application.Commands
{
    public class CompleteOrderCommand : IRequest<bool>
    {
        public int OrderId { get; set; }

        public CompleteOrderCommand(int orderId)
        {
            OrderId = orderId;
        }
    }
}
