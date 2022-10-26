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
    public class HeaderController : Controller
    {
        private readonly NewAgencyDBContext _context;
        private readonly IWebHostEnvironment _environment;

        public HeaderController(NewAgencyDBContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: HeadController
        public ActionResult Index()
        {
            var header = _context.Mastheads.ToList();
            return View(header);
        }

        // GET: HeadController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HeadController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Header header, IFormFile NewPhoto)
        {
            header.PhotoURL = ImageHelper.UploadImage(NewPhoto, _environment);
            header.CreatedDate = DateTime.Now;
             _context.Mastheads.Add(header);
           _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            
           
        }

        // GET: HeadController/Edit/5
        public async Task <ActionResult> Edit(int id)
        {
            var header = await _context.Mastheads.FirstOrDefaultAsync(x => x.ID == id);
            return View(header);
        }

        // POST: HeadController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Header header, IFormFile NewPhoto, string OldPhoto)
        {
            try
            {
                if (NewPhoto != null)
                {
                    
                   header.PhotoURL = ImageHelper.UploadImage(NewPhoto, _environment);

                }
                else
                {
                    header.PhotoURL = OldPhoto;
                }
                _context.Mastheads.Update(header);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HeadController/Delete/5
        public ActionResult Delete(int id)
        {
            var header =  _context.Mastheads.FirstOrDefault(x => x.ID == id);

            return View(header);
        }

        // POST: HeadController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Header header)
        {
            _context.Mastheads.Remove(header);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
