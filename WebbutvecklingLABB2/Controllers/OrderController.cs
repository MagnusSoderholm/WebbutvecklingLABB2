using Microsoft.AspNetCore.Mvc;
using WebbutvecklingLABB2.Repositories;
using WebbutvecklingLABB2.Models;

namespace WebbutvecklingLABB2.Controllers;

[Route("api/orders")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IRepository<Order> _orderRepository;
    private readonly IRepository<Product> _productRepository;
    private readonly IRepository<Customer> _customerRepository;

    public OrderController(
        IRepository<Order> orderRepository,
        IRepository<Product> productRepository,
        IRepository<Customer> customerRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _customerRepository = customerRepository;
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(OrderRequest orderRequest)
    {
  
        var product = await _productRepository.GetByIdAsync(orderRequest.ProductId);
        var customer = await _customerRepository.GetByIdAsync(orderRequest.CustomerId);

        if (product == null)
        {
            return NotFound($"Product with ID {orderRequest.ProductId} not found.");
        }

        if (customer == null)
        {
            return NotFound($"Customer with ID {orderRequest.CustomerId} not found.");
        }

        var order = new Order
        {
            CustomerId = customer.Id,
            Customer = customer,
            OrderDate = DateTime.UtcNow,
            OrderItems = new List<OrderItem>
            {
                new OrderItem
                {
                    ProductId = product.Id,
                    Product = product,
                    Quantity = orderRequest.Quantity
                }
            }
        };

     
        await _orderRepository.AddAsync(order);

        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }

 
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        return order == null ? NotFound() : Ok(order);
    }
}

public class OrderRequest
{
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int Quantity { get; set; }
}
