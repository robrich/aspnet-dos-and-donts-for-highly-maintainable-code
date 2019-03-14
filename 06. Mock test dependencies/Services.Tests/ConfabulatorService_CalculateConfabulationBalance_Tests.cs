using FluentAssertions;
using MockTestDependencies.Dependencies;
using Moq;
using Moq.AutoMock;
using System.Collections.Generic;
using Xunit;

namespace MockTestDependencies.Services.Tests
{
	public class ConfabulatorService_CalculateConfabulationBalance_Tests
	{

		[Fact]
		public void NullCustomer_Returns0()
		{
			// Arrange
			int customerId = 0;
			decimal expected = 0;

			// Satisfy interfaces
			AutoMocker mockRepo = new AutoMocker();
			Mock<ICustomerRepository> customerRepository = setupCustomerRepository(mockRepo, returns: null);

            // Act
            // fragile:
            ConfabulatorService service = new ConfabulatorService(customerRepository.Object, new Mock<IOrderRepository>().Object, new Mock<IOrderService>().Object);
            // better:
            //ConfabulatorService service = mockRepo.CreateInstance<ConfabulatorService>();
			decimal actual = service.CalculateConfabulationBalance(customerId);

			// Assert
			actual.Should().Be(expected);

		}

		[Fact]
		public void NoOrders_Returns0()
		{
			// Arrange
			int customerId = 0;
			decimal expected = 0;

			// Satisfy interfaces
			Customer customer = new Customer();
			List<Order> orders = new List<Order>();

			AutoMocker mockRepo = new AutoMocker();
			Mock<ICustomerRepository> customerRepository = setupCustomerRepository(mockRepo, returns: customer);
			Mock<IOrderRepository> orderRepository = setupOrderRepository(mockRepo, returns: orders);

			// Act
			ConfabulatorService service = mockRepo.CreateInstance<ConfabulatorService>();
			decimal actual = service.CalculateConfabulationBalance(customerId);

			// Assert
			actual.Should().Be(expected);

		}

		[Fact]
		public void OneOrder_NoDiscount_ReturnsTotal()
		{
			// Arrange
			int customerId = 0;
			decimal expected = 100;

			// Satisfy interfaces
			Customer customer = new Customer {
				DiscountPercent = 0
			};
			List<Order> orders = new List<Order> {
				new Order {Total = 100}
			};

			AutoMocker mockRepo = new AutoMocker();
			Mock<ICustomerRepository> customerRepository = setupCustomerRepository(mockRepo, returns: customer);
			Mock<IOrderRepository> orderRepository = setupOrderRepository(mockRepo, returns: orders);
			Mock<IOrderService> orderService = setupOrderService(mockRepo);

			// Act
			ConfabulatorService service = mockRepo.CreateInstance<ConfabulatorService>();
			decimal actual = service.CalculateConfabulationBalance(customerId);

			// Assert
			actual.Should().Be(expected);

		}

		[Fact]
		public void ThreeOrder_HalfDiscount_Returns225()
		{
			// Arrange
			int customerId = 0;
			decimal expected = 225;

			// Satisfy interfaces
			Customer customer = new Customer {
				DiscountPercent = 25
			};
			List<Order> orders = new List<Order> {
				new Order {Total = 100},
				new Order {Total = 100},
				new Order {Total = 100}
			};

			AutoMocker mockRepo = new AutoMocker();
			Mock<ICustomerRepository> customerRepository = setupCustomerRepository(mockRepo, returns: customer);
			Mock<IOrderRepository> orderRepository = setupOrderRepository(mockRepo, returns: orders);
			Mock<IOrderService> orderService = setupOrderService(mockRepo);

			// Act
			ConfabulatorService service = mockRepo.CreateInstance<ConfabulatorService>();
			decimal actual = service.CalculateConfabulationBalance(customerId);

			// Assert
			actual.Should().Be(expected);

		}


		private Mock<ICustomerRepository> setupCustomerRepository(AutoMocker mockRepo, Customer returns)
		{
			Mock<ICustomerRepository> mock = mockRepo.GetMock<ICustomerRepository>();
			mock.Setup(m => m.GetById(It.IsAny<int>())).Returns(returns);
			return mock;
		}

		private Mock<IOrderRepository> setupOrderRepository(AutoMocker mockRepo, List<Order> returns)
		{
			Mock<IOrderRepository> mock = mockRepo.GetMock<IOrderRepository>();
			mock.Setup(m => m.GetOrdersForCustomer(It.IsAny<int>())).Returns(returns);
			return mock;
		}

		private Mock<IOrderService> setupOrderService(AutoMocker mockRepo)
		{
			Mock<IOrderService> mock = mockRepo.GetMock<IOrderService>();
			mock.Setup(m => m.CalculateOrderTotal(It.IsAny<Order>())).Returns<Order>(o => o.Total);
			return mock;
		}

	}
}
