using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vetKado.Context;
using vetKado.Entity;

namespace vetKado.Controllers
{
    public class OwnerController : Controller
    {
        private readonly VetContext _context;
        public OwnerController(VetContext context)
        {
            _context = context;
        }
        [HttpGet]
        // GET: Owner
        public async Task<IActionResult> Index()
        {
            var owners = await _context.Owners.ToListAsync();
            return View(owners);
        }

        // GET: Owner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var owner = await _context.Owners
                .Include(o => o.Pets)
                .FirstOrDefaultAsync(o => o.OwnerId == id);

            if (owner == null)
                return NotFound();

            return View(owner);
        }

        // GET: Owner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Owner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,Address")] Owner owner)
        {
            
                _context.Add(owner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            return View(owner);
        }

        // GET: Owner/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var editOwner = await _context.Owners.FindAsync(id);
            if (editOwner == null)
            {
                return NotFound();
            }
            return View(editOwner);
        }

        // POST: Owner/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Owner owner)
        {

            
                    _context.Update(owner);
                    await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            
          //  return View(owner);
        }

        // GET: Owner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var deleteOwner = await _context.Owners.FindAsync(id);
            _context.Remove(deleteOwner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Owner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner != null)
            {
                _context.Owners.Remove(owner);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool OwnerExists(int id)
        {
            return _context.Owners.Any(e => e.OwnerId == id);
        }
    }
}
    

