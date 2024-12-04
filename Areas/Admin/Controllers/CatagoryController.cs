using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    public IActionResult Update(int Id)
    {
        Catagory? catagory = _context.Catagories.Find(Id);
        if (catagory == null)
        {
            return NotFound("bele deyer tapilmadu");
        }
        //CatagoryVM catagoryVM = new CatagoryVM()
        //{
        //    Name= catagory.Name
        //};
        return View(catagory);
    } 
    [HttpPost]
    public IActionResult Update(Catagory catagory)
    {
        Catagory? updateCatagory = _context.Catagories.AsNoTracking().FirstOrDefault(x => x.Id == catagory.Id);
        if (updateCatagory == null)
        {
            return NotFound("No Such Service");
        }
        _context.Catagories.Update(catagory);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

}
