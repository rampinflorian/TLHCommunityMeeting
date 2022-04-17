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
        var list = _context.Questions.OrderBy(m => !string.IsNullOrEmpty(m.Answer)).ThenBy(m => m.CreatedAt).ToList();
        return View(list);
    }
    
    [Route("details/{questionId:int}")]
    [HttpGet]
    public IActionResult Details(int questionId)
    {
        var question = _context.Questions.First(m => m.QuestionId == questionId);

        return View(question);
    }
    
    
    [Route("create")]
    [HttpGet]
    public IActionResult Create()
    {
        return View(new Question());
    }
    
    [Route("create")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Question question)
    {
        if (!ModelState.IsValid)
        {
            return View(question);
        }
        _context.Questions.Add(question);
        _context.SaveChanges();
        
        return RedirectToAction(nameof(Index));
    }
    
    [Route("edit/{id:int}")]
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var question = _context.Questions.Find(id);
        if (question == null) return RedirectToAction(nameof(Index));
        
        return View(question);
    }
    
    [Route("edit/{id:int}")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Question question)
    {
        if (!ModelState.IsValid) return RedirectToAction(nameof(Index));
        
        _context.Questions.Update(question);
        _context.SaveChanges();
        
        return RedirectToAction(nameof(Index));
    }
    
    [Route("delete/{id:int}")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var question = _context.Questions.Find(id);
        if (question == null) return RedirectToAction(nameof(Index));

        _context.Remove(question);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));


    }
    
}