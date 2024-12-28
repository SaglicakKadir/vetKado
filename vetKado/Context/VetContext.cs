using Microsoft.EntityFrameworkCore;
using vetKado.Entity;

namespace vetKado.Context
{
    public class VetContext:DbContext
    {
        public VetContext(DbContextOptions<VetContext> options) : base(options) 
        {

        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
    }
}
