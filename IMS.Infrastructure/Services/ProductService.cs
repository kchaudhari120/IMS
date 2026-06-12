using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IMS.Application.DTOs.Product;
using IMS.Application.Interfaces;
using IMS.Domain.Entities;

namespace IMS.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;

    public ProductService(
        IUnitOfWork unitOfWork,
        IProductRepository productRepository)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var products =
            await _productRepository.GetAllWithDetailsAsync();

        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            CategoryName = p.Category?.Name ?? "",
            SupplierName = p.Supplier?.SupplierName ?? "",
            CurrentStock = p.CurrentStock
        }).ToList();
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product =
            await _productRepository.GetByIdWithDetailsAsync(id);

        if (product == null)
            return null;

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CategoryName = product.Category?.Name ?? "",
            SupplierName = product.Supplier?.SupplierName ?? "",
            CurrentStock = product.CurrentStock
        };
    }

    public async Task<int> CreateAsync(CreateProductDto dto)
    {
        var category =
        await _unitOfWork.Categories.GetByIdAsync(dto.CategoryId);

        if (category == null)
            throw new Exception("Invalid Category Id");

        var supplier =
            await _unitOfWork.Suppliers.GetByIdAsync(dto.SupplierId);

        if (supplier == null)
            throw new Exception("Invalid Supplier Id");
        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            CategoryId = dto.CategoryId,
            SupplierId = dto.SupplierId,
            CurrentStock = 0,
            CreatedDate = DateTime.UtcNow
        };

        await _unitOfWork.Products.AddAsync(product);

        await _unitOfWork.SaveChangesAsync();

        return product.Id;
    }

    public async Task UpdateAsync(int id, UpdateProductDto dto)
    {
        var product =
            await _unitOfWork.Products.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product not found");

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.CategoryId = dto.CategoryId;
        product.SupplierId = dto.SupplierId;

        _unitOfWork.Products.Update(product);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product =
            await _unitOfWork.Products.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product not found");

        _unitOfWork.Products.Delete(product);

        await _unitOfWork.SaveChangesAsync();
    }
}