using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniqloProject.DAL;
using UniqloProject.Models;
using UniqloProject.ViewModels;

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
    public IActionResult Create()
    {
        ViewBag.Catagories = new SelectList(_context.Catagories, "Id", "Name");

        return View();
    }
    [HttpPost]
    public IActionResult Create(ProductVM productVM)
    {
        if (ModelState.IsValid)
        {
            Product product = new Product()
            {
                Title = productVM.Title,
                ImgUrl = productVM.ImgUrl,
                Price = productVM.Price,
                NewPrice = productVM.NewPrice,
                CatagoryId = productVM.CatagoryId,
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Catagories = new SelectList(_context.Catagories, "Id", "Name");
        return View(productVM);
    }
 
    public IActionResult Update(int Id)
    {
       Product? product = _context.Products.Find(Id);
        if (product == null)
        {
            return NotFound("Bu id ye uygunun tapilmafdi");
        }
        ProductVM productVM = new ProductVM()
        {
            Title= product.Title,
            ImgUrl = product.ImgUrl,
            Price = product.Price,
            NewPrice = product.NewPrice,
            CatagoryId = product.CatagoryId


        };
        ViewBag.Catagories = new SelectList(_context.Catagories, "Id", "Name");
        return View(productVM);
    }
    [HttpPost]
    public IActionResult Update(int id, ProductVM productVM)
    {
       Product? updateProduct = _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (updateProduct == null)
        {
            return NotFound("tapilmadi");
        }
        Product product = new Product()
        {
            Id= id,
            Title= productVM.Title,
            ImgUrl= productVM.ImgUrl,
            Price = productVM.Price,
            NewPrice = productVM.NewPrice,
            CatagoryId = productVM.CatagoryId
        };
        ViewBag.Catagories = new SelectList(_context.Catagories, "Id", "Name");
        _context.Products.Update(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index),"Home");
    }
}