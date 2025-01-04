using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Runtime.InteropServices;
using vetKado.Context;
using vetKado.Entity;
using vetKado.Models;

namespace vetKado.Controllers
{
    public class PetController : Controller
    {
        private readonly VetContext _context;
        public PetController(VetContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchName, string searchSpecies, string searchOwner, string searchBreed)
        {
            var pets = from p in _context.Pets.Include(p => p.Owner)
                       select p;

            // Arama kriterlerine göre filtreleme
            if (!string.IsNullOrEmpty(searchName))
            {
                pets = pets.Where(p => p.Name.Contains(searchName));
            }

            if (!string.IsNullOrEmpty(searchSpecies))
            {
                pets = pets.Where(p => p.Species.Contains(searchSpecies));
            }

            if (!string.IsNullOrEmpty(searchBreed))
            {
                pets = pets.Where(p => p.Breed.Contains(searchBreed));
            }

            if (!string.IsNullOrEmpty(searchOwner))
            {
                pets = pets.Where(p => p.Owner.Name.Contains(searchOwner));
            }

            // ViewData ile arama kriterlerini View'a gönderme
            ViewData["searchName"] = searchName;
            ViewData["searchSpecies"] = searchSpecies;
            ViewData["searchOwner"] = searchOwner;
            ViewData["searchBreed"] = searchBreed;

            return View(await pets.ToListAsync());
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
                .Include(p => p.Vaccines) // Aşıları dahil ediyoruz
                .FirstOrDefaultAsync(m => m.PetId == id);
            return View(pet);
        }
        public async Task<IActionResult> CreateTreatment(int id) // id, PetId olarak gelecek
        {
            var pet = await _context.Pets.FindAsync(id);
            ViewBag.PetName = pet.Name; // Hayvan adını görüntülemek için
            ViewBag.PetId = pet.PetId;  // Tedaviye bağlamak için
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTreatment(Treatment treatment)
        {

            _context.Add(treatment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //            ViewBag.OwnerList = new SelectList(_context.Owners, "OwnerId", "Name");
            return View(treatment);
        }
        public async Task<IActionResult> CreateVaccine(int id) // id, PetId olarak gelecek
        {
            var pet = await _context.Pets.FindAsync(id);
            ViewBag.PetName = pet.Name; // Hayvan adını görüntülemek için
            ViewBag.PetId = pet.PetId;  // Tedaviye bağlamak için
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVaccine(Vaccine vaccine)
        {
            _context.Add(vaccine);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
            return View(vaccine);
        }


        public ActionResult NewRecord()
        {
            return View(new PetOwnerViewModel());
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewRecord(PetOwnerViewModel model)
        {
            
                // Sahip kaydını oluştur
                _context.Owners.Add(model.Owner);
                await _context.SaveChangesAsync();

                // Hayvan kaydını oluştur ve sahip ile ilişkilendir
                model.Pet.OwnerId = model.Owner.OwnerId;
                _context.Pets.Add(model.Pet);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index"); 
                return View(model);
        }

    }
}
