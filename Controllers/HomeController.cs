using Microsoft.AspNetCore.Mvc;
using UniqloProject.DAL;
using UniqloProject.Models;

namespace UniqloProject.Controllers
{
    public class HomeController : Controller
    {
      private readonly  AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           List<SliderItem> sliderItems = _context.SliderItems.ToList();
            return View(sliderItems);
        }
    }
}
