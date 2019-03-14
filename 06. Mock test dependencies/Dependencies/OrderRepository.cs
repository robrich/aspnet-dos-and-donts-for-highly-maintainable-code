using System.Collections.Generic;

namespace MockTestDependencies.Dependencies
{
	public interface IOrderRepository
	{
		List<Order> GetOrdersForCustomer(int customerId);
	}

	// TODO: public class OrderRepository : IOrderRepository
}
