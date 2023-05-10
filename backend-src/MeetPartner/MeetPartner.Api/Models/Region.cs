using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetPartner.Api.Models;
public class Region{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    [ForeignKey("City")]
    public int CityId { get; set; }
    public City City { get; set; }
}