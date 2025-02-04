using Ordering.Domain.Events;

namespace eShop.Ordering.API.Application.DomainEventHandlers
{
    public class OrderCompletedDomainEventHandler : INotificationHandler<OrderStatusChangedToCompletedDomainEvent>
    {
        private readonly IOrderingIntegrationEventService _orderingIntegrationEventService;
        private  readonly ILogger<OrderCompletedDomainEventHandler> _logger;

        public OrderCompletedDomainEventHandler(
        IOrderingIntegrationEventService orderingIntegrationEventService,
        ILogger<OrderCompletedDomainEventHandler> logger)
        {
            _orderingIntegrationEventService = orderingIntegrationEventService;
            _logger = logger;
        }

        public async Task Handle(OrderStatusChangedToCompletedDomainEvent domainEvent,
        CancellationToken cancellationToken)
        {
            _logger.LogInformation("Order {OrderId} completed, creating integration event",
                domainEvent.OrderId);
            var orderCompletedIntegrationEvent = new OrderCompletedIntegrationEvent(domainEvent.OrderId);
            await _orderingIntegrationEventService.AddAndSaveEventAsync(orderCompletedIntegrationEvent);
        }
    }
}
