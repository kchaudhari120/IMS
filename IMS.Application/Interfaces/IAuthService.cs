using IMS.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace IMS.Application.Interfaces
//{
//    internal class IAuthService
//    {
//    }
//}



namespace IMS.Application.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(RegisterDto dto);

    Task<string> LoginAsync(LoginDto dto);
}