using IMS.Application.DTOs.Auth;
using IMS.Application.Interfaces;
using IMS.Domain.Entities;
using IMS.Infrastructure.Authentication;
using IMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace IMS.Infrastructure.Authentication
//{
//    internal class AuthService
//    {
//    }
//}

namespace IMS.Infrastructure.Authentication;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly IJwtService _jwtService;

    public AuthService(
        ApplicationDbContext context,
        IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    public async Task RegisterAsync(RegisterDto dto)
    {
        var userExists =
            await _context.Users
                .AnyAsync(x => x.Email == dto.Email);

        if (userExists)
            throw new Exception("Email already exists");

        var user = new User
        {
            UserName = dto.UserName,
            Email = dto.Email,
            PasswordHash =
                PasswordHasher.Hash(dto.Password),
            Role = dto.Role
        };

        _context.Users.Add(user);

        await _context.SaveChangesAsync();
    }

    public async Task<string> LoginAsync(LoginDto dto)
    {
        var hashedPassword =
            PasswordHasher.Hash(dto.Password);

        var user =
            await _context.Users.FirstOrDefaultAsync(
                x => x.Email == dto.Email &&
                     x.PasswordHash == hashedPassword);

        if (user == null)
            throw new Exception("Invalid credentials");

        return _jwtService.GenerateToken(user);
    }
}