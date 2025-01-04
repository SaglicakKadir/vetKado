using vetKado.Entity;
//sahiple hayvanın aynı anda oluşturulması için oluşturulmuş bir model
namespace vetKado.Models
{
    public class PetOwnerViewModel
    {
        public Pet Pet { get; set; }
        public Owner Owner { get; set; }

        public PetOwnerViewModel()
        {
            Pet = new Pet();
            Owner = new Owner();
        }
    }
}
