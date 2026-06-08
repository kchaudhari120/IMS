using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace IMS.Domain.Entities
//{
//    internal class Product
//    {
//    }
//}

namespace IMS.Domain.Entities;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public int SupplierId { get; set; }

    public int CurrentStock { get; set; }

    public DateTime CreatedDate { get; set; }

    public Category Category { get; set; } = null!;

    public Supplier Supplier { get; set; } = null!;
}