using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vetKado.Context;

namespace vetKado.Controllers
{
    public class TreatmentController : Controller
    {
        private readonly VetContext _context;
        public TreatmentController(VetContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var pets= await _context.Treatments.Include(p=>p.Pet).ToListAsync();
            return View(pets);
        }
    }
}
