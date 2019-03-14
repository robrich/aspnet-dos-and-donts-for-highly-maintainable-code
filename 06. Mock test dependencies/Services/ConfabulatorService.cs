using MockTestDependencies.Dependencies;
using System;
using System.Collections.Generic;

namespace MockTestDependencies.Services
{
	public interface IConfabulatorService
	{
		decimal CalculateConfabulationBalance(int customerId);
	}
	public class ConfabulatorService : IConfabulatorService
	{
		private readonly ICustomerRepository customerRepository;
		private readonly IOrderRepository orderRepository;
		private readonly IOrderService orderService;

		public ConfabulatorService(ICustomerRepository customerRepository, IOrderRepository orderRepository, IOrderService orderService)
		{
			this.customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
			this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
			this.orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
		}

		public decimal CalculateConfabulationBalance(int customerId)
		{

			Customer customer = this.customerRepository.GetById(customerId);
			if (customer == null) {
				return 0;
			}

			List<Order> orders = this.orderRepository.GetOrdersForCustomer(customerId);
			if (orders.Count < 1) {
				return 0;
			}

			decimal balance = 0;

			foreach (Order order in orders) {
				decimal orderTotal = this.orderService.CalculateOrderTotal(order);
				decimal discount = orderTotal * ((decimal)customer.DiscountPercent / 100.0M);
				decimal orderNet = orderTotal - discount;
				balance += orderNet;
			}

			return balance;
		}

	}
}
