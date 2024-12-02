using Microsoft.AspNetCore.Mvc;
using UniqloProject.DAL;
using UniqloProject.Models;
using UniqloProject.ViewModels;

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
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(CatagoryVM catagoryVM)
    {
        if (ModelState.IsValid)
        {
            Catagory catagory = new Catagory()
            {
                Name = catagoryVM.Name,
            };
            _context.Catagories.Add(catagory);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        return View(catagoryVM);
    }

   /* public IActionResult Update(int Id)
    {
        Catagory? catagory =  _context.Catagories.Find(Id);
        if (catagory == null)
        {
            return NotFound("bele deyer tapilmadu");
        }
        CatagoryVM catagoryVM = new CatagoryVM()
        {
            Name= catagory.Name
        };
        return View(catagoryVM);
    }
    [HttpPost]
    public IActionResult Update(CatagoryVM catagoryVM)
    {
        if (!ModelState.IsValid)
        {
            return View(catagoryVM);
        }

        return View();
    }*/

}
