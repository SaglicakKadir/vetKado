namespace vetKado.Entity
{
    public class Pet
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public List<Treatment> Treatments { get; set; }
    }
}
