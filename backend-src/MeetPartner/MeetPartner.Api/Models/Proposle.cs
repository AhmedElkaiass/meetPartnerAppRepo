using System.ComponentModel.DataAnnotations.Schema;

namespace MeetPartner.Api.Models;
public class Proposle
{
    public int Id { get; set; }
    [ForeignKey("Idea")]
    public int IdeaId { get; set; }
    public Idea Idea { get; set; }
    public DateTime CreatedDate { get; set; }
    [ForeignKey("User")]
    public int ByUserId { get; set; }
    public User User { get; set; }
    [ForeignKey("Status")]
    public int StatusId { get; set; }
    public ProposleStatus Status { get; set; }
}