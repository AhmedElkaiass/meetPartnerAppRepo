using MeetPartner.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetPartner.Api.Data;
public class AppDbContext:DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
    }
    public DbSet<City> Cities { get; set; }    
    public DbSet<Country> Coutries { get; set; }
    public DbSet<Idea> Ideas { get; set; }
    public DbSet<IdeaType> IdeaTypes { get; set; }
    public DbSet<Proposle> Proposles { get; set; }  
    public DbSet<ProposleStatus> ProposleStatuses { get; set; }  
    public DbSet<Region> Regions { get; set; }
    public DbSet<User> Users { get; set; }
}