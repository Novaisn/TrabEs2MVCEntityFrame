using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class LoginModel
{
    [EmailAddress]
    public string Email { get; set; }
    [MinLength(6)]
    public string Password { get; set; }
}