using System.ComponentModel.DataAnnotations;

namespace MeetPartner.Api.Models;
public class IdeaType{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}