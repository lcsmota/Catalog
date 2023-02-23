using CleanArchApi.Application.DTOs;
using CleanArchApi.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchApi.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductsController> _logger;
    public ProductsController(IProductService productService, ILogger<ProductsController> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    [HttpGet]
    [AllowAnonymous]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync()
    {

        var products = await _productService.GetProductsAsync();

        if (!products.Any()) return NotFound("Products not found.");

        _logger.LogInformation($"Returned all products from database.");
        return Ok(products);
    }

    [HttpGet("{id:int}", Name = "GetProduct")]
    [AllowAnonymous]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);

        if (product is null)
        {
            _logger.LogError($"Product with id: {id}, has not been found in database");
            return NotFound("Product not found.");
        }

        _logger.LogInformation($"Returned product with id: {id}");
        return Ok(product);
    }

    [HttpGet("{id:int}/ProductWithCategory")]
    [AllowAnonymous]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public async Task<ActionResult<ProductDTO>> GetProductByIdWithCategoryAsync(int id)
    {
        var product = await _productService.GetProductWithCategoryAsync(id);

        if (product is null)
        {
            _logger.LogError($"Product with id: {id}, has not been found in database");
            return NotFound("Product not found.");
        }

        _logger.LogInformation($"Returned product with id: {id} and your category");
        return Ok(product);
    }

    [HttpPost]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    public async Task<ActionResult<ProductDTO>> PostAsync(ProductDTO productDTO)
    {
        if (productDTO is null)
        {
            _logger.LogError($"Product object sent from client is null");
            return BadRequest("Invalid data. Check the field(s) and try again.");
        }

        await _productService.InsertProductAsync(productDTO);

        return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
    }

    [HttpPut("{id:int}")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
    public async Task<ActionResult<ProductDTO>> PutAsync(int id, ProductDTO productDTO)
    {
        if (id != productDTO.Id || productDTO is null)
        {
            _logger.LogError($"Product object sent from client is null or invalid");
            return BadRequest("Invalid data. Check the field(s) and try again.");
        }

        var product = await _productService.GetProductByIdAsync(productDTO.Id);
        if (product is null) return NotFound("Product not found.");

        await _productService.UpdateProductAsync(productDTO);

        return Ok(productDTO);
    }

    [HttpDelete("{id:int}")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);

        if (product is null)
        {
            _logger.LogError($"Product with id: {id}, has not been found in database");
            return NotFound("Product not found.");
        }

        await _productService.DeleteProductAsync(id);

        return NoContent();
    }
}
