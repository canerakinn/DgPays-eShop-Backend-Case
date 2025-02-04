namespace eShop.Ordering.API.Application.IntegrationEvents.Events
{
    public record OrderCompletedIntegrationEvent : IntegrationEvent
    {
        // Using record type for built-in value equality and immutability
        public int OrderId { get; }

        public OrderCompletedIntegrationEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}
