using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IMS.Application.DTOs.Supplier;

namespace IMS.Application.Interfaces;

public interface ISupplierService
{
    Task<List<SupplierDto>> GetAllAsync();

    Task<SupplierDto?> GetByIdAsync(int id);

    Task<int> CreateAsync(CreateSupplierDto dto);

    Task UpdateAsync(int id, UpdateSupplierDto dto);

    Task DeleteAsync(int id);
}