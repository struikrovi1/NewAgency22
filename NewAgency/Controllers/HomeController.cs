using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewAgency.Data;
using NewAgency.Models;
using NewAgency.ViewModels;
using System.Diagnostics;

namespace NewAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NewAgencyDBContext _context;

        public HomeController(ILogger<HomeController> logger, NewAgencyDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            IndexVM vm = new()
            {
                Header = _context.Mastheads.FirstOrDefault(),
                Services = _context.Services.Take(3).ToList(),
                Portfolios = _context.Portfolios.Include(c=>c.Category).Take(6).ToList(),  
                Teams = _context.Teams.Take(3).ToList(),
                Abouts = _context.Abouts.Take(4).ToList(),
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(ContactUs contact)
        {

            _context.Add(contact);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}