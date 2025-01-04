namespace vetKado.Entity
{
    public class Vaccine
    {
        public int VaccineId { get; set; }
        public string VaccineName { get; set; }
        public string VaccineDescription { get; set; }
        public DateTime VaccineDate { get; set; } = DateTime.Now;
        public DateTime? VaccineTime { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
