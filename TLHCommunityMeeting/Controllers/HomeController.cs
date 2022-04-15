using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TLHCommunityMeeting.Data;
using TLHCommunityMeeting.Models;

namespace TLHCommunityMeeting.Controllers;

[Route("")]
public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }
    [Route("")]
    public IActionResult Index()
    {
        return View(_context.Questions.OrderBy(m => m.CreatedAt).ToList());
    }
    
    [Route("create")]
    [HttpGet]
    public IActionResult Create()
    {
        return View(new Question());
    }
    
    [Route("create")]
    [HttpPost]
    public IActionResult Create(Question question)
    {
        if (!ModelState.IsValid) return RedirectToAction();
        
        _context.Questions.Add(question);
        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }
}