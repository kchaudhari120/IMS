using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IMS.Application.DTOs.Product;
public class ProductDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public string SupplierName { get; set; } = string.Empty;

    public int CurrentStock { get; set; }
}