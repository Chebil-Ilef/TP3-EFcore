using Microsoft.AspNetCore.Mvc;
using TP3.Models;

namespace TP3.Controllers
{
    public class GenreController : Controller
    {
        private readonly AppDbContext _db;

        public GenreController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.genres.ToList());
        }
    }
}
