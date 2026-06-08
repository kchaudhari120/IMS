using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace IMS.Domain.Entities
//{
//    internal class StockTransaction
//    {
//    }
//}

namespace IMS.Domain.Entities;

public class StockTransaction
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string TransactionType { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public DateTime TransactionDate { get; set; }

    public string? Remarks { get; set; }

    public Product Product { get; set; } = null!;
}