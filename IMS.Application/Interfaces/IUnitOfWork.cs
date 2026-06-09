using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IMS.Domain.Entities;

namespace IMS.Application.Interfaces;

public interface IUnitOfWork
{
    IRepository<Category> Categories { get; }

    IRepository<Product> Products { get; }

    IRepository<Supplier> Suppliers { get; }

    IRepository<StockTransaction> StockTransactions { get; }

    Task<int> SaveChangesAsync();
}