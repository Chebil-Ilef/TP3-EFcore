using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP3.Models;

namespace TP3.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _db;

        public MovieController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.movies.ToList());
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie c)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            

            c.Id = new int();
            _db.movies.Add(c);
            _db.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var movie = _db.movies.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

           

            return View(movie);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {

                _db.Entry(movie).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        public IActionResult Delete(int id)
        {
            var movie = _db.movies.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _db.movies.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            _db.movies.Remove(movie);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Details(int? id)
        {
            if (id == null) return Content("unable to find Id");
            var c = _db.movies.SingleOrDefault(c => c.Id == id);
            return View(c);
        }
    }
}
