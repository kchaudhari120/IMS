using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Interfaces;
using global::IMS.Application.DTOs.Category;
using IMS.Application.DTOs.Category;



public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllAsync();

    Task<CategoryDto?> GetByIdAsync(int id);

    Task<int> CreateAsync(CreateCategoryDto dto);

    Task UpdateAsync(int id, UpdateCategoryDto dto);

    Task DeleteAsync(int id);
}