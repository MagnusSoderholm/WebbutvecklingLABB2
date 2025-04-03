using Microsoft.AspNetCore.Mvc;
using WebbutvecklingLABB2.Repositories;
using WebbutvecklingLABB2.Models;

namespace WebbutvecklingLABB2.Controllers;

//[Route("api/products")]
//[ApiController]
//public class ProductController : ControllerBase
//{
//    private readonly IRepository<Product> _productRepository;

//    public ProductController(IRepository<Product> productRepository)
//    {
//        _productRepository = productRepository;
//    }

//    [HttpGet]
//    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
//    {
//        return Ok(await _productRepository.GetAllAsync());
//    }

//    [HttpGet("{id}")]
//    public async Task<ActionResult<Product>> GetProduct(int id)
//    {
//        var product = await _productRepository.GetByIdAsync(id);
//        return product == null ? NotFound() : Ok(product);
//    }

//    [HttpPost]
//    public async Task<ActionResult<Product>> CreateProduct(Product product)
//    {
//        await _productRepository.AddAsync(product);
//        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
//    }

//    [HttpPut("{id}")]
//    public async Task<IActionResult> UpdateProduct(int id, Product product)
//    {
//        if (id != product.Id) return BadRequest();
//        await _productRepository.UpdateAsync(product);
//        return NoContent();
//    }

//    [HttpDelete("{id}")]
//    public async Task<IActionResult> DeleteProduct(int id)
//    {
//        await _productRepository.DeleteAsync(id);
//        return NoContent();
//    }
//}




[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IRepository<Product> _productRepository;

    public ProductController(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _productRepository.GetAllAsync();

        if (products == null || !products.Any())
        {
            return NotFound("Inga produkter hittades.");
        }

        // Returnera JSON istället för HTML
        return Ok(products);  // Detta kommer att serialisera objektet till JSON
    }
}
