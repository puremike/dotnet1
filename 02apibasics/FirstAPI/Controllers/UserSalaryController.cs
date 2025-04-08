using FirstAPI.Data;
using FirstAPI.Dtos;
using FirstAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers;

[ApiController, Route("v1/[controller]")]
public class UserSalaryController(IConfiguration config) : ControllerBase
{
    DBHelperDapper _dapper = new DBHelperDapper(config);
    [HttpGet("salaries")]
    public ActionResult<IEnumerable<UserJobInfo>> GetSalaries()
    {
        string sql = @"SELECT [UserId]
                        ,[Salary]
                        FROM  TutorialAppSchema.UserSalary;";
        IEnumerable<UserSalary> salaries = _dapper.QueryData<UserSalary>(sql);

        return salaries != null ? Ok(salaries) : NotFound("salaries not found");
    }

    [HttpGet("{id}")]
    public IActionResult GetSalary(int id)
    {
        if (id < 1)
        {
            return BadRequest("Invalid UserId");
        }

        string sql = @"SELECT [UserId]
                        ,[Salary]
                        FROM  TutorialAppSchema.UserSalary WHERE UserId = @UserId;";
        var salary = _dapper.QuerySingleData<UserSalary>(sql, new { UserId = id });

        return salary != null ? Ok(salary) : NotFound("salary not found");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateSalary(int id, SalaryToAddDTO salary)
    {
        if (id < 1)
        {
            return BadRequest("Invalid UserId");
        }

        string sql = @"UPDATE TutorialAppSchema.UserSalary
                            SET 
                            Salary = @Salary
                            WHERE UserId = @UserId;";
        int rowsAffected = _dapper.ExecuteQuery(sql, new { UserId = id, salary.Salary });

        return rowsAffected != 0 ? Ok("Salary updated successfully") : BadRequest("error updating salary");
    }

    [HttpPost("create-salary")]
    public IActionResult CreateSalary(SalaryToAddDTO salary)
    {

        string sql = @"INSERT INTO TutorialAppSchema.UserSalary
                        (Salary)
                        OUTPUT INSERTED.*
                        VALUES 
                        (@Salary);";
        var sal = _dapper.QuerySingleData<UserSalary>(sql, new { salary.Salary });

        return sal != null ? Ok(new
        {
            Message = "Salary created successfully",
            Salary = sal,
        }) : BadRequest("error creating salary");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteSalary(int id)
    {
        if (id < 1)
        {
            return BadRequest("Invalid UserId!");
        }

        string sql = @"DELETE FROM TutorialAppSchema.UserSalary WHERE UserId = @UserId";
        int rowsAffected = _dapper.ExecuteQuery(sql, new { UserId = id });

        return rowsAffected != 0 ? Ok("Salary deleted successfully") : BadRequest("error deleting salary");
    }

}

