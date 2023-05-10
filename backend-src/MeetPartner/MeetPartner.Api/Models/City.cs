using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetPartner.Api.Models;
public class City
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    [ForeignKey("Country")]
    public int CountyId { get; set; }
    public Country Country { get; set; }
}