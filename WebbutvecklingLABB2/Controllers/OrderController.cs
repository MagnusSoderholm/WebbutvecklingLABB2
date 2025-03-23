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

    // Skapa order med endast productId och customerId
    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(OrderRequest orderRequest)
    {
        // Hämta produkt och kund från databasen baserat på de skickade ID:n
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

        // Skapa ordern med den hämtade informationen
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
                    Quantity = orderRequest.Quantity // Quantity kan också vara en parameter i OrderRequest
                }
            }
        };

        // Lägg till ordern i databasen
        await _orderRepository.AddAsync(order);

        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }

    // Get order (detta är en exempelfunktion för att hämta order med ID)
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        return order == null ? NotFound() : Ok(order);
    }
}

// En förenklad modell för orderinmatning (endast de ID:n vi behöver)
public class OrderRequest
{
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int Quantity { get; set; } // Du kan lägga till mer information som Quantity om det behövs
}
