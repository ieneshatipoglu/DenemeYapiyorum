using Microsoft.AspNetCore.Mvc;
using DenemeYapiyorum.Models;
using DenemeYapiyorum.Data;

namespace DenemeYapiyorum.Controllers
{
    public class ArabaController : Controller
    {
        private readonly DbBaglantisi _context;
        
        public ArabaController(DbBaglantisi context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var arabalar = _context.Arabalar.ToList();
            return View(arabalar);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost] 
        public IActionResult Create(Araba araba)
        {
            _context.Arabalar.Add(araba);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Guncelle(int id)
        {
            var data = _context.Arabalar.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Guncelle(Araba araba)
        {
            _context.Arabalar.Update(araba);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var data = _context.Arabalar.Find(id);
            _context.Arabalar.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
