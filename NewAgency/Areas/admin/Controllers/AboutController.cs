using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAgency.Data;
using NewAgency.Helper;
using NewAgency.Models;

namespace NewAgency.Areas.admin.Controllers
{
    [Area(nameof(admin))]
    [Authorize]
    public class AboutController : Controller
    {
        private readonly NewAgencyDBContext _context;
        private readonly IWebHostEnvironment _environment;


        public AboutController(NewAgencyDBContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        // GET: AboutController
        public ActionResult Index()
        {
            var about = _context.Abouts.ToList();
            return View(about);
        }

        // GET: AboutController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AboutController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AboutController/Create
        [HttpPost]
   
        public ActionResult Create(About about, IFormFile NewPhoto)
        {
            try
            {
                about.PhotoURL = ImageHelper.UploadImage(NewPhoto, _environment);
              
                _context.Abouts.Add(about);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

        // GET: AboutController/Edit/5
        public ActionResult Edit(int id)
        {
            var abouts = _context.Abouts.FirstOrDefault();
            return View(abouts);
        }

        // POST: AboutController/Edit/5
        [HttpPost]
    
        public ActionResult Edit(About about, IFormFile NewPhoto, string OldPhoto)
        {
            try
            {
                if (NewPhoto != null)
                {

                    about.PhotoURL = ImageHelper.UploadImage(NewPhoto, _environment);

                }
                else
                {
                    about.PhotoURL = OldPhoto;
                }
                _context.Abouts.Update(about);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AboutController/Delete/5
        public ActionResult Delete(int id)
        {
            var abouts = _context.Abouts.FirstOrDefault();
            return View(abouts);
        }

        // POST: AboutController/Delete/5
        [HttpPost]
     
        public ActionResult Delete(About about)
        {
            try
            {
                _context.Abouts.Remove(about);
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
