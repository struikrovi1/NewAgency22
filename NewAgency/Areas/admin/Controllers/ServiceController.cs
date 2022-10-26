using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAgency.Data;
using NewAgency.Models;

namespace NewAgency.Areas.admin.Controllers
{
    [Area(nameof(admin))]
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly NewAgencyDBContext _context;

        public ServiceController(NewAgencyDBContext context)
        {
            _context = context;
        }

        // GET: ServiceController
        public ActionResult Index()
        {
            var service = _context.Services.ToList();
            return View(service);
        }

        // GET: ServiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
    
        public ActionResult Create(Service service)
        {
            try
            {
                _context.Add(service);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceController/Edit/5
        public ActionResult Edit(int id)
        { 
            return View(_context.Services.FirstOrDefault(c=>c.ID==id));
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
    
        public ActionResult Edit(int id, Service service)
        {
            try
            {
                _context.Update(service);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            return View(_context.Services.FirstOrDefault(c => c.ID == id));
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
     
        public ActionResult Delete(int id, Service service)
        {
            try
            {
                _context.Remove(service);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
