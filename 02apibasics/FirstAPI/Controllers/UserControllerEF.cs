using AutoMapper;
using FirstAPI.Data;
using FirstAPI.Dtos;
using FirstAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Controllers;


[ApiController, Route("v1/[controller]")]
public class UserControllerEF(IConfiguration config) : ControllerBase
{
    DBHelperEF _entityFramework = new DBHelperEF(config);
    IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UserToAddDTO, User>()));

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        if (id < 1)
        {
            return BadRequest("Invalid UserId");
        }

        var user = _entityFramework.Users.Where(u => u.UserId == id).FirstOrDefault<User>();

        return user != null ? Ok(user) : NotFound("User not found");
    }

    [HttpGet("users")]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        IEnumerable<User> users = _entityFramework.Users.ToList<User>();

        return users != null ? Ok(users) : NotFound("Users not found");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, UserToAddDTO user)
    {
        if (id < 1)
        {
            return BadRequest("Invalid UserId");
        }

        var userDb = _entityFramework.Users.Where(u => u.UserId == id).FirstOrDefault<User>();

        if (userDb == null) return NotFound("User not found");

        // update field
        userDb.FirstName = user.FirstName;
        userDb.LastName = user.LastName;
        userDb.Email = user.Email;
        userDb.Gender = user.Gender;
        userDb.Active = user.Active;

        return _entityFramework.SaveChanges() > 0 ? Ok("User updated successfully") : NotFound("Error updating user");

    }

    [HttpPost("create-user")]
    public IActionResult CreateUser(UserToAddDTO user)
    {

        var NewUserDb = _mapper.Map<User>(user);
        var userDb = _entityFramework.Add(NewUserDb);

        return _entityFramework.SaveChanges() > 0 ? Ok("User created successfully") : BadRequest("Error creating user");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        if (id < 1)
        {
            return BadRequest("Invalid UserId");
        }

        int rowsAffected = _entityFramework.Users.Where(u => u.UserId == id).ExecuteDelete<User>();

        return rowsAffected != 0 ? Ok("User deleted successfully") : BadRequest("Failed to delete user");
    }

}