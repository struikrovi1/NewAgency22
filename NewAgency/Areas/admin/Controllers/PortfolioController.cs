using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewAgency.Data;
using NewAgency.Helper;
using NewAgency.Models;

namespace NewAgency.Areas.admin.Controllers
{
    [Area(nameof(admin))]
    [Authorize]
    public class PortfolioController : Controller
    {

        private readonly NewAgencyDBContext _context;
        private readonly IWebHostEnvironment _environment;

        public PortfolioController(NewAgencyDBContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        // GET: PortfolioController
        public ActionResult Index()
        {
            var port = _context.Portfolios.Include(c => c.Category).ToList();
            return View(port);
        }

        // GET: PortfolioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PortfolioController/Create
        public ActionResult Create()
        {
            ViewData["Categories"] = _context.Categories.ToList();
            return View();
        }

        // POST: PortfolioController/Create
        [HttpPost]
        
        public ActionResult Create(Portfolio portfolio, int categoryId, IFormFile NewPhoto)
        {
            try
            {
                var photoName = ImageHelper.UploadImage(NewPhoto, _environment);
                portfolio.PhotoURL = photoName;

                portfolio.CreatedDate = DateTime.Now;
                portfolio.CategoryID = categoryId;

                _context.Portfolios.Add(portfolio);
                _context.SaveChanges();
                return RedirectToAction("Index");
               
            }
            catch
            {
                return View();
            }
        }

        // GET: PortfolioController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["Categories"] = _context.Categories.ToList();
            var portfolio = _context.Portfolios.SingleOrDefault(c => c.ID == id);
            return View(portfolio);
            
        }

        // POST: PortfolioController/Edit/5
        [HttpPost]
       
        public ActionResult Edit(Portfolio portfolio, IFormFile NewPhoto, string OldPhoto)
        {
            ViewData["Categories"] = _context.Categories.ToList();
            if (NewPhoto != null)
            {
               
                portfolio.PhotoURL = ImageHelper.UploadImage(NewPhoto, _environment);

            }
            else
            {
                portfolio.PhotoURL = OldPhoto;
            }
            portfolio.IsDeleted = !portfolio.IsDeleted;
            _context.Portfolios.Update(portfolio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: PortfolioController/Delete/5
        public ActionResult Delete(int id)
        {
            var portfolio = _context.Portfolios.SingleOrDefault(c => c.ID == id);
            return View(portfolio);
        }

        // POST: PortfolioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Portfolio portfolio)
        {
            try
            {
                var pro = _context.Portfolios.FirstOrDefault(x => x.ID == portfolio.ID);
                pro.IsDeleted = true;
                 _context.SaveChangesAsync();
                return RedirectToAction("Index");



            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
