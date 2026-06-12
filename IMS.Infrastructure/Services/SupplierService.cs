using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IMS.Application.DTOs.Supplier;
using IMS.Application.Interfaces;
using IMS.Domain.Entities;

namespace IMS.Infrastructure.Services;

public class SupplierService : ISupplierService
{
    private readonly IUnitOfWork _unitOfWork;

    public SupplierService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<SupplierDto>> GetAllAsync()
    {
        var suppliers =
            await _unitOfWork.Suppliers.GetAllAsync();

        return suppliers.Select(x => new SupplierDto
        {
            Id = x.Id,
            SupplierName = x.SupplierName,
            ContactPerson = x.ContactPerson,
            Email = x.Email,
            Phone = x.Phone,
            Address = x.Address,
            CreatedDate = x.CreatedDate
        }).ToList();
    }

    public async Task<SupplierDto?> GetByIdAsync(int id)
    {
        var supplier =
            await _unitOfWork.Suppliers.GetByIdAsync(id);

        if (supplier == null)
            return null;

        return new SupplierDto
        {
            Id = supplier.Id,
            SupplierName = supplier.SupplierName,
            ContactPerson = supplier.ContactPerson,
            Email = supplier.Email,
            Phone = supplier.Phone,
            Address = supplier.Address,
            CreatedDate = supplier.CreatedDate
        };
    }

    public async Task<int> CreateAsync(CreateSupplierDto dto)
    {
        var supplier = new Supplier
        {
            SupplierName = dto.SupplierName,
            ContactPerson = dto.ContactPerson,
            Email = dto.Email,
            Phone = dto.Phone,
            Address = dto.Address,
            CreatedDate = DateTime.UtcNow
        };

        await _unitOfWork.Suppliers.AddAsync(supplier);

        await _unitOfWork.SaveChangesAsync();

        return supplier.Id;
    }

    public async Task UpdateAsync(int id, UpdateSupplierDto dto)
    {
        var supplier =
            await _unitOfWork.Suppliers.GetByIdAsync(id);

        if (supplier == null)
            throw new Exception("Supplier not found");

        supplier.SupplierName = dto.SupplierName;
        supplier.ContactPerson = dto.ContactPerson;
        supplier.Email = dto.Email;
        supplier.Phone = dto.Phone;
        supplier.Address = dto.Address;

        _unitOfWork.Suppliers.Update(supplier);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var supplier =
            await _unitOfWork.Suppliers.GetByIdAsync(id);

        if (supplier == null)
            throw new Exception("Supplier not found");

        _unitOfWork.Suppliers.Delete(supplier);

        await _unitOfWork.SaveChangesAsync();
    }
}