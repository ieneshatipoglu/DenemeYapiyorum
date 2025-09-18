using DenemeYapiyorum.Data;
using DenemeYapiyorum.Models;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly DbBaglantisi _context;

    public HomeController(DbBaglantisi context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var vm = new Listeleme
        {
            Kisiler = _context.Kisiler.ToList(),
            Arabalar = _context.Arabalar.ToList()
        };

        return View(vm);
    }
}
