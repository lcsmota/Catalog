using CleanArchApi.Application.DTOs;
using CleanArchApi.Application.Interfaces;
using CleanArchApi.Domain.FiltersDb;
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

        return categories.IsSuccess
            ? Ok(categories)
            : NotFound(categories);
    }

    [HttpGet("{id:int}", Name = "GetCategory")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public async Task<ActionResult<CategoryDTO>> GetAsync(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);

        return category.IsSuccess
            ? Ok(category)
            : NotFound(category);
    }

    [HttpGet("Pagination")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public async Task<ActionResult<CategoryDTO>> GetWithPaginationAsync([FromQuery] CategoryFilterDb categoryFilterDb)
    {
        var category = await _categoryService.GetPagedAsync(categoryFilterDb);

        return category.IsSuccess
            ? Ok(category)
            : BadRequest(category);
    }

    [HttpPost]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    public async Task<ActionResult> PostAsync(CategoryDTO categoryDTO)
    {
        var result = await _categoryService.InsertCategoryAsync(categoryDTO);

        return result.IsSuccess
            ? Ok(result)
            : BadRequest(result);
    }

    [HttpPut()]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
    public async Task<ActionResult<CategoryDTO>> PutAsync(CategoryDTO categoryDTO)
    {
        var category = await _categoryService.UpdateCategoryAsync(categoryDTO);

        return category.IsSuccess
            ? Ok(categoryDTO)
            : BadRequest(category);
    }

    [HttpDelete("{id:int}")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var category = await _categoryService.DeleteCategoryAsync(id);

        return category.IsSuccess
            ? Ok(category)
            : NotFound(category);
    }
}
