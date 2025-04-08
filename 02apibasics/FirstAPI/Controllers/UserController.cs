using FirstAPI.Data;
using FirstAPI.Dtos;
using FirstAPI.Model;
using Microsoft.AspNetCore.Mvc;


namespace FirstAPI.Controllers;

[ApiController, Route("v1/[controller]")]
public class UserController(IConfiguration config) : ControllerBase
{

    private readonly DBHelperDapper _dapper = new DBHelperDapper(config);

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        if (id < 1)
        {
            return BadRequest("Invalid UserId!");
        }
        string sql = @"SELECT [UserId], [FirstName], [LastName], [Email], [Gender], [Active] FROM TutorialAppSchema.Users WHERE UserId = @UserId;";

        var user = _dapper.QuerySingleData<User>(sql, new { UserId = id });
        return user != null ? Ok(user) : NotFound("User not found");
    }

    [HttpGet("users")]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        string sql = @"SELECT  [UserId], [FirstName], [LastName], [Email], [Gender], [Active] FROM TutorialAppSchema.Users;";

        IEnumerable<User> users = _dapper.QueryData<User>(sql);

        return users != null ? Ok(users) : NotFound("Users not found");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, UserToAddDTO user)
    {

        if (id < 1)
        {
            return BadRequest("Invalid UserId");
        }
        string sql = @"UPDATE TutorialAppSchema.Users 
                            SET 
                            FirstName = @FirstName, 
                            LastName = @LastName, 
                            Email = @Email, 
                            Gender = @Gender, 
                            Active = @Active 
                            WHERE UserId = @UserId;";

        int rowsAffected = _dapper.ExecuteQuery(sql, new { UserId = id, user.FirstName, user.LastName, user.Email, user.Gender, user.Active });

        return rowsAffected != 0 ? Ok("User updated successfully") : BadRequest("error updating user");
    }

    [HttpPost("create-user")]
    public IActionResult CreateUser(UserToAddDTO user)
    {

        string sql = @"INSERT INTO TutorialAppSchema.Users 
    (FirstName, LastName, Email, Gender, Active)
                        OUTPUT INSERTED.*
                        VALUES 
    (@FirstName, @LastName, @Email, @Gender, @Active);";

        var createdUser = _dapper.QuerySingleData<User>(sql, new { user.FirstName, user.LastName, user.Email, user.Gender, user.Active });

        return createdUser != null ? Ok(new
        {
            Message = "User created successfully",
            User = createdUser
        }) : BadRequest("Error creating user");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        if (id < 1)
        {
            return BadRequest("Invalid UserId!");
        }

        string sql = @"DELETE FROM TutorialAppSchema.Users WHERE UserId = @UserId";
        int rowsAffected = _dapper.ExecuteQuery(sql, new { UserId = id });

        return rowsAffected != 0 ? Ok("User deleted successfully") : BadRequest("error deleting user");
    }
}
