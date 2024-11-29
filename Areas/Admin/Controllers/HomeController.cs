using Microsoft.AspNetCore.Mvc;
using UniqloProject.DAL;
using UniqloProject.Models;

namespace UniqloProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<SliderItem> sliderItems = _context.SliderItems.ToList();
            return View(sliderItems);
        }

        public IActionResult Delete(int Id)
        {
            SliderItem? deleteourWork = _context.SliderItems.Find(Id);
            if (deleteourWork == null)
            {
                return NotFound("NO such Works");
            }


            _context.SliderItems.Remove(deleteourWork);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(SliderItem sliderItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("smth went wrong");
            }
            else
            {
                _context.SliderItems.Add(sliderItem);
                _context.SaveChanges();
            }


            return RedirectToAction(nameof(Index));
        }



    }
}
