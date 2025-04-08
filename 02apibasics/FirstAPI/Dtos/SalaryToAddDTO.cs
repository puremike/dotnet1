using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Dtos;

public class SalaryToAddDTO
{

    [property: Required(ErrorMessage = "Salary is required")]
    public decimal Salary { get; set; }
}
