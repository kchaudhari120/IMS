using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IMS.Application.DTOs.Product;

public interface IProductService
{
    Task<List<ProductDto>> GetAllAsync();

    Task<ProductDto?> GetByIdAsync(int id);

    Task<int> CreateAsync(CreateProductDto dto);

    Task UpdateAsync(int id, UpdateProductDto dto);

    Task DeleteAsync(int id);
}