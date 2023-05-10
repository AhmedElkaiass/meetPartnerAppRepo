using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetPartner.Api.Models;

public class User{
    [Key]
    public int Id { get; set; } 
    [Required]
    public string Email { get; set; }
    [Required]
    public string FullName { get; set; }
    public string HashPasword { get; set; } 
    [ForeignKey("Region")]
    public int RegionId { get; set; }
    public Region Region { get; set; }
}