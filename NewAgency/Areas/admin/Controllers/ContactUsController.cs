using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAgency.Data;

namespace NewAgency.Areas.admin.Controllers
{
    [Area(nameof(admin))]
    [Authorize]
    public class ContactUsController : Controller
    {
        private readonly NewAgencyDBContext _context;
        

        public ContactUsController(NewAgencyDBContext context)
        {
            _context = context;
           
        }
        // GET: ContactUsController
        public ActionResult Index()
        {
            var contactUs = _context.ContactUs.ToList(); 
            return View(contactUs);
        }

        // GET: ContactUsController/Details/5
        public ActionResult Details(int id)
        {
            var contact = _context.ContactUs.FirstOrDefault(c => c.ID == id);
            return View(contact);
        }

        // GET: ContactUsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactUsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactUsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactUsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactUsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactUsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
