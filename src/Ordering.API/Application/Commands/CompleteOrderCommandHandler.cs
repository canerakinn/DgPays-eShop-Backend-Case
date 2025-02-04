
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace eShop.Ordering.API.Application.Commands
{
    public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger _logger;

        public CompleteOrderCommandHandler(IOrderRepository orderRepository,
            ILogger<CompleteOrderCommand> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }
        public async Task<bool> Handle(CompleteOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(command.OrderId);

            if (order == null)
            {
                _logger.LogWarning("Order {OrderId} not found", command.OrderId);
                return false;
            }
            try
            {
                order.SetCompleted();
                await _orderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                return true;
            }
            catch (OrderingDomainException ex)
            {
                _logger.LogError(ex, "Error completing order {OrderId}", command.OrderId);
                return false;
            }
        }
    }
}
