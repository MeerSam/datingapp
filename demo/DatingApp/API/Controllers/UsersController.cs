using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]

[Route("api/[controller]")] // /api/users
public class UsersController(DataContext context) : ControllerBase
{
    // // OLD WAY of doing 
    // private readonly DataContext _context; // private fields with Underscore

    // public UsersController(DataContext context)
    // {
    //     _context = context; 
    // }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();
        return users;
    }

    [HttpGet("{id:int}")] // /api/users/2    // or just use HttpGet("{id}"
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null) return NotFound();
        return user;
    }
}
