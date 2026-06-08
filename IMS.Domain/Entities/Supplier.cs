using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace IMS.Domain.Entities
//{
//    internal class Supplier
//    {
//    }
//}

namespace IMS.Domain.Entities;

public class Supplier
{
    public int Id { get; set; }

    public string SupplierName { get; set; } = string.Empty;

    public string? ContactPerson { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateTime CreatedDate { get; set; }
}