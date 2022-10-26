using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAgency.Data;
using NewAgency.Models;

namespace NewAgency.Areas.admin.Controllers
{
    [Area(nameof(admin))]
 [Authorize]
    public class CategoryController : Controller
    {
        private readonly NewAgencyDBContext _context;

        public CategoryController(NewAgencyDBContext context)
        {
            _context = context;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            var category = _context.Categories.ToList();
            return View(category);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
           

            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]

        public ActionResult Create(Category category)
        {
            try


            {
                category.CreatedDate = DateTime.Now;    
                _context.Add(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.ID == id);
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
       
        public ActionResult Edit(Category category)
        {
            try
            {
                _context.Update(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.ID == id);
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
      
        public ActionResult Delete(Category category)
        {
            try
            { var cat = _context.Categories.FirstOrDefault(c => c.ID == category.ID);
                cat.IsDeleted = true;
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
