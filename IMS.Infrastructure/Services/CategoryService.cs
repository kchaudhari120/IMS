using IMS.Application.DTOs.Category;
using IMS.Application.Interfaces;
using IMS.Domain.Entities;
using IMS.Infrastructure.Data;
using IMS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Services;

public class CategoryService : ICategoryService
{
    //private readonly ApplicationDbContext _context;   

    //public CategoryService(ApplicationDbContext context)
    //{
    //    _context = context;
    //}

    private readonly IUnitOfWork _unitOfWork;
    public CategoryService(IUnitOfWork unitOfWork)
    {
      
        _unitOfWork = unitOfWork;
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        //return await _context.Categories
        //    .Select(x => new CategoryDto
        //    {
        //        Id = x.Id,
        //        Name = x.Name,
        //        Description = x.Description,
        //        CreatedDate = x.CreatedDate
        //    })
        //    .ToListAsync();

        var categories = await _unitOfWork.Categories.GetAllAsync();

        return categories.Select(x => new CategoryDto
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            CreatedDate = x.CreatedDate
        }).ToList();
    }

    public async Task<CategoryDto?> GetByIdAsync(int id)
    {
        //return await _context.Categories
        //    .Where(x => x.Id == id)
        //    .Select(x => new CategoryDto
        //    {
        //        Id = x.Id,
        //        Name = x.Name,
        //        Description = x.Description,
        //        CreatedDate = x.CreatedDate
        //    })
        //    .FirstOrDefaultAsync();

        var category = await _unitOfWork.Categories.GetByIdAsync(id);

        if (category == null)
            return null;

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            CreatedDate = category.CreatedDate
        };

    }

    public async Task<int> CreateAsync(CreateCategoryDto dto)
    {
        //var category = new Category
        //{
        //    Name = dto.Name,
        //    Description = dto.Description,
        //    CreatedDate = DateTime.UtcNow
        //};

        //_context.Categories.Add(category);

        //await _context.SaveChangesAsync();

        //return category.Id;


        var category = new Category
        {
            Name = dto.Name,
            Description = dto.Description,
            CreatedDate = DateTime.UtcNow
        };

        await _unitOfWork.Categories.AddAsync(category);

        await _unitOfWork.SaveChangesAsync();

        return category.Id;
    }

    public async Task UpdateAsync(int id, UpdateCategoryDto dto)
    {
        //var category =
        //    await _context.Categories.FindAsync(id);

        //if (category == null)
        //    throw new Exception("Category not found");

        //category.Name = dto.Name;
        //category.Description = dto.Description;

        //await _context.SaveChangesAsync();

        var category = await _unitOfWork.Categories.GetByIdAsync(id);

        if (category == null)
            throw new Exception("Category not found");

        category.Name = dto.Name;
        category.Description = dto.Description;

        _unitOfWork.Categories.Update(category);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        //var category =
        //    await _context.Categories.FindAsync(id);

        //if (category == null)
        //    throw new Exception("Category not found");

        //_context.Categories.Remove(category);

        //await _context.SaveChangesAsync();

        var category = await _unitOfWork.Categories.GetByIdAsync(id);

        if (category == null)
            throw new Exception("Category not found");

        _unitOfWork.Categories.Delete(category);

        await _unitOfWork.SaveChangesAsync();
    }
}