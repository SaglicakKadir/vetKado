using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vetKado.Context;
using vetKado.Entity;

namespace vetKado.Controllers
{
    public class PetController : Controller
    {
        private readonly VetContext _context;
        public PetController(VetContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var pets = await _context.Pets.Include(p=>p.Owner).ToListAsync();
            return View(pets);
        }
        public IActionResult Create()
        {
            ViewBag.OwnerList = new SelectList(_context.Owners, "OwnerId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pet pet)
        {
            
            _context.Add(pet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
//            ViewBag.OwnerList = new SelectList(_context.Owners, "OwnerId", "Name");
            return View(pet);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var editPet = await _context.Pets.FindAsync(id);
            ViewBag.OwnerList = new SelectList(_context.Owners, "OwnerId", "Name");
            if (editPet == null)
            {
                return NotFound();
            }
            return View(editPet);
        }

        // POST: Owner/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Pet pet)
        {


            _context.Update(pet);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

            //  return View(owner);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var deletePet = await _context.Pets.FindAsync(id);
            _context.Remove(deletePet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var pet = await _context.Pets
                .Include(p => p.Owner) // Sahibi dahil ediyoruz
                .Include(p => p.Treatments) // Tedavileri dahil ediyoruz
                .FirstOrDefaultAsync(m => m.PetId == id);
            return View(pet);
        }
    }
}
