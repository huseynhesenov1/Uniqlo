using Microsoft.AspNetCore.Mvc;
using UniqloProject.DAL;
using UniqloProject.Models;

namespace UniqloProject.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductController : Controller
{
    private AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        List<Product> products = _context.Products.ToList();
        return View(products);
    }
    public IActionResult Delete(int Id)
    {
        Product? product = _context.Products.Find(Id);
        if (product == null)
        {
            return NotFound("bele product yoxdur");
        }
        product.IsDelete = true;
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}