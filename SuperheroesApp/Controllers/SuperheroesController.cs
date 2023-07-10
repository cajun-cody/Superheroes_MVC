using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperheroesApp.Data;
using SuperheroesApp.Models;

namespace SuperheroesApp.Controllers
{
    public class SuperheroesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SuperheroesController(ApplicationDbContext context)
        {
            _context = context;
        }

    
        // GET: SuperheroesController
        public ActionResult Index()
        {
            //Query to get list of superheros
            var superheroes = _context.Superheroes.ToList();
            return View(superheroes);
        }

        // GET: SuperheroesController/Details/5   
        public ActionResult Details(int id)
        {
            //Query to get info for 1 superhero
            var hero = _context.Superheroes.Find(id);
            return View(hero);
        }

        // GET: SuperheroesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperheroesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                _context.Superheroes.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(superhero);
            }
        }

        // GET: SuperheroesController/Edit/5
        public ActionResult Edit(int id)
        {
            //Find the superhero to edit.
            var superhero = _context.Superheroes.Find(id);
            return View(superhero);
        }

        // POST: SuperheroesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero editSuperhero)
        {
            try
            {
                //After hero is found, make changes update and save. 
                _context.Superheroes.Update(editSuperhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var superhero = _context.Superheroes.Find(id);
                return View(superhero);
            }
        }

        // GET: SuperheroesController/Delete/5
        public ActionResult Delete(int id)
        {
            var superhero = (_context.Superheroes.Find(id));
            return View(superhero);
        }

        // POST: SuperheroesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero deleteSuperhero)
        {
            try
            {
                //After superhero is found delete the hero and save changes. 
                _context.Superheroes.Remove(deleteSuperhero);
                _context.SaveChanges(); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var superhero = _context.Superheroes.Find(id);
                return View(superhero);
            }
        }
    }
}
