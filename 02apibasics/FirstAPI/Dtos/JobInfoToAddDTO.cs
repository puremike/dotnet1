using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Dtos;

public class JobInfoToAddDTO
{
    [property: Required(ErrorMessage = "JobTitle is required")]
    [property: StringLength(25)]
    public string JobTitle { get; set; } = "";

    [property: Required(ErrorMessage = "Department is required")]
    [property: StringLength(25)]
    public string Department { get; set; } = "";
}
