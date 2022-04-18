using Microsoft.AspNetCore.Mvc;
using TLHCommunityMeeting.Data;

namespace TLHCommunityMeeting.Controllers;

[Route("history")]
public class HistoryController : Controller
{
    private readonly ApplicationDbContext _context;

    public HistoryController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        return View(_context.Questions.Where(m => m.MeetingAt != null).OrderBy(m => m.CreatedAt).ToList());
    }
}