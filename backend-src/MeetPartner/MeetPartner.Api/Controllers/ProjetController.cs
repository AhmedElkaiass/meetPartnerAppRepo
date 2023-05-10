using MeetPartner.Api.Data;
using MeetPartner.Api.Dtos;
using MeetPartner.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetPartner.Api.Contollers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProjectController : ControllerBase
{
    private readonly AppDbContext _db;
    public ProjectController(AppDbContext db)
    {
        _db = db;
    }
    [HttpPost("")]
    public async Task<ActionResult> Post(Idea idea)
    {
        UserActionResult result = new();
        string id = User.Claims.Where(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).SingleOrDefault()?.Value;
        idea.ByUserId = Convert.ToInt32(id);
        _db.Ideas.Add(idea);
        await _db.SaveChangesAsync();
        result.IsSuccess = true;
        return Ok(result);
    }
    [HttpGet("ByMe")]
    public ActionResult GetByMe(int? TypeId)
    {
        UserActionResult result = new();
        string id = User.Claims.Where(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).SingleOrDefault()?.Value;
        result.Data = _db.Ideas.Where(x => x.ByUserId == Convert.ToInt32(id) && (!TypeId.HasValue || x.IdeaTypeId == TypeId.Value)).Select(x => new
        {
            x.Title,
            x.Description,
            x.ExpectedProfitRatio,
            ByUser = x.ByUser.FullName
        }).ToList();
        return Ok(result);
    }
    [HttpGet("")]
    public ActionResult Get(int? TypeId)
    {
        UserActionResult result = new();
        result.Data = _db.Ideas.Where(x => (!TypeId.HasValue || x.IdeaTypeId == TypeId.Value)).Select(x => new
        {
            x.Title,
            x.Description,
            x.ExpectedProfitRatio,
            ByUser = x.ByUser.FullName
        }).ToList();
        return Ok(result);
    }
}