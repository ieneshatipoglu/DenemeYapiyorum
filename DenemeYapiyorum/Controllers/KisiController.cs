using Microsoft.AspNetCore.Mvc;
using DenemeYapiyorum.Data;
using DenemeYapiyorum.Models;

namespace DenemeYapiyorum.Controllers
{
    public class KisiController : Controller
    {
        private readonly DbBaglantisi _context;
        public KisiController(DbBaglantisi context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var kisiler = _context.Kisiler.ToList();
            return View(kisiler);


        }
        [HttpGet]
        public IActionResult KisiEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KisiEkle(Kisi kisi)
        {
            _context.Kisiler.Add(kisi);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = _context.Kisiler.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Kisi kisi)
        {
            var data = _context.Kisiler.Update(kisi);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var data = _context.Kisiler.Find(id);
            _context.Kisiler.Remove(data);
                _context.SaveChanges();
            return RedirectToAction("Index");
        }
     }
 }

