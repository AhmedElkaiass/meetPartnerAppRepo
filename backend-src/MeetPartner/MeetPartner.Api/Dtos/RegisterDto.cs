using System.ComponentModel.DataAnnotations;
namespace MeetPartner.Api.Dtos;
public class RegisterDto
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string FullName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string ConfirmPassord { get; set; }
    public int RegionId { get; set; }
}
public class UserActionResult
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public string ErrorMessage { get; set; }
    public object Data { get; set; }
}
public class LoginDto
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }    
}