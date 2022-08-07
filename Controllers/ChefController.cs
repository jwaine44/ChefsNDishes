using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers;

public class ChefController : Controller
{

    private ChefsNDishesContext _context;

    public ChefController(ChefsNDishesContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {   
        List<Chef> allChefs = _context.Chefs.Include(c => c.CreatedDishes).ToList(); 

        return View("Index", allChefs);
    }

    [HttpGet("/new")]
    public IActionResult NewChef()
    {
        return View("NewChef");
    }

    [HttpPost("/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return NewChef();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
