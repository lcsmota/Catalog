using CleanArchApi.Application.DTOs;
using CleanArchApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchApi.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAsync()
    {
        var categories = await _categoryService.GetCategoriesAsync();

        if (!categories.Any()) return NotFound("Products not found.");

        return Ok(categories);
    }

    [HttpGet("{id:int}", Name = "GetCategory")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public async Task<ActionResult<CategoryDTO>> GetAsync(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);

        if (category is null) return NotFound("Category not found.");

        return Ok(category);
    }

    [HttpPost]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    public async Task<ActionResult<CategoryDTO>> PostAsync(CategoryDTO categoryDTO)
    {
        if (categoryDTO is null)
            return BadRequest("Invalid data. Check the field(s) and try again.");

        await _categoryService.InsertCategoryAsync(categoryDTO);

        return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.Id }, categoryDTO);
    }

    [HttpPut("{id:int}")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
    public async Task<ActionResult<CategoryDTO>> PutAsync(int id, CategoryDTO categoryDTO)
    {
        if (id != categoryDTO.Id || categoryDTO is null)
            return BadRequest("Invalid data. Check the field(s) and try again.");

        var category = await _categoryService.GetCategoryByIdAsync(categoryDTO.Id);
        if (category is null) return NotFound("Category not found.");

        await _categoryService.UpdateCategoryAsync(categoryDTO);

        return Ok(categoryDTO);
    }

    [HttpDelete("{id:int}")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);

        if (category is null) return NotFound("Category not found.");

        await _categoryService.DeleteCategoryAsync(id);

        return NoContent();
    }
}
