using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Dtos;

public class UserToAddDTO
{
    [property: Required(ErrorMessage = "FirstName is required")]
    [property: StringLength(25)]
    public string FirstName { get; set; } = "";

    [property: Required(ErrorMessage = "LastName is required")]
    [property: StringLength(25)]
    public string LastName { get; set; } = "";

    [property: EmailAddress]
    [property: Required(ErrorMessage = "Email address is required")]
    public string Email { get; set; } = "";

    [property: Required(ErrorMessage = "Gender is required")]
    [property: StringLength(10)]
    public string Gender { get; set; } = "";
    public bool Active { get; set; } = false;
}

// public record UserToAddDTO(
//     [property: Required(ErrorMessage = "FirstName is required")]
//     [property: StringLength(50)]
//     string FirstName = "",

//     [property: Required]
//     [property: StringLength(50)]
//     string LastName = "",

//     [property: EmailAddress]
//     string Email = "",

//     [property: StringLength(10)]
//     string Gender = "",

//     bool Active = false);