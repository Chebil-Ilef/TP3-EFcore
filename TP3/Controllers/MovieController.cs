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
        public ActionResult CreateMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.ImageFile != null && movie.ImageFile.Length > 0)
                {
                    // Enregistrez le fichier image sur le serveur
                    var imagePath = Path.Combine("wwwroot/images", movie.ImageFile.FileName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        movie.ImageFile.CopyTo(stream);
                    }

                    // Enregistrez le chemin de l'image dans la base de données
                    movie.Photo = $"/images/{movie.ImageFile.FileName}";
                }

                _db.movies.Add(movie);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Gestion des erreurs de validation
            return View("Create", movie);
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
                if (movie.ImageFile != null && movie.ImageFile.Length > 0)
                {
                    // Enregistrez le fichier image sur le serveur
                    var imagePath = Path.Combine("wwwroot/images", movie.ImageFile.FileName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        movie.ImageFile.CopyTo(stream);
                    }

                    // Enregistrez le chemin de l'image dans la base de données
                    movie.Photo = $"/images/{movie.ImageFile.FileName}";
                }
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

            // Delete the image file from the /images folder
            if (!string.IsNullOrEmpty(movie.Photo))
            {
                var imagePath = Path.Combine("wwwroot", movie.Photo.TrimStart('/'));

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
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
