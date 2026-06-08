using IMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace IMS.Application.Interfaces
//{
//    internal interface IJwtService
//    {
//    }
//}



namespace IMS.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}