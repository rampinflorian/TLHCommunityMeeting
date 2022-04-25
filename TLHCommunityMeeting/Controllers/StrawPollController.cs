using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TLHCommunityMeeting.Data;
using TLHCommunityMeeting.Forms;
using TLHCommunityMeeting.Models;
using TLHCommunityMeeting.Services.StrawPoll;

namespace TLHCommunityMeeting.Controllers;

[Route("strawpoll")]
public class StrawPollController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly StrawPollService _strawPollService;

    public StrawPollController(ApplicationDbContext context, StrawPollService? strawPollService)
    {
        _context = context;
        _strawPollService = strawPollService;
    }

    [Route("")]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var strawpolls = await _strawPollService.GetStrawPollsAsync();

        return View(strawpolls);
    }

    [Route("create")]
    [HttpGet]
    public IActionResult Create()
    {
        return View(new StrawPollForm());
    }

    [Route("create")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(StrawPollForm strawPollForm)
    {
        var strawPoll = await _strawPollService.CreateStrawPollAsync(strawPollForm);

        if (strawPoll != null)
        {
            _context.Add(new StrawPoll()
            {
                ApiPath = strawPoll.Poll?.Id
            });

            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }
    
    [Route("delete/{id}")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(string id)
    {
        var strawPoll = await _context.StrawPolls.FirstOrDefaultAsync(m => m.ApiPath == id);

        if (strawPoll == null)
        {
            return NotFound();
        }
        var result = _strawPollService.DeleteStrawPollAsync(strawPoll);

        if (result.Result)
        {
            _context.StrawPolls.Remove(strawPoll);
            await _context.SaveChangesAsync();
        }
        

        return RedirectToAction("Index");
    }
}