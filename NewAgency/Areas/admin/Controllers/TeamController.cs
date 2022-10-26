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
    public class TeamController : Controller
    {

        private readonly NewAgencyDBContext _context;
        private readonly IWebHostEnvironment _environment;
        public TeamController(NewAgencyDBContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        // GET: TeamController
        public ActionResult Index()
        {
            var team = _context.Teams.ToList();
            return View(team);
        }

        // GET: TeamController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TeamController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeamController/Create
        [HttpPost]
    
        public ActionResult Create(Team team, IFormFile NewPhoto)
        {
            try
            {

                var photoName = ImageHelper.UploadImage(NewPhoto, _environment);
                team.PhotoURL = photoName;

                team.CreatedDate = DateTime.Now;
                

                _context.Teams.Add(team);
                _context.SaveChanges();
             
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamController/Edit/5
        public ActionResult Edit(int id)
        {
            var team = _context.Teams.FirstOrDefault(c => c.ID == id);
            return View(team);
        }

        // POST: TeamController/Edit/5
        [HttpPost]
       
        public ActionResult Edit(IFormFile NewPhoto, string OldPhoto, Team team)
        {
            if (NewPhoto != null)
            {

                team.PhotoURL = ImageHelper.UploadImage(NewPhoto, _environment);

            }
            else
            {
                team.PhotoURL = OldPhoto;
            }
            _context.Teams.Update(team);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: TeamController/Delete/5
        public ActionResult Delete(int id)
        {
            var team = _context.Teams.FirstOrDefault(c => c.ID == id);
            return View(team);
           
        }

        // POST: TeamController/Delete/5
        [HttpPost]
       
        public ActionResult Delete(Team team)
        {
            try
            {
                _context.Remove(team);
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
