using AutoMapper;
using CleanArchApi.Application.DTOs;
using CleanArchApi.Application.Interfaces;
using CleanArchApi.Application.Validations;
using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.FiltersDb;
using CleanArchApi.Domain.Interfaces;

namespace CleanArchApi.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepo;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryRepository categoryRepo, IMapper mapper)
    {
        _categoryRepo = categoryRepo;
        _mapper = mapper;
    }

    public async Task<ResultService<IEnumerable<CategoryDTO>>> GetCategoriesAsync()
    {
        var categories = await _categoryRepo.GetCategoriesAsync();

        if (!categories.Any())
            return ResultService.Fail<IEnumerable<CategoryDTO>>("Categories not found.");

        return ResultService.OK<IEnumerable<CategoryDTO>>(_mapper.Map<IEnumerable<CategoryDTO>>(categories));
    }

    public async Task<ResultService<CategoryDTO>> GetCategoryByIdAsync(int? id)
    {
        var category = await _categoryRepo.GetCategoryByIdAsync(id);

        if (category is null)
            return ResultService.Fail<CategoryDTO>("Category not found.");

        return ResultService.OK<CategoryDTO>(_mapper.Map<CategoryDTO>(category));
    }

    public async Task<ResultService<CategoryDTO>> InsertCategoryAsync(CategoryDTO categoryDTO)
    {
        if (categoryDTO is null)
            return ResultService.Fail<CategoryDTO>("Invalid data");

        var result = new CategoryDTOValidator().Validate(categoryDTO);
        if (!result.IsValid)
            return ResultService.RequestError<CategoryDTO>("Error. Check the field(s) and try again", result);

        var categoryDb = _mapper.Map<Category>(categoryDTO);
        await _categoryRepo.InsertCategoryAsync(categoryDb);

        return ResultService.OK<CategoryDTO>(_mapper.Map<CategoryDTO>(categoryDb));
    }

    public async Task<ResultService> UpdateCategoryAsync(CategoryDTO categoryDTO)
    {
        if (categoryDTO is null)
            return ResultService.Fail("Invalid data.");

        var validation = new CategoryDTOValidator().Validate(categoryDTO);
        if (!validation.IsValid)
            return ResultService.RequestError("Error: Check the field(s) and try again.", validation);

        var categoryDb = await _categoryRepo.GetCategoryByIdAsync(categoryDTO.Id);
        if (categoryDb is null)
            return ResultService.Fail("Category not found.");

        categoryDb = _mapper.Map<CategoryDTO, Category>(categoryDTO, categoryDb);
        await _categoryRepo.UpdateCategoryAsync(categoryDb);

        return ResultService.OK("Category updated successfully.");
    }

    public async Task<ResultService> DeleteCategoryAsync(int? id)
    {
        var categoryDb = _categoryRepo.GetCategoryByIdAsync(id).Result;

        if (categoryDb is null)
            return ResultService.Fail("Category not found.");

        await _categoryRepo.DeleteCategoryAsync(categoryDb);
        return ResultService.OK("Category deleted successfully.");
    }

    public async Task<ResultService<PagedBaseResponseDTO<CategoryDTO>>> GetPagedAsync(CategoryFilterDb categoryFilterDb)
    {
        var categoriesPaged = await _categoryRepo.GetPagedAsync(categoryFilterDb);

        var result = new PagedBaseResponseDTO<CategoryDTO>(
            categoriesPaged.TotalRegisters,
            _mapper.Map<List<CategoryDTO>>(categoriesPaged.Datas));

        return ResultService.OK(result);
    }
}
