namespace MockTestDependencies.Dependencies
{
	public interface IOrderService
	{
		decimal CalculateOrderTotal(Order order);
	}

	// TODO: public class OrderService : IOrderService
}
