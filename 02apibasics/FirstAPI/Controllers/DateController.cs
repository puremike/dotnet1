using FirstAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers;

[ApiController, Route("v1/[controller]")]
public class DateController(IConfiguration config)
{
    DBHelperDapper _dapper = new DBHelperDapper(config);

    [HttpGet("date")]
    public DateTime GetDate()
    {
        return _dapper.QuerySingleData<DateTime>("SELECT GETDATE();");
    }

}