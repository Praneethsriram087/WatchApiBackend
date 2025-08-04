using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Watch_Api_Backend.Models;
using Watch_Api_Backend.Services;

namespace Watch_Api_Backend.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class UsersController : ControllerBase
{
    private readonly UsersService _usersService;
    public UsersController(UsersService usersService)
    {
        _usersService = usersService;
    }
    [HttpGet]
    public async Task<List<User>> Get()=>
        await _usersService.GetUsersAsync();
    

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<User>> Get(string id)
    {
        var user = await _usersService.GetUserAsync(id);
        if (user is null)
        {
            return NotFound();
        }
        return user;
    }

    [HttpPost]
    public async Task<IActionResult> Post(User newUser)
    {
        User user= new User{Email=newUser.Email,Role=newUser.Role,};
        await _usersService.CreateUserAsync(user);
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }
    




}