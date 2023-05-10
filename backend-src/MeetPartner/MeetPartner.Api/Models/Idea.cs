using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetPartner.Api.Models;
public class Idea
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Tag { get; set; }
    public float ExpectedCost { get; set; }
    public float ExpectedProfitRatio { get; set; }
    [ForeignKey("ByUser")]
    public int ByUserId { get; set; }
    public User ByUser { get; set; }
    
    [ForeignKey("IdeaType")]
    public int IdeaTypeId { get; set; }
    public IdeaType IdeaType { get; set; }
}