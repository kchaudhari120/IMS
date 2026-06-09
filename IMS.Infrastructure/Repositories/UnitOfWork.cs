using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IMS.Application.Interfaces;
using IMS.Domain.Entities;
using IMS.Infrastructure.Data;

namespace IMS.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        Categories = new Repository<Category>(_context);

        Products = new Repository<Product>(_context);

        Suppliers = new Repository<Supplier>(_context);

        StockTransactions =
            new Repository<StockTransaction>(_context);
    }

    public IRepository<Category> Categories { get; }

    public IRepository<Product> Products { get; }

    public IRepository<Supplier> Suppliers { get; }

    public IRepository<StockTransaction> StockTransactions { get; }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}