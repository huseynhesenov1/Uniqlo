using Microsoft.AspNetCore.Mvc;
using UniqloProject.DAL;
using UniqloProject.Models;

namespace UniqloProject.Areas.Admin.Controllers;
[Area("Admin")]
public class CatagoryController : Controller
{
    private readonly AppDbContext _context;

    public CatagoryController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        List<Catagory> catagories = _context.Catagories.ToList();
        return View(catagories);
       
    }
    public IActionResult Delete(int Id)
    {
        Catagory? catagory = _context.Catagories.Find(Id);
        if (catagory == null)
        {
            return NotFound("bele product yoxdur");
        }
        catagory.IsDelete = true;
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));

    }

}
