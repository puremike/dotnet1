using FirstAPI.Data;
using FirstAPI.Dtos;
using FirstAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers;

[ApiController, Route("v1/[controller]")]
public class UserJobInfoController(IConfiguration config) : ControllerBase
{
    DBHelperDapper _dapper = new DBHelperDapper(config);
    [HttpGet("jobs-info")]
    public ActionResult<IEnumerable<UserJobInfo>> GetJobsInfo()
    {
        string sql = @"SELECT [UserId]
                        ,[JobTitle]
                        ,[Department]
                        FROM  TutorialAppSchema.UserJobInfo;";
        IEnumerable<UserJobInfo> jobs = _dapper.QueryData<UserJobInfo>(sql);

        return jobs != null ? Ok(jobs) : NotFound("jobs not found");
    }

    [HttpGet("{id}")]
    public IActionResult GetJobInfo(int id)
    {
        if (id < 1)
        {
            return BadRequest("Invalid UserId");
        }

        string sql = @"SELECT [UserId]
                        ,[JobTitle]
                        ,[Department]
                        FROM  TutorialAppSchema.UserJobInfo WHERE UserId = @UserId;";
        var job = _dapper.QuerySingleData<UserJobInfo>(sql, new { UserId = id });

        return job != null ? Ok(job) : NotFound("job not found");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateJobInfo(int id, JobInfoToAddDTO jobInfo)
    {
        if (id < 1)
        {
            return BadRequest("Invalid UserId");
        }

        string sql = @"UPDATE TutorialAppSchema.UserJobInfo
                            SET 
                            JobTitle = @JobTitle,
                            Department = @Department
                            WHERE UserId = @UserId;";
        int rowsAffected = _dapper.ExecuteQuery(sql, new { UserId = id, jobInfo.JobTitle, jobInfo.Department });

        return rowsAffected != 0 ? Ok("Job updated successfully") : BadRequest("error updating job");
    }

    [HttpPost("create-job")]
    public IActionResult CreateJobInfo(JobInfoToAddDTO jobInfo)
    {

        string sql = @"INSERT INTO TutorialAppSchema.UserJobInfo
                        (JobTitle, Department)
                        OUTPUT INSERTED.*
                        VALUES 
                        (@JobTitle, @Department);";
        var job = _dapper.QuerySingleData<UserJobInfo>(sql, new { jobInfo.JobTitle, jobInfo.Department });

        return job != null ? Ok(new
        {
            Message = "Job created successfully",
            Job = job,
        }) : BadRequest("error creating job");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        if (id < 1)
        {
            return BadRequest("Invalid UserId!");
        }

        string sql = @"DELETE FROM TutorialAppSchema.UserJobInfo WHERE UserId = @UserId";
        int rowsAffected = _dapper.ExecuteQuery(sql, new { UserId = id });

        return rowsAffected != 0 ? Ok("Job deleted successfully") : BadRequest("error deleting user");
    }

}

