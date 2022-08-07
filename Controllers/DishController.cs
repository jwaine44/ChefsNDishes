using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers;

public class DishController : Controller
{
    
    private ChefsNDishesContext _context;

    public DishController(ChefsNDishesContext context)
    {
        _context = context;
    }

    [HttpGet("/dishes")]
    public IActionResult Dishes()
    {   
        List<Dish> allDishes = _context.Dishes.Include(d => d.Creator).ToList(); 

        return View("Dishes", allDishes);
    }

    [HttpGet("/dishes/new")]
    public IActionResult NewDish()
    {
        List<Chef> everyChef = _context.Chefs.ToList();
        ViewBag.everyChef = everyChef;
        return View("NewDish");
    }

    [HttpPost("/dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Dishes");
        }
        return NewDish();
    }



}